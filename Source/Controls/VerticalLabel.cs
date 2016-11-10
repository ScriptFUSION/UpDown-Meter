using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ScriptFUSION.UpDown_Meter.Controls {
    public class VerticalLabel : Label {
        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.TranslateTransform(0, Height);
            e.Graphics.RotateTransform(-90);

            using (var brush = new SolidBrush(ForeColor))
            using (var format = CreateStringFormat(TextAlign)) {
                e.Graphics.DrawString(Text, Font, brush, new Rectangle(0, 0, Height, Width), format);
            }
        }

        private StringFormat CreateStringFormat(ContentAlignment alignment) {
            var format = new StringFormat();

            switch (alignment) {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                    format.Alignment = StringAlignment.Near;
                    break;

                case ContentAlignment.TopCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.BottomCenter:
                    format.Alignment = StringAlignment.Center;
                    break;

                default:
                    format.Alignment = StringAlignment.Far;
                    break;
            }

            switch (alignment) {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                    format.LineAlignment = StringAlignment.Near;
                    break;

                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleRight:
                    format.LineAlignment = StringAlignment.Center;
                    break;

                default:
                    format.LineAlignment = StringAlignment.Far;
                    break;
            }

            return format;
        }
    }
}
