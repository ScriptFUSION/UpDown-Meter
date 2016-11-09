using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.NetworkInformation;

namespace ScriptFUSION.UpDown_Meter {
    public partial class OptionsForm : Form {
        private Point? headerBorderP1, headerBorderP2, headerBorderP3, headerBorderP4;

        internal Options Options { get; private set; }

        public OptionsForm() {
            InitializeComponent();

            LoadAdapaters();
        }

        internal OptionsForm(Options options) : this() {
            Options = options;
        }

        private void nics_SelectedIndexChanged(object sender, EventArgs e) {
            Options.NetworkInterface = (NetworkInterface)nics.SelectedItems.Cast<ListViewItem>().FirstOrDefault()?.Tag;
        }

        private void ok_Click(object sender, EventArgs e) {
            Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            Close();
        }

        private void LoadAdapaters() {
            IEnumerable<NetworkInterface> interfaces = NetworkInterface.GetAllNetworkInterfaces();

            if (!showDisabledAdapters.Checked) {
                interfaces = interfaces.Where(nic => nic.OperationalStatus == OperationalStatus.Up);
            }

            nics.Items.Clear();
            nics.Items.AddRange(
                interfaces.Select(
                    nic => {
                        var stats = nic.GetIPStatistics();

                        var item = new ListViewItem(new[] {
                            nic.Description,
                            nic.NetworkInterfaceType.ToString(),
                            nic.Speed.ToString(),
                            stats.BytesReceived.ToString(),
                            stats.BytesSent.ToString()
                        });
                        item.Tag = nic;

                        if (nic.OperationalStatus != OperationalStatus.Up) {
                            item.ForeColor = SystemColors.GrayText;
                        }

                        return item;
                    }
                )
                .ToArray()
            );

            // HeaderSize includes column content but ColumnContent excludes header size.
            nics.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void showDisabledAdapters_CheckedChanged(object sender, EventArgs e) {
            LoadAdapaters();
        }

        private void OptionsForm_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawLine(
                SystemPens.ButtonShadow,
                (headerBorderP1 = headerBorderP1 ?? new Point(0, header.Bounds.Bottom + 1)).Value,
                (headerBorderP2 = headerBorderP2 ?? new Point(header.Bounds.Right, headerBorderP1.Value.Y)).Value
            );
            e.Graphics.DrawLine(
                SystemPens.ButtonHighlight,
                (headerBorderP3 = headerBorderP3 ?? new Point(0, headerBorderP1.Value.Y + 1)).Value,
                (headerBorderP4 = headerBorderP4 ?? new Point(headerBorderP2.Value.X, headerBorderP3.Value.Y)).Value
            );
        }
    }
}
