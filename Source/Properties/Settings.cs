using System.Collections.Generic;
using System.Configuration;

namespace ScriptFUSION.UpDown_Meter.Properties {
    internal sealed partial class Settings {
        [UserScopedSetting]
        [SettingsSerializeAs(SettingsSerializeAs.Binary)]
        public Dictionary<string, ulong> NicSpeeds
        {
            get
            {
                if (this["NicSpeeds"] == null) {
                    this["NicSpeeds"] = new Dictionary<string, ulong>();
                }

                return (Dictionary<string, ulong>)this["NicSpeeds"];
            }
            set { this["NicSpeeds"] = value; }
        }
    }
}
