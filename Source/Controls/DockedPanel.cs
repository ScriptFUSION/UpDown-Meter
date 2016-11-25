using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ScriptFUSION.UpDown_Meter.Controls {
    [Docking(DockingBehavior.Never)]
    public class DockedPanel : Panel {
        protected override void OnParentChanged(EventArgs e) {
            base.OnParentChanged(e);

            Dock = DockStyle.Fill;
        }

        [Browsable(false)]
        [DefaultValue(DockStyle.Fill)]
        public override DockStyle Dock
        {
            get { return base.Dock; }
            set { base.Dock = value; }
        }
    }
}
