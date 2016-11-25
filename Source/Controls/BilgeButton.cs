using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ScriptFUSION.UpDown_Meter.Controls {
    [DefaultEvent("Click")]
    public partial class BilgeButton : Control {
        private bool mouseDown, mouseOver, selected, frozen;

        public Image Image { get; set; }

        [DefaultValue(false)]
        public bool ToggleButton { get; set; }

        /// <summary>
        /// True to syncronize freeze state with selected state, otherwise false.
        /// </summary>
        [DefaultValue(false)]
        public bool FreezeOnSelect { get; set; }

        [DefaultValue(false)]
        public bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;

                if (FreezeOnSelect) {
                    Frozen = value;
                }

                Invalidate();
            }
        }

        [DefaultValue(false)]
        public bool Frozen
        {
            get { return frozen; }
            set
            {
                if ((frozen = value) == false) {
                    // Force button to revert mouse over state.
                    IsMouseOver = false;
                }
            }
        }

        private bool IsMouseDown
        {
            get { return mouseDown; }
            set
            {
                mouseDown = value;
                Invalidate();
            }
        }

        private bool IsMouseOver
        {
            get { return mouseOver; }
            set
            {
                mouseOver = value;
                Invalidate();
            }
        }

        public BilgeButton() {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.StandardDoubleClick, false);
        }

        public void SimulateClick() {
            OnClick(EventArgs.Empty);
        }

        protected override void OnPaint(PaintEventArgs e) {
            if (DesignMode) {
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle, ForeColor, ButtonBorderStyle.Dashed);
            }

            if (Image == null) return;

            var imageX = Width / 2 - Image.Width / 2;
            var imageY = Height / 2 - Image.Height / 2;

            if (IsMouseOver || Selected) {
                // Draw mono image.
                if (!IsMouseDown || !Selected) {
                    e.Graphics.DrawImageMono(Image, BackColor.Darken(.2f), imageX, imageY);
                }

                // Draw filled background.
                using (var brush = new SolidBrush(
                    Color.FromArgb(
                        Selected ?
                            IsMouseOver ? 128 : 26 :
                            IsMouseDown ? 192 : 64,
                        SystemColors.Highlight
                    )
                )) {
                    e.Graphics.FillRectangle(brush, ClientRectangle);
                }

                // Draw border.
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle, SystemColors.Highlight, ButtonBorderStyle.Solid);
            }

            var offset = IsMouseOver && !IsMouseDown && !Selected ? 1 : 0;
            e.Graphics.DrawImageTranslucent(Image, Selected ? 1 : .75f, imageX - offset, imageY - offset);
        }

        private void BilgeButton_Click(object sender, EventArgs e) {
            if (ToggleButton) {
                Selected = !Selected;
            }
        }

        private void BilgeButton_MouseEnter(object sender, EventArgs e) {
            if (!Frozen) {
                IsMouseOver = true;
            }
        }

        private void BilgeButton_MouseLeave(object sender, EventArgs e) {
            IsMouseDown = IsMouseOver = false;
        }

        private void BilgeButton_MouseDown(object sender, MouseEventArgs e) {
            if ((e.Button & MouseButtons.Left) > 0) {
                IsMouseDown = true;
            }
        }

        private void BilgeButton_MouseUp(object sender, MouseEventArgs e) {
            if ((e.Button & MouseButtons.Left) > 0) {
                IsMouseDown = false;
            }
        }
    }
}
