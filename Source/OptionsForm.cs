using ScriptFUSION.UpDown_Meter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptFUSION.UpDown_Meter {
    public partial class OptionsForm : Form {
        internal Options Options { get; private set; }

        internal OptionsForm(Options options) {
            Options = options;

            InitializeComponent();
            LoadNetworkInterfaces();
        }

        private void SaveSettings() {
            Options.Save(Settings.Default);
        }

        private void LoadNetworkInterfaces() {
            var interfaces = showDisabledAdapters.Checked ? NetworkInterfaces.FetchAll() : NetworkInterfaces.FetchOperational();

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

            SyncSelectedNetworkInterface();
        }

        private void SyncSelectedNetworkInterface() {
            foreach (ListViewItem nic in nics.Items) {
                if (((NetworkInterface)nic.Tag).Id == Options.NetworkInterface?.Id) {
                    nic.Selected = true;
                    break;
                }
            }
        }

        #region Event handlers

        private void ok_Click(object sender, EventArgs e) {
            Close();

            SaveSettings();
        }

        private void cancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void nics_SelectedIndexChanged(object sender, EventArgs e) {
            Options.NetworkInterface = (NetworkInterface)nics.SelectedItems.Cast<ListViewItem>().FirstOrDefault()?.Tag;
        }

        private void showDisabledAdapters_CheckedChanged(object sender, EventArgs e) {
            LoadNetworkInterfaces();
        }

        private void OptionsForm_Paint(object sender, PaintEventArgs e) {
            ControlPaint.DrawBorder3D(e.Graphics, new Rectangle(0, header.Bounds.Bottom + 1, Width, 2), Border3DStyle.SunkenOuter);
        }

        #endregion
    }
}
