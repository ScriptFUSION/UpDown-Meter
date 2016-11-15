using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ScriptFUSION.UpDown_Meter {
    internal class TrayIconIllustrator {
        private Bitmap frame, upBar, downBar;

        public TrayIconIllustrator() {
            frame = new Bitmap(16, 16, PixelFormat.Format24bppRgb);
            upBar = new Bitmap(14, 6, frame.PixelFormat);
            downBar = (Bitmap)upBar.Clone();

            DrawFrame(frame);
            DrawBar(upBar, Color.FromArgb(0, 200, 0), Color.FromArgb(0, 70, 0));
            DrawBar(downBar, Color.FromArgb(220, 0, 0), Color.FromArgb(70, 0, 0));
        }

        private static void DrawFrame(Image framework) {
            var rect = new Rectangle(Point.Empty, framework.Size);

            using (var g = Graphics.FromImage(framework)) {
                // Border.
                ControlPaint.DrawBorder(g, rect, Color.Gray, ButtonBorderStyle.Solid);
                g.DrawRectangle(Pens.Black, rect);

                // Background.
                rect.Inflate(-1, -1);
                using (var brush = new SolidBrush(Color.FromArgb(80, 80, 80))) {
                    g.FillRectangle(brush, rect);
                }

                // Central bar.
                g.DrawLine(Pens.Black, 1, 8, 14, 8);
                g.DrawLine(Pens.Gray, 1, 7, 14, 7);
            }
        }

        private static void DrawBar(Image bar, Color primary, Color secondary) {
            using (var g = Graphics.FromImage(bar)) {
                var rect = new Rectangle(Point.Empty, bar.Size);

                using (var brush = new SolidBrush(primary)) {
                    g.FillRectangle(brush, rect);
                }

                using (var pen = new Pen(secondary)) {
                    for (var x = 2; x < bar.Width; x += 3) {
                        g.DrawLine(pen, x, 0, x, bar.Height);
                    }
                }
            }
        }

        private Bitmap CompositeMeters(float up, float down) {
            var bitmap = (Bitmap)frame.Clone();

            using (var g = Graphics.FromImage(bitmap)) {
                g.DrawImageUnscaledAndClipped(
                    upBar, new Rectangle(1, 1, Math.Min(upBar.Width, (int)Math.Round(upBar.Width * up)), upBar.Height)
                );
                g.DrawImageUnscaledAndClipped(
                    downBar, new Rectangle(1, 9, Math.Min(downBar.Width, (int)Math.Round(downBar.Width * down)), downBar.Height)
                );
            }

            return bitmap;
        }

        private static byte[] BitmapToBytes(Bitmap bitmap) {
            var bitmapData = bitmap.LockBits(new Rectangle(Point.Empty, bitmap.Size), ImageLockMode.ReadOnly, bitmap.PixelFormat);
            var colourData = new byte[bitmapData.Stride * bitmap.Height];

            System.Runtime.InteropServices.Marshal.Copy(bitmapData.Scan0, colourData, 0, colourData.Length);
            bitmap.UnlockBits(bitmapData);

            return colourData;
        }

        /// <summary>
        /// Converts a bitmap to an icon using a crude encoder suitable only for 24-bit images.
        /// </summary>
        private static Icon BitmapToIcon(Bitmap bitmap) {
            System.Diagnostics.Debug.Assert(bitmap.PixelFormat == PixelFormat.Format24bppRgb);

            // Empirically, icon DIBs must be bottom-up because top-down DIBs do not draw correctly.
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

            var xorBytes = BitmapToBytes(bitmap);
            var andBytes = new byte[((bitmap.Width + 31 & ~31) >> 3) * bitmap.Height];
            var bitmapSize = xorBytes.Length + andBytes.Length;

            // See https://msdn.microsoft.com/en-us/library/windows/desktop/dd318229(v=vs.85).aspx.
            byte[] ICONIMAGE = {
                40, 0, 0, 0, // Size of structure.
                (byte)bitmap.Width, 0, 0, 0,
                (byte)(bitmap.Height * 2), 0, 0, 0,
                1, 0, // Planes.
                24, 0, // Bits per pixel.
                0, 0, 0, 0, // Compression type.
                (byte)(bitmapSize % 256), (byte)(bitmapSize / 256), 0, 0, // Image size.
                0, 0, 0, 0, // Horizontal pixels per meter.
                0, 0, 0, 0, // Vertical pixels per meter.
                0, 0, 0, 0, // Number of colours used.
                0, 0, 0, 0, // Number of important colours.
            };

            var iconSize = bitmapSize + ICONIMAGE.Length;

            // See https://msdn.microsoft.com/en-us/library/ms997538.aspx.
            byte[] ICONDIRENTRY = {
                (byte)bitmap.Width,
                (byte)bitmap.Height,
                0, // Number of colours.
                0, // Reserved.
                1, 0, // Colour planes.
                24, 0, // Bits per pixel.
                (byte)(iconSize % 256), (byte)(iconSize / 256), 0, 0, // Image size.
                22, 0, 0, 0, // Image offset.
            };

            byte[] ICONDIR = {
                0, 0, // Reserved.
                1, 0, // Type (icon).
                1, 0, // Number of images.
            };

            using (var ms = new MemoryStream(
                new byte[ICONDIR.Length + ICONDIRENTRY.Length + ICONIMAGE.Length + xorBytes.Length + andBytes.Length]
            )) {
                ms.Write(ICONDIR, 0, ICONDIR.Length);
                ms.Write(ICONDIRENTRY, 0, ICONDIRENTRY.Length);
                ms.Write(ICONIMAGE, 0, ICONIMAGE.Length);
                ms.Write(xorBytes, 0, xorBytes.Length);
                ms.Write(andBytes, 0, andBytes.Length);

                ms.Position = 0;
                return new Icon(ms);
            }
        }

        public Icon DrawIcon(float up, float down) {
            using (var meter = CompositeMeters(up, down)) {
                return BitmapToIcon(meter);
            }
        }
    }
}
