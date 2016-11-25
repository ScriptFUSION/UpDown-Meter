using System;
using System.Linq;
using System.Windows.Forms;

namespace ScriptFUSION.UpDown_Meter.Controls {
    public partial class PanelStack : Control {
        private DockedPanel[] panels;

        private DockedPanel selectedPanel;

        public PanelStack() {
            InitializeComponent();
        }

        public DockedPanel[] Panels
        {
            get { return panels; }
            set
            {
                panels = value;

                foreach (var panel in value) {
                    Controls.Add(panel);
                }

                SelectedPanel = value.FirstOrDefault();
            }
        }

        public DockedPanel SelectedPanel
        {
            get { return selectedPanel; }
            set
            {
                foreach (var panel in Panels) {
                    panel.Visible = panel == value;
                }

                selectedPanel = value;
            }
        }
    }
}
