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
        /// Point at which the user starts dragging the form.
        /// </summary>
        private Point dragPoint;

        public NetGraphForm() {
            InitializeComponent();
            toolbox.BackColor = BackColor.Desaturate(.15f).Darken(.14f);

            samplerBindingSource.Add(sampler = netGraph.Sampler = new NetworkInterfaceSampler());
            sampler.SampleAdded += Sampler_SampleAdded;

            Options = Options.FromSettings(Settings.Default);

            trayIconIllustrator = new TrayIconIllustrator();
            trayIcon.Icon = Icon;

            // Timer does not fire at start-up so trigger manually.
            timer_Tick(null, null);
        }

        /// <summary>
        /// Application options.
        /// </summary>
        private Options Options
        {
            get { return options; }
            set { SyncOptionsWithSampler(options = value); }
        }

        private Sample LastSample
        {
            get { return sampler.GetSamples().First(); }
        }

        private IEnumerable<Sample> LatestSamples
        {
            get { return sampler.GetSamples().Take(10); }
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
            get { return LastSample.Max < 1000 && AverageDownloadSpeed < 1000 && AverageUploadSpeed < 1000; }
        }

        private void SyncOptionsWithSampler(Options options) {
            var nic = sampler.NetworkInterface = options.NetworkInterface;

            if (nic != null) {
                if (options.NicSpeeds.ContainsKey(nic.Id)) {
                    sampler.MaximumSpeed = options.NicSpeeds[nic.Id];
                }
            }
        }

        private void UpdateStats() {
            dlRaw.Text = LastSample.Downstream.ToString();
            ulRaw.Text = LastSample.Upstream.ToString();

            dlAvg.Text = AverageDownloadSpeed.ToString();
            ulAvg.Text = AverageUploadSpeed.ToString();
        }

        private void UpdateTray() {
            UpdateTrayIcon();

            trayIcon.Text = string.Format(
                "D: {0} KB/s U: {1} KB/s",
                Math.Round(LastSample.Downstream / 1000f, 1),
                Math.Round(LastSample.Upstream / 1000f, 1)
            );
        }

        private void UpdateTrayIcon() {
            var oldIcon = trayIcon.Icon;

            if (IsConnectionDormant) {
                // Use application icon.
                trayIcon.Icon = Icon;
            }
            else {
                // Draw new icon.
                trayIcon.Icon = trayIconIllustrator.DrawIcon(
                    LastSample.Upstream / (float)sampler.MaximumSpeed,
                    LastSample.Downstream / (float)sampler.MaximumSpeed
                );
            }

            // Dispose of old icon unless it's the application icon.
            if (oldIcon != null && oldIcon != Icon) {
                oldIcon.Dispose();
            }
        }

        #region Event handlers

        private void Sampler_SampleAdded(NetworkInterfaceSampler sampler, Sample sample) {
            UpdateStats();
        }

        private void timer_Tick(object sender, EventArgs e) {
            sampler.SampleAdapter();
            UpdateTray();
        }

        private void close_Click(object sender, EventArgs e) {
            Close();
        }

        private void minimize_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }

        private void topmost_Click(object sender, EventArgs e) {
            TopMost = topmost.Selected;
        }

        private void transparent_Click(object sender, EventArgs e) {
            Opacity = transparent.Selected ? .4 : 1;
        }

        private void reset_Click(object sender, EventArgs e) {
            sampler.Reset();
        }

        private void settings_Click(object sender, EventArgs e) {
            using (var optionsForm = new OptionsForm(Options.Clone())) {
                optionsForm.Icon = Icon;

                if (optionsForm.ShowDialog(this) == DialogResult.OK) {
                    Options = optionsForm.Options;
                }
            }
        }

        private void trayIcon_Click(object sender, EventArgs e) {
            WindowState = WindowState == FormWindowState.Normal ? FormWindowState.Minimized : FormWindowState.Normal;
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
                Location = new Point(Location.X + e.X - dragPoint.X, Location.Y + e.Y - dragPoint.Y);
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
        }

        #endregion
    }
}
