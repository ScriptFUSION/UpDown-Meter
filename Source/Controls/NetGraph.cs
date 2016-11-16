using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace ScriptFUSION.UpDown_Meter {
    public partial class NetGraph : Control {
        private const float HEADROOM = .1f;

        private NetworkInterfaceSampler sampler;

        private Dictionary<Sample, ulong> sampleIndexes;
        private ulong sampleCount;

        private Pen applePen, pineapplePen, ppapPen, headroomPen, periodPen, lightPeriodPen;

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

        private void Sampler_SampleAdded(NetworkInterfaceSampler sampler, Sample sample) {
            sampleIndexes.Add(sample, sampleCount++);

            Invalidate();
        }

        private void Sampler_SamplesCleared(NetworkInterfaceSampler sampler) {
            Reset();
        }

        protected override void OnPaint(PaintEventArgs e) {
            // Avoid division by zero.
            if (sampler?.MaximumSpeed > 0) {
                // Use entire graph area regardless of clipping region.
                Rectangle surface = GraphRectangle;

                // Drawing start point on x-axis.
                var x = surface.Right - 1;

                foreach (var sample in sampler.GetSamples()) {
                    var downstream = sample.Downstream / (float)sampler.MaximumSpeed;
                    var upstream = sample.Upstream / (float)sampler.MaximumSpeed;
                    var downDominant = downstream > upstream;
                    var hybridHeight = surface.Height * (1 - (downDominant ? upstream : downstream) * (1 - HEADROOM)) + surface.Top;
                    var dominantHeight = surface.Height * (1 - (downDominant ? downstream : upstream) * (1 - HEADROOM)) + surface.Top;

                    // Draw hybrid bar.
                    e.Graphics.DrawLine(ppapPen, x, hybridHeight, x, surface.Bottom);

                    // Draw upload/download bar.
                    e.Graphics.DrawLine(downDominant ? applePen : pineapplePen, x, dominantHeight, x, hybridHeight);

                    // Draw period separator.
                    if (sampleIndexes[sample] % 30 == 0) {
                        for (var i = surface.Top; i < surface.Bottom; i += 4) {
                            e.Graphics.DrawLine((i - surface.Top) % 8 == 0 ? periodPen : lightPeriodPen, x, i, x, i + 3);
                        }
                    }

                    // Do not draw more samples than surface width permits.
                    if (--x < surface.Left) break;
                }

                // Draw headroom bar.
                var headroomY = surface.Height * HEADROOM;
                e.Graphics.DrawLine(headroomPen, x + 1, headroomY, surface.Right, headroomY);
            }

            // Paint entire border regardless of clipping region.
            ControlPaint.DrawBorder3D(e.Graphics, ClientRectangle, Border3DStyle.SunkenOuter);
        }

        protected override void OnPaintBackground(PaintEventArgs e) {
            // Use entire client area regardless of clipping region.
            Rectangle surface = ClientRectangle;

            using (var backgroud = new LinearGradientBrush(surface, SystemColors.ControlLightLight, SystemColors.Control, 90)) {
                e.Graphics.FillRectangle(backgroud, surface);
            }
        }
    }
}
