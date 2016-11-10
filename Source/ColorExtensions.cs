using System;
using System.Drawing;
using System.Linq;

namespace ScriptFUSION.UpDown_Meter {
    public static class ColorExtensions {
        public static Color Desaturate(this Color colour, float percentage) {
            var averageBrightness = (colour.R + colour.G + colour.B) / 3;

            return Color.FromArgb(
                colour.A,
                (int)Math.Round(colour.R + (averageBrightness - colour.R) * percentage),
                (int)Math.Round(colour.G + (averageBrightness - colour.G) * percentage),
                (int)Math.Round(colour.B + (averageBrightness - colour.B) * percentage)
            );
        }
    }
}
