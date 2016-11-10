using ScriptFUSION.UpDown_Meter.Properties;
using System;
using System.Linq;
using System.Net.NetworkInformation;

namespace ScriptFUSION.UpDown_Meter {
    internal sealed class Options {
        public NetworkInterface NetworkInterface { get; set; }

        public Options Clone() {
            return (Options)this.MemberwiseClone();
        }

        public static Options FromSettings(Settings settings) {
            return new Options {
                NetworkInterface = NetworkInterfaces.Fetch(settings.LastNic)
            };
        }

        public void Save(Settings settings) {
            settings.LastNic = NetworkInterface?.Id;
            settings.Save();
        }
    }
}
