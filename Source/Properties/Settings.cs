using System.Collections.Generic;
using System.Configuration;

namespace ScriptFUSION.UpDown_Meter.Properties {
    internal sealed partial class Settings {
        [UserScopedSetting]
        [SettingsSerializeAs(SettingsSerializeAs.Binary)]
        public Dictionary<string, long> NicSpeeds
        {
            get
            {
                if (this["NicSpeeds"] == null) {
                    this["NicSpeeds"] = new Dictionary<string, long>();
                }

                return (Dictionary<string, long>)this["NicSpeeds"];
            }
            set { this["NicSpeeds"] = value; }
        }
    }
}
