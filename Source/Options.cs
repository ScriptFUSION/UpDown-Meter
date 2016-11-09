using ScriptFUSION.UpDown_Meter.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ScriptFUSION.UpDown_Meter {
    sealed class Options {
        public NetworkInterface NetworkInterface { get; set; }

        public Options Clone() {
            return (Options)this.MemberwiseClone();
        }

        public static Options FromSettings(Settings settings) {
            return new Options {
                NetworkInterface = NetworkInterfaces.Fetch(settings.LastNic)
            };
        }
    }
}
