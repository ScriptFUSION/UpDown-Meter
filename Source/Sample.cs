using System;
using System.Linq;

namespace ScriptFUSION.UpDown_Meter {
    public struct Sample {
        public long Downstream { get; set; }

        public long Upstream { get; set; }

        public static Sample operator -(Sample a, Sample b) {
            return new Sample {
                Downstream = a.Downstream - b.Downstream,
                Upstream = a.Upstream - b.Upstream,
            };
        }

        public long Max
        {
            get
            {
                return Math.Max(Downstream, Upstream);
            }
        }
    }
}
