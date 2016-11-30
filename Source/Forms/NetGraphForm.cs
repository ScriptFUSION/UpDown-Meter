using ScriptFUSION.UpDown_Meter.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ScriptFUSION.UpDown_Meter {
    public partial class NetGraphForm : Form {
        private Options options;

        private NetworkInterfaceSampler sampler;

        private TrayIconIllustrator trayIconIllustrator;

        /// <summary>
        /// Icon displayed in the system tray when the connection is dormant.
        /// </summary>
        private static Icon dormantIcon;

        /// <summary>
        /// Point at which the user starts dragging the form.
        /// </summary>
        private Point dragPoint;

        public NetGraphForm() {
            InitializeComponent();

            toolbox.BackColor = BackColor.Desaturate(.15f).Darken(.14f);

            sampler = netGraph.Sampler = new NetworkInterfaceSampler();
            sampler.SampleAdded += Sampler_SampleAdded;

            Options = new Options(Settings.Default);
            ApplyLoadTimeOptions();

            trayIconIllustrator = new TrayIconIllustrator();
            UpdateTrayIcon();

            // Timer does not fire at start-up so trigger manually.
            timer_Tick(null, null);
        }

        /// <summary>
        /// Application options.
        /// </summary>
        private Options Options
        {
            get { return options; }
            set
            {
                options = value;

                SyncSamplerOptions(value);
                SyncUiOptions(value);
            }
        }

        private Sample LastSample
        {
            get { return sampler.FirstOrDefault(); }
        }

        private IEnumerable<Sample> LatestSamples
        {
            get { return sampler.Take(10); }
        }

        private ulong AverageDownloadSpeed
        {
            get { return (ulong)LatestSamples.Average(sample => sample.Downstream); }
        }

        private ulong AverageUploadSpeed
        {
            get { return (ulong)LatestSamples.Average(sample => sample.Upstream); }
        }

        private bool IsConnectionDormant
        {
            get { return LastSample == null || LastSample.Max < 1000 && AverageDownloadSpeed < 1000 && AverageUploadSpeed < 1000; }
        }

        private void ApplyLoadTimeOptions() {
            if (!Options.Bounds.Location.IsEmpty) {
                StartPosition = FormStartPosition.Manual;
                Location = Options.Bounds.Location;
            }

            if (!Options.LoadHidden) {
                Show();
            }
        }

        private void SyncSamplerOptions(Options options) {
            var nic = sampler.NetworkInterface = options.NetworkInterface;

            sampler.MaximumSpeed = options.NicSpeeds.ContainsKey(nic?.Id ?? string.Empty) ? options.NicSpeeds[nic.Id] : 0;

            nicSpeed.Text = Math.Round(sampler.MaximumSpeed / 1000f).ToString("0 kB/s");
        }

        private void SyncUiOptions(Options options) {
            if (options.Topmost && !topmost.Selected) topmost.SimulateClick();
            if (options.Transparent && !transparent.Selected) transparent.SimulateClick();
        }

        private void UpdateStats() {
            const string FORMAT = "F1";

            dlRaw.Text = Math.Round(LastSample.Downstream / 1000f, 1).ToString(FORMAT);
            ulRaw.Text = Math.Round(LastSample.Upstream / 1000f, 1).ToString(FORMAT);

            dlAvg.Text = Math.Round(AverageDownloadSpeed / 1000f, 1).ToString(FORMAT);
            ulAvg.Text = Math.Round(AverageUploadSpeed / 1000f, 1).ToString(FORMAT);
        }

        private void UpdateTray() {
            UpdateTrayIcon();

            trayIcon.Text = string.Format(
                "D: {0} kB/s U: {1} kB/s",
                Math.Round(LastSample.Downstream / 1000f, 1),
                Math.Round(LastSample.Upstream / 1000f, 1)
            );
        }

        private void UpdateTrayIcon() {
            var oldIcon = trayIcon.Icon;

            if (IsConnectionDormant || sampler.MaximumSpeed == 0) {
                // Use application icon.
                trayIcon.Icon = CreateDormantIcon();
            }
            else {
                // Draw new icon.
                trayIcon.Icon = trayIconIllustrator.DrawIcon(
                    LastSample.Upstream / (float)sampler.MaximumSpeed,
                    LastSample.Downstream / (float)sampler.MaximumSpeed
                );
            }

            if (oldIcon != dormantIcon) {
                oldIcon?.Dispose();
            }
        }

        /// <summary>
        /// Creates an icon to be displayed when the connection is dormant.
        /// </summary>
        /// <remarks>
        /// The system tray is unable to select the most appropriate icon size for itself so this method gives it the
        /// little extra help it needs to not completely suck.
        /// </remarks>
        private Icon CreateDormantIcon() {
            return dormantIcon = dormantIcon ?? new Icon(Icon, 16, 16);
        }

        private void ToggleWindowVisibility() {
            if (Visible = !Visible) {
                Activate();
            }
        }

        private bool CanSnap(int clientEdge, int containerEdge, int tension) {
            if (!Options.Docking) {
                return false;
            }

            const int DOCK_DISTANCE = 10;

            return Math.Abs(clientEdge - containerEdge) <= DOCK_DISTANCE && Math.Abs(tension) <= DOCK_DISTANCE;
        }

        #region Event handlers

        private void timer_Tick(object sender, EventArgs e) {
            sampler.SampleAdapter();
        }

        private void close_Click(object sender, EventArgs e) {
            Close();
        }

        private void minimize_Click(object sender, EventArgs e) {
            Hide();
        }

        private void topmost_Click(object sender, EventArgs e) {
            TopMost = topmost.Selected = topmostMenuItem.Checked = Options.Topmost =
                sender == topmost ? topmost.Selected : topmostMenuItem.Checked;

            Options.Save();
        }

        private void transparent_Click(object sender, EventArgs e) {
            Opacity = (transparent.Selected = transparencyMenuItem.Checked = Options.Transparent =
                sender == transparent ? transparent.Selected : transparencyMenuItem.Checked
            ) ? .4 : 1;

            Options.Save();
        }

        private void reset_Click(object sender, EventArgs e) {
            sampler.Reset();
        }

        private void settings_Click(object sender, EventArgs e) {
            using (var optionsForm = new OptionsForm(Options.Clone())) {
                optionsForm.Icon = Icon;
                optionsForm.ApplyOptions += (_, options) => {
                    Options = options.Clone();
                };

                if (optionsForm.ShowDialog(this) == DialogResult.OK) {
                    Options = optionsForm.Options;
                }
            }
        }

        private void trayIcon_MouseClick(object sender, MouseEventArgs e) {
            if ((e.Button & MouseButtons.Left) > 0) {
                ToggleWindowVisibility();
            }
        }

        private void showMenuItem_Click(object sender, EventArgs e) {
            ToggleWindowVisibility();
        }

        private void homePageMenuItem_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/ScriptFUSION/UpDown-Meter");
        }

        private void Sampler_SampleAdded(NetworkInterfaceSampler sampler, Sample sample) {
            UpdateStats();
            UpdateTray();
        }

        private void NetGraphForm_Resize(object sender, EventArgs e) {
            ShowInTaskbar = WindowState != FormWindowState.Minimized;
        }

        private void NetGraphForm_MouseDown(object sender, MouseEventArgs e) {
            // Record drag start location.
            if ((e.Button & MouseButtons.Left) > 0) {
                dragPoint = e.Location;
            }
        }

        private void NetGraphForm_MouseMove(object sender, MouseEventArgs e) {
            // Drag form.
            if ((e.Button & MouseButtons.Left) > 0) {
                var container = Screen.FromRectangle(Bounds).WorkingArea;
                var x = Location.X + e.X - dragPoint.X;
                var y = Location.Y + e.Y - dragPoint.Y;

                if (CanSnap(Left, container.Left, x - container.Left)) {
                    x = container.Left;
                }
                if (CanSnap(Top, container.Top, y - container.Top)) {
                    y = container.Top;
                }
                if (CanSnap(Right, container.Right, container.Right - (x + Width))) {
                    x = container.Right - Width;
                }
                if (CanSnap(Bottom, container.Bottom, container.Bottom - (y + Height))) {
                    y = container.Bottom - Height;
                }

                Location = new Point(x, y);
            }
        }

        private void NetGraphForm_Paint(object sender, PaintEventArgs e) {
            // Force bottom and right to be drawn before top and left, causing the latter to overlap the former at the corners.
            ControlPaint.DrawBorder3D(e.Graphics, ClientRectangle, Border3DStyle.RaisedInner, Border3DSide.Bottom | Border3DSide.Right);
            ControlPaint.DrawBorder3D(e.Graphics, ClientRectangle, Border3DStyle.RaisedInner, Border3DSide.Top | Border3DSide.Left);

            // Draw toolbox edge.
            var toolboxEdge = toolbox.Bounds;
            toolboxEdge.Offset(-toolbox.Width, 0);
            ControlPaint.DrawBorder3D(e.Graphics, toolboxEdge, Border3DStyle.RaisedInner, Border3DSide.Right);

            // Draw status bar border.
            var statusBarBounds = statusBar.Bounds;
            statusBarBounds.Inflate(1, 1);
            ControlPaint.DrawBorder(e.Graphics, statusBarBounds, SystemColors.ButtonShadow, ButtonBorderStyle.Solid);
        }

        private void NetGraphForm_FormClosed(object sender, FormClosedEventArgs e) {
            Options.Bounds = Bounds;

            Options.Save();
        }

        #endregion
    }
}
