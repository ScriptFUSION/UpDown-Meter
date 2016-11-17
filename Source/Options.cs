using ScriptFUSION.UpDown_Meter.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;

namespace ScriptFUSION.UpDown_Meter {
    internal sealed class Options {
        private Settings settings;

        public Options(Settings settings) {
            this.settings = settings;

            NetworkInterface = NetworkInterfaces.Fetch(settings.LastNic);
            NicSpeeds = settings.NicSpeeds;
            Topmost = settings.Topmost;
            Transparent = settings.Transparent;
            Bounds = settings.Bounds;
        }

        public NetworkInterface NetworkInterface { get; set; }

        public Dictionary<string, ulong> NicSpeeds { get; private set; }

        public Rectangle Bounds { get; set; }

        public bool Topmost { get; set; }

        public bool Transparent { get; set; }

        public Options Clone() {
            var clone = (Options)MemberwiseClone();
            clone.NicSpeeds = new Dictionary<string, ulong>(NicSpeeds);

            return clone;
        }

        public void Save() {
            settings.LastNic = NetworkInterface?.Id;
            settings.NicSpeeds = NicSpeeds;
            settings.Topmost = Topmost;
            settings.Transparent = Transparent;
            settings.Bounds = Bounds;

            settings.Save();
        }
    }
}
