using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;

namespace ScriptFUSION.UpDown_Meter {
    public class NetworkInterfaceSampler : INotifyPropertyChanged {
        private NetworkInterface nic;
        private ulong maximumSpeed;

        private PropertyChangedEventHandler propertyChangedHandlers;

        public NetworkInterfaceSampler() {
            Reset();
        }

        public delegate void SampleAddedDelegate(NetworkInterfaceSampler sampler, Sample sample);

        public delegate void SamplesClearedDelegate(NetworkInterfaceSampler sampler);

        public event SampleAddedDelegate SampleAdded;

        public event SamplesClearedDelegate SamplesCleared;

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add { propertyChangedHandlers += value; }
            remove { propertyChangedHandlers -= value; }
        }

        /// <summary>
        /// Stack of relative samples from the current NetworkInterface.
        /// </summary>
        private Stack<Sample> Samples { get; set; }

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
        public ulong MaximumSpeed
        {
            get { return maximumSpeed; }
            set
            {
                maximumSpeed = value;
                RaisePropertyChanged();
            }
        }

        public void Reset() {
            Samples = new Stack<Sample>(Samples?.Count ?? 0x100);
            LastSample = null;

            RaiseSamplesCleared();
        }

        public void SampleAdapter() {
            var sample = CreateRelativeSample();
            Samples.Push(sample);

            // TODO: Crop old samples.

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

        public IEnumerable<Sample> GetSamples() {
            return Samples.ToArray<Sample>();
        }

        private void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string property = null) {
            propertyChangedHandlers?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private void RaiseSampleAdded(Sample sample) {
            SampleAdded?.Invoke(this, sample);
        }

        public void RaiseSamplesCleared() {
            SamplesCleared?.Invoke(this);
        }
    }
}
