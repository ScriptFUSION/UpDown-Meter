﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace ScriptFUSION.UpDown_Meter {
    public partial class NetGraph : Control, INotifyPropertyChanged {
        private long maximumSpeed;

        private Pen applePen, pineapplePen, ppapPen;

        private PropertyChangedEventHandler propertyChangedHandlers;

        /// <summary>
        /// List of relative samples.
        /// </summary>
        private Stack<Sample> Samples { get; set; }

        public long MaximumSpeed
        {
            get { return maximumSpeed; }
            set
            {
                maximumSpeed = value;
                OnPropertyChanged();
            }
        }

        public NetGraph() {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            Samples = new Stack<Sample>();

            CreatePens();
        }

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add { propertyChangedHandlers += value; }
            remove { propertyChangedHandlers -= value; }
        }

        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string property = null) {
            if (propertyChangedHandlers != null) {
                propertyChangedHandlers(this, new PropertyChangedEventArgs(property));
            }
        }

        private void CreatePens() {
            const int opacity = 192; // 75%.

            applePen = new Pen(Color.FromArgb(opacity, 255, 76, 76));
            pineapplePen = new Pen(Color.FromArgb(opacity, 0, 255, 0).Desaturate(.4f));
            ppapPen = new Pen(Color.FromArgb(opacity, 255, 255, 0).Desaturate(.3f));
        }

        public void AddSample(Sample sample) {
            Samples.Push(sample);

            // Automatic calibration.
            //if (sample.Max > MaximumSpeed) {
            //    MaximumSpeed = sample.Max;
            //}

            Invalidate();
        }

        public IEnumerable<Sample> GetSamples() {
            return Samples.ToArray<Sample>();
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

        protected override void OnPaint(PaintEventArgs e) {
            // Avoid division by zero.
            if (MaximumSpeed > 0) {
                // Use entire graph area regardless of clipping region.
                Rectangle surface = GraphRectangle;
                var x = surface.Right - 1;

                foreach (var sample in Samples) {
                    var downstream = sample.Downstream / (float)MaximumSpeed;
                    var upstream = sample.Upstream / (float)MaximumSpeed;
                    var downDominant = downstream > upstream;
                    var hybridHeight = surface.Height * (1 - (downDominant ? upstream : downstream)) + surface.Top;
                    var dominantHeight = surface.Height * (1 - (downDominant ? downstream : upstream)) + surface.Top;

                    // Draw hybrid bar.
                    e.Graphics.DrawLine(ppapPen, x, hybridHeight, x, surface.Bottom);

                    // Draw upload/download bar.
                    e.Graphics.DrawLine(downDominant ? applePen : pineapplePen, x, dominantHeight, x, hybridHeight);

                    // Do not draw more samples than surface width permits.
                    if (--x < surface.Left) break;
                }
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