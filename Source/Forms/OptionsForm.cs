using ScriptFUSION.UpDown_Meter.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace ScriptFUSION.UpDown_Meter {
    public partial class OptionsForm : Form {
        internal Options Options { get; private set; }

        private NetworkInterface SelectedNic
        {
            get { return (NetworkInterface)nics.SelectedItems.Cast<ListViewItem>().FirstOrDefault()?.Tag; }
        }

        internal OptionsForm(Options options) {
            Options = options;

            InitializeComponent();
            LoadNetworkInterfaces();
            LoadSettings();

            // Load default page.
            networking.SimulateClick();
        }

        internal delegate void ApplyOptionsDelegate(OptionsForm sender, Options options);

        internal event ApplyOptionsDelegate ApplyOptions;

        private void SaveSettings() {
            if ((Options.NetworkInterface = SelectedNic) != null) {
                Options.NicSpeeds[SelectedNic.Id] = ulong.Parse(customSpeed.Text);
            }

            Options.Docking = dock.Checked;

            Options.Save();
        }

        private void LoadSettings() {
            dock.Checked = Options.Docking;
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
                            stats.BytesSent.ToString(),
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

            SelectCurrentNetworkInterface();
        }

        private void SelectCurrentNetworkInterface() {
            if (Options.NetworkInterface != null) {
                foreach (ListViewItem nic in nics.Items) {
                    if (((NetworkInterface)nic.Tag).Id == Options.NetworkInterface.Id) {
                        nic.Selected = true;
                        break;
                    }
                }
            }
        }

        #region Event handlers

        private void ok_Click(object sender, EventArgs e) {
            SaveSettings();

            Close();
        }

        private void cancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void apply_Click(object sender, EventArgs e) {
            SaveSettings();

            ApplyOptions?.Invoke(this, Options);
        }

        private void nics_SelectedIndexChanged(object sender, EventArgs e) {
            detectedSpeed.Text = (SelectedNic?.Speed / 8).ToString();
            customSpeed.Text = SelectedNic != null && Options.NicSpeeds.ContainsKey(SelectedNic.Id)
                ? Options.NicSpeeds[SelectedNic.Id].ToString()
                : detectedSpeed.Text;
        }

        private void showDisabledAdapters_CheckedChanged(object sender, EventArgs e) {
            LoadNetworkInterfaces();
        }

        private void copySpeed_Click(object sender, EventArgs e) {
            customSpeed.Text = detectedSpeed.Text;
        }

        private void pagingButton_Click(object sender, EventArgs e) {
            var clickedButton = sender as BilgeButton;
            var map = new Dictionary<BilgeButton, DockedPanel>() {
                { networking, networkingPage },
                { options, optionsPage },
            };

            foreach (var button in footer.Controls.Cast<Control>().OfType<BilgeButton>()) {
                button.Selected = false;
            }
            clickedButton.Selected = true;

            pager.SelectedPanel = map[clickedButton];
            title.Text = clickedButton.Text;
        }

        private void footer_Paint(object sender, PaintEventArgs e) {
            ControlPaint.DrawBorder3D(
                e.Graphics,
                new Rectangle(0, 0, Width, 2),
                Border3DStyle.SunkenOuter
            );
        }

        private void OptionsForm_Paint(object sender, PaintEventArgs e) {
            // Draw header border.
            ControlPaint.DrawBorder3D(e.Graphics, new Rectangle(0, header.Bottom + 1, Width, 2), Border3DStyle.SunkenOuter);
        }

        #endregion
    }
}
