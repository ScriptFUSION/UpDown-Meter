using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace ScriptFUSION.UpDown_Meter.Controls {
    public partial class NetGraph : Control {
        private const float HEADROOM = .1f;

        private NetworkInterfaceSampler sampler;

        private Dictionary<Sample, ulong> sampleIndexes;
        private ulong sampleCount;

        private Pen applePen, pineapplePen, ppapPen, headroomPen, periodPen, lightPeriodPen;

        private const int WARNING_MAX_OPACITY = 192;
        private byte warningOpacity = WARNING_MAX_OPACITY;

        private DateTime pulseStart;

        public NetGraph() {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            CreatePens();
        }

        /// <summary>
        /// Gets the rectangle that represents the graph area of the control.
        /// </summary>
        private Rectangle GraphRectangle
        {
            get
            {
                var rectangle = ClientRectangle;
                rectangle.Inflate(-1, -1);

                return rectangle;
            }
        }

        public NetworkInterfaceSampler Sampler
        {
            set
            {
                sampler = value;

                value.SampleAdded += Sampler_SampleAdded;
                value.SamplesCleared += Sampler_SamplesCleared;

                Reset();
            }
        }

        private void CreatePens() {
            const int OPACITY = 192; // 75%.

            applePen = new Pen(Color.FromArgb(OPACITY, 255, 76, 76));
            pineapplePen = new Pen(Color.FromArgb(OPACITY, 0, 255, 0).Desaturate(.4f));
            ppapPen = new Pen(Color.FromArgb(OPACITY, 255, 255, 0).Desaturate(.3f));

            headroomPen = new Pen(Color.FromArgb(40, 0, 0, 0));

            periodPen = new Pen(Color.FromArgb(60, 0, 0, 0));
            lightPeriodPen = new Pen(Color.FromArgb(16, 0, 0, 0));
        }

        public void Reset() {
            sampleIndexes = new Dictionary<Sample, ulong>();
            sampleCount = 0;

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e) {
            // Avoid division by zero.
            if (sampler?.MaximumSpeed > 0) {
                StopPulse();

                // Use entire graph area regardless of clipping region.
                PaintGraph(e.Graphics, GraphRectangle);
            }
            else {
                StartPulse();

                PaintWarning(e.Graphics, ClientRectangle, "Please choose an adapter");
            }

            // Paint entire border regardless of clipping region.
            ControlPaint.DrawBorder3D(e.Graphics, ClientRectangle, Border3DStyle.SunkenOuter);
        }

        private void PaintGraph(Graphics g, Rectangle surface) {
            // Drawing start point on x-axis.
            var x = surface.Right - 1;

            foreach (var sample in sampler) {
                var downstream = sample.Downstream / (float)sampler.MaximumSpeed;
                var upstream = sample.Upstream / (float)sampler.MaximumSpeed;
                var downDominant = downstream > upstream;
                var hybridHeight = surface.Height * (1 - (downDominant ? upstream : downstream) * (1 - HEADROOM)) + surface.Top;
                var dominantHeight = surface.Height * (1 - (downDominant ? downstream : upstream) * (1 - HEADROOM)) + surface.Top;

                // Draw hybrid bar.
                g.DrawLine(ppapPen, x, hybridHeight, x, surface.Bottom);

                // Draw upload/download bar.
                g.DrawLine(downDominant ? applePen : pineapplePen, x, dominantHeight, x, hybridHeight);

                // Draw period separator.
                if (sampleIndexes[sample] % 30 == 0) {
                    for (var i = surface.Top; i < surface.Bottom; i += 4) {
                        g.DrawLine((i - surface.Top) % 8 == 0 ? periodPen : lightPeriodPen, x, i, x, i + 3);
                    }
                }

                // Do not draw more samples than surface width permits.
                if (--x < surface.Left) break;
            }

            // Draw headroom bar.
            var headroomY = surface.Height * HEADROOM;
            g.DrawLine(headroomPen, x + 1, headroomY, surface.Right, headroomY);
        }

        private void PaintWarning(Graphics g, Rectangle surface, string warning) {
            const int MARGIN = 2;
            var indicatorSize = new SizeF(30, 30);
            var warningSize = g.MeasureString(warning, Font);
            var totalSize = new SizeF(indicatorSize.Width + MARGIN + warningSize.Width, indicatorSize.Height);

            g.SmoothingMode = SmoothingMode.HighQuality;

            // Draw indicator.
            using (var brush = new SolidBrush(Color.FromArgb(128, BackColor.Darken(.4f)))) {
                g.FillEllipse(brush, new RectangleF(
                    new PointF(
                        (float)Math.Round(surface.Width / 2 - totalSize.Width / 2),
                        (float)Math.Round(surface.Height / 2 - indicatorSize.Height / 2)
                    ),
                    indicatorSize
                ));
            }

            // Draw indicator text.
            using (var font = new Font("Segoe UI", 18, FontStyle.Bold)) {
                var fontSize = g.MeasureString("?", font);

                g.DrawString(
                    "?",
                    font,
                    SystemBrushes.Control,
                    (float)Math.Round(surface.Width / 2 - totalSize.Width / 2 + indicatorSize.Width / 2 - fontSize.Width / 2 + 1.5),
                    (float)Math.Round(surface.Height / 2 - fontSize.Height / 2)
                );
            }

            // Draw warning text.
            using (var brush = new SolidBrush(Color.FromArgb(warningOpacity, ForeColor))) {
                g.DrawString(
                    warning,
                    Font,
                    brush,
                    (float)Math.Round(surface.Width / 2 + indicatorSize.Width - totalSize.Width / 2 + MARGIN),
                    (float)Math.Round(surface.Height / 2 - warningSize.Height / 2 + .5)
                );
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e) {
            // Use entire client area regardless of clipping region.
            Rectangle surface = ClientRectangle;

            using (var backgroud = new LinearGradientBrush(surface, SystemColors.ControlLightLight, SystemColors.Control, 90)) {
                e.Graphics.FillRectangle(backgroud, surface);
            }
        }

        private void StartPulse() {
            // Already started.
            if (pulseStart != default(DateTime) || DesignMode) {
                return;
            }

            pulseStart = DateTime.Now;
            pulse.Enabled = true;
        }

        private void StopPulse() {
            pulse.Enabled = false;
            pulseStart = default(DateTime);
        }

        private double Ease(double t) {
            t = t < .5 ? t * 2 : 2 - 2 * t;

            return t * t * t;
        }

        #region Event handlers

        private void Sampler_SampleAdded(NetworkInterfaceSampler sampler, Sample sample) {
            sampleIndexes.Add(sample, sampleCount++);

            Invalidate();
        }

        private void Sampler_SamplesCleared(NetworkInterfaceSampler sampler) {
            Reset();
        }

        private void pulse_Tick(object sender, EventArgs e) {
            const float ANIMATION_DURATION = 1500;

            warningOpacity = (byte)(WARNING_MAX_OPACITY - (WARNING_MAX_OPACITY *
                Ease((DateTime.Now - pulseStart).TotalMilliseconds % ANIMATION_DURATION / ANIMATION_DURATION)
            ));

            Invalidate();
        }

        #endregion
    }
}
