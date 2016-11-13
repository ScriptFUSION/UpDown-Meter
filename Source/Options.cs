using ScriptFUSION.UpDown_Meter.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace ScriptFUSION.UpDown_Meter {
    internal sealed class Options {
        public NetworkInterface NetworkInterface { get; set; }

        public Dictionary<string, ulong> NicSpeeds { get; private set; }

        public Options Clone() {
            var clone = (Options)this.MemberwiseClone();
            clone.NicSpeeds = new Dictionary<string, ulong>(NicSpeeds);

            return clone;
        }

        public static Options FromSettings(Settings settings) {
            return new Options {
                NetworkInterface = NetworkInterfaces.Fetch(settings.LastNic),
                NicSpeeds = settings.NicSpeeds,
            };
        }

        public void Save(Settings settings) {
            settings.LastNic = NetworkInterface?.Id;
            settings.NicSpeeds = NicSpeeds;
            settings.Save();
        }
    }
}
