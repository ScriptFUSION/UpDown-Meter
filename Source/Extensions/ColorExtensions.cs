using System;
using System.Drawing;
using System.Linq;

namespace ScriptFUSION.UpDown_Meter {
    public static class ColorExtensions {
        public static Color Desaturate(this Color colour, float percentage) {
            var averageBrightness = Math.Round((colour.R + colour.G + colour.B) / 3f);

            return Color.FromArgb(
                colour.A,
                (int)Math.Round(colour.R + (averageBrightness - colour.R) * percentage),
                (int)Math.Round(colour.G + (averageBrightness - colour.G) * percentage),
                (int)Math.Round(colour.B + (averageBrightness - colour.B) * percentage)
            );
        }

        public static Color Darken(this Color colour, float percentage) {
            var amount = byte.MaxValue * percentage;

            return Color.FromArgb(
                colour.A,
                Math.Max(0, (int)Math.Round(colour.R - amount)),
                Math.Max(0, (int)Math.Round(colour.G - amount)),
                Math.Max(0, (int)Math.Round(colour.B - amount))
            );
        }
    }
}
