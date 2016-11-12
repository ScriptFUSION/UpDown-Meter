using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace ScriptFUSION.UpDown_Meter {
    public partial class NetGraph : Control, INotifyPropertyChanged {
        private const float HEADROOM = .1f;

        private long maximumSpeed, sampleCount;

        private Pen applePen, pineapplePen, ppapPen, periodPen, headroomPen, lightPeriodPen;

        private PropertyChangedEventHandler propertyChangedHandlers;

        /// <summary>
        /// List of relative samples.
        /// </summary>
        private Stack<Sample> Samples { get; set; }

        private Dictionary<Sample, long> sampleIndexes;

        public long MaximumSpeed
        {
            get { return maximumSpeed; }
            set
            {
                maximumSpeed = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the rectangle that represents the graph area of the control.
        /// </summary>
        public Rectangle GraphRectangle
        {
            get
            {
                var rectangle = ClientRectangle;
                rectangle.Inflate(-1, -1);

                return rectangle;
            }
        }

        public NetGraph() {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            Reset();
            CreatePens();
        }

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add { propertyChangedHandlers += value; }
            remove { propertyChangedHandlers -= value; }
        }

        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string property = null) {
            propertyChangedHandlers?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public void Reset() {
            Samples = new Stack<Sample>(Samples?.Count ?? Width);
            sampleIndexes = new Dictionary<Sample, long>();
        }

        private void CreatePens() {
            const int opacity = 192; // 75%.

            applePen = new Pen(Color.FromArgb(opacity, 255, 76, 76));
            pineapplePen = new Pen(Color.FromArgb(opacity, 0, 255, 0).Desaturate(.4f));
            ppapPen = new Pen(Color.FromArgb(opacity, 255, 255, 0).Desaturate(.3f));

            headroomPen = new Pen(Color.FromArgb(40, 0, 0, 0));
            periodPen = new Pen(Color.FromArgb(60, 0, 0, 0));
            lightPeriodPen = new Pen(Color.FromArgb(16, 0, 0, 0));
        }

        public void AddSample(Sample sample) {
            Samples.Push(sample);
            sampleIndexes.Add(sample, sampleCount++);

            // TODO: Crop old samples.

            // Automatic calibration.
            //if (sample.Max > MaximumSpeed) {
            //    MaximumSpeed = sample.Max;
            //}

            Invalidate();
        }

        public IEnumerable<Sample> GetSamples() {
            return Samples.ToArray<Sample>();
        }

        protected override void OnPaint(PaintEventArgs e) {
            // Use entire graph area regardless of clipping region.
            Rectangle surface = GraphRectangle;

            // Drawing start point on x-axis.
            var x = surface.Right - 1;

            // Avoid division by zero.
            if (MaximumSpeed > 0) {
                foreach (var sample in Samples) {
                    var downstream = sample.Downstream / (float)MaximumSpeed;
                    var upstream = sample.Upstream / (float)MaximumSpeed;
                    var downDominant = downstream > upstream;
                    var hybridHeight = surface.Height * (1 - (downDominant ? upstream : downstream) * (1 - HEADROOM)) + surface.Top;
                    var dominantHeight = surface.Height * (1 - (downDominant ? downstream : upstream) * (1 - HEADROOM)) + surface.Top;

                    // Draw hybrid bar.
                    e.Graphics.DrawLine(ppapPen, x, hybridHeight, x, surface.Bottom);

                    // Draw upload/download bar.
                    e.Graphics.DrawLine(downDominant ? applePen : pineapplePen, x, dominantHeight, x, hybridHeight);

                    // Draw period separator.
                    if (sampleIndexes[sample] % 60 == 0) {
                        for (var i = surface.Top; i < surface.Bottom; i += 4) {
                            e.Graphics.DrawLine((i - surface.Top) % 8 == 0 ? periodPen : lightPeriodPen, x, i, x, i + 3);
                        }
                    }

                    // Do not draw more samples than surface width permits.
                    if (--x < surface.Left) break;
                }
            }

            // Draw headroom bar.
            var headroomY = surface.Height * HEADROOM;
            e.Graphics.DrawLine(headroomPen, x + 1, headroomY, surface.Right, headroomY);

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
