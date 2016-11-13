using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace ScriptFUSION.UpDown_Meter {
    public static class GraphicsExtensions {
        /// <summary>
        /// Draws an image using only the specified colour while preserving alpha information.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="image">Image to draw.</param>
        /// <param name="colour">Colour.</param>
        /// <param name="x">Upper-left horizontal coordinate to begin drawing image from.</param>
        /// <param name="y">Upper-left vertical coordinate to begin drawing image from.</param>
        public static void DrawImageMono(this Graphics graphics, Image image, Color colour, int x, int y) {
            using (var attributes = new ImageAttributes()) {
                var matrix = new ColorMatrix();

                // Scale everything to black.
                matrix.Matrix00 = matrix.Matrix11 = matrix.Matrix22 = 0;

                // Translate to fixed colour.
                matrix.Matrix40 = colour.R / (float)byte.MaxValue;
                matrix.Matrix41 = colour.G / (float)byte.MaxValue;
                matrix.Matrix42 = colour.B / (float)byte.MaxValue;

                // Apply affine transformation matrix.
                attributes.SetColorMatrix(matrix);

                DrawImageAttributes(graphics, image, x, y, attributes);
            }
        }

        /// <summary>
        /// Draws an image blended into the background by the specified alpha amount.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="image">Image to draw.</param>
        /// <param name="alpha">Transparency coefficient between 0 and 1 where 0 is transparent and 1 is opaque.</param>
        /// <param name="x">Upper-left horizontal coordinate to begin drawing image from.</param>
        /// <param name="y">Upper-left vertical coordinate to begin drawing image from.</param>
        public static void DrawImageTranslucent(this Graphics graphics, Image image, float alpha, int x, int y) {
            using (var attributes = new ImageAttributes()) {
                var matrix = new ColorMatrix();
                matrix.Matrix33 = alpha;
                attributes.SetColorMatrix(matrix);

                DrawImageAttributes(graphics, image, x, y, attributes);
            }
        }

        private static void DrawImageAttributes(Graphics graphics, Image image, int x, int y, ImageAttributes attributes) {
            graphics.DrawImage(
                image,
                new[] {
                        new Point(x, y),
                        new Point(x + image.Width, y),
                        new Point(x, y + image.Height),
                },
                new Rectangle(Point.Empty, image.Size),
                GraphicsUnit.Pixel,
                attributes
            );
        }
    }
}
