using ScriptFUSION.UpDown_Meter.Properties;
using System;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
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

        /// <summary>
        /// Application options.
        /// </summary>
        private Options Options
        {
            get { return options; }
            set { SyncOptionsWithSampler(options = value); }
        }

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

        private void SyncOptionsWithSampler(Options options) {
            var nic = sampler.NetworkInterface = options.NetworkInterface;

            if (nic != null) {
                if (options.NicSpeeds.ContainsKey(nic.Id)) {
                    sampler.MaximumSpeed = options.NicSpeeds[nic.Id];
                }
            }
        }

        private void UpdateStats() {
            var lastSample = sampler.GetSamples().First();
            dlRaw.Text = lastSample.Downstream.ToString();
            ulRaw.Text = lastSample.Upstream.ToString();

            var sampleSet = sampler.GetSamples().Take(10);
            dlAvg.Text = ((long)sampleSet.Average(sample => sample.Downstream)).ToString();
            ulAvg.Text = ((long)sampleSet.Average(sample => sample.Upstream)).ToString();
        }

        private void UpdateTrayIcon() {
            var oldIcon = trayIcon.Icon;

            var lastSample = sampler.GetSamples().First();
            trayIcon.Icon = trayIconIllustrator.DrawIcon(
                lastSample.Upstream / (float)sampler.MaximumSpeed,
                lastSample.Downstream / (float)sampler.MaximumSpeed
            );

            // Dispose of old icon.
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
            UpdateTrayIcon();
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
