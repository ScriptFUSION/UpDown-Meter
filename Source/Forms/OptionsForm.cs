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
        private RegistryPersister registry;

        internal OptionsForm(Options options) {
            Options = options;
            registry = new RegistryPersister(new RegistryOptions());

            InitializeComponent();
            LoadNetworkInterfaces();
            LoadSettings();

            // Load default page.
            networking.SimulateClick();
        }

        internal Options Options { get; private set; }

        private RegistryOptions RegistryOptions { get { return registry.Options; } }

        private NetworkInterface SelectedNic
        {
            get { return (NetworkInterface)nics.SelectedItems.Cast<ListViewItem>().FirstOrDefault()?.Tag; }
        }

        internal delegate void ApplyOptionsDelegate(OptionsForm sender, Options options);

        internal event ApplyOptionsDelegate ApplyOptions;

        private void SaveSettings() {
            if ((Options.NetworkInterface = SelectedNic) != null) {
                // TODO: Validate text before parsing.
                Options.NicSpeeds[SelectedNic.Id] = ulong.Parse(customSpeed.Text);
            }

            Options.Docking = docking.Checked;
            Options.LoadHidden = loadHidden.Checked;

            Options.Save();

            SaveRegistrySettings();
        }

        private void SaveRegistrySettings() {
            RegistryOptions.LoadAtSystemStartup = loadSystem.Checked;

            registry.Save();
        }

        private void LoadSettings() {
            docking.Checked = Options.Docking;
            loadHidden.Checked = Options.LoadHidden;

            LoadRegistrySettings();
        }

        private void LoadRegistrySettings() {
            registry.Load();

            loadSystem.Checked = RegistryOptions.LoadAtSystemStartup;
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

                        // Store NetworkInterface because querying NICs is an expensive operation.
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
            nics.Items.Cast<ListViewItem>()
                .Where(item => ((NetworkInterface)item.Tag).Id == Options.NetworkInterface?.Id)
                .ToList().ForEach(item => item.Selected = true);
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

            pages.SelectedPanel = map[clickedButton];
            title.Text = clickedButton.Text;
        }

        private void header_Paint(object sender, PaintEventArgs e) {
            ControlPaint.DrawBorder3D(e.Graphics, new Rectangle(0, header.Bottom - 2, Width, 2), Border3DStyle.SunkenOuter);
        }

        private void footer_Paint(object sender, PaintEventArgs e) {
            ControlPaint.DrawBorder3D(e.Graphics, new Rectangle(0, 0, Width, 2), Border3DStyle.SunkenOuter);
        }

        #endregion
    }
}
