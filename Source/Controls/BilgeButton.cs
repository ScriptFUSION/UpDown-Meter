using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ScriptFUSION.UpDown_Meter.Controls {
    [DefaultEvent("Click")]
    public partial class BilgeButton : UserControl {
        private bool mouseDown, mouseOver;

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

        public Image Image { get; set; }

        public BilgeButton() {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e) {
            if (Image == null) return;

            var imageX = Width / 2 - Image.Width / 2;
            var imageY = Height / 2 - Image.Height / 2;

            if (IsMouseOver) {
                if (!IsMouseDown) {
                    e.Graphics.DrawImageMono(Image, BackColor.Darken(.2f), imageX, imageY);
                }

                using (var brush = new SolidBrush(Color.FromArgb(IsMouseDown ? 192 : 64, SystemColors.Highlight))) {
                    e.Graphics.FillRectangle(brush, ClientRectangle);
                }
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle, SystemColors.Highlight, ButtonBorderStyle.Solid);
            }

            var offset = IsMouseOver && !IsMouseDown ? 1 : 0;
            e.Graphics.DrawImageTranslucent(Image, .75f, imageX - offset, imageY - offset);
        }

        private void BilgeButton_MouseEnter(object sender, EventArgs e) {
            IsMouseOver = true;
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
