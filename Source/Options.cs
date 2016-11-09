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
    }
}
