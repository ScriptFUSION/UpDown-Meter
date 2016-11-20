using Nito.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;

namespace ScriptFUSION.UpDown_Meter {
    public class NetworkInterfaceSampler : IEnumerable<Sample> {
        private NetworkInterface nic;

        public delegate void SampleAddedDelegate(NetworkInterfaceSampler sampler, Sample sample);

        public delegate void SamplesClearedDelegate(NetworkInterfaceSampler sampler);

        public event SampleAddedDelegate SampleAdded;

        public event SamplesClearedDelegate SamplesCleared;

        /// <summary>
        /// Collection of relative samples from the current NetworkInterface.
        /// </summary>
        private Deque<Sample> Samples { get; set; } = new Deque<Sample>(0x1000);

        /// <summary>
        /// Latest absolute sample from the current NetworkInterface.
        /// </summary>
        private Sample LastSample { get; set; }

        public NetworkInterface NetworkInterface
        {
            get { return nic; }
            set
            {
                // Only update NIC if changed.
                if (nic?.Id != value?.Id) {
                    nic = value;
                    Reset();
                }
            }
        }

        /// <summary>
        /// List of relative samples.
        /// </summary>
        public ulong MaximumSpeed { get; set; }

        public void Reset() {
            Samples.Clear();
            LastSample = null;

            RaiseSamplesCleared();
        }

        public void SampleAdapter() {
            // Remove oldest sample when at capacity.
            if (Samples.Count == Samples.Capacity) {
                Samples.RemoveFromBack();
            }

            // Add latest sample.
            var sample = CreateRelativeSample();
            Samples.AddToFront(sample);

            // TODO: Automatic calibration.

            RaiseSampleAdded(sample);
        }

        private Sample CreateRelativeSample() {
            if (nic != null) {
                var stats = nic.GetIPStatistics();
                var lastSample = LastSample;
                var currentSample = LastSample = CreateAbsoluteSample(stats);

                // Do not diff a zero-sample because the reading will be inaccurate and usually off the scale.
                // This only happens after LastSample has been reset to zero.
                if (lastSample?.Max > 0) {
                    return currentSample - lastSample;
                }
            }

            return new Sample(0, 0);
        }

        private Sample CreateAbsoluteSample(IPInterfaceStatistics stats) {
            return new Sample(stats.BytesReceived, stats.BytesSent);
        }

        private void RaiseSampleAdded(Sample sample) {
            SampleAdded?.Invoke(this, sample);
        }

        public void RaiseSamplesCleared() {
            SamplesCleared?.Invoke(this);
        }

        public IEnumerator<Sample> GetEnumerator() {
            return Samples.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return Samples.GetEnumerator();
        }
    }
}
