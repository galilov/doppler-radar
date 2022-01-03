using System;
using System.Threading;
using System.Numerics;

namespace SignalLibrary
{
    public class PhaseSignalProcessor : SignalProcessor
    {
        public const int SampleRate = 96000;
        public const double TransmitterFreq = 40000; // Hz
        public const int FourieBlockSize = SampleRate / 2;
        public const double FreqPerFourierBin = (double)SampleRate / FourieBlockSize;
        private int _temperature = 20;
        public bool ReflectedMode;

        public PhaseSignalProcessor() : base(SampleRate, 2, 0, 1, FourieBlockSize)
        {
        }

        public Action<double> OnDataAvalable { get; set; }

        public int Temperature
        {
            get => Interlocked.CompareExchange(ref _temperature, 0, 0);
            set => Interlocked.Exchange(ref _temperature, value);
        }

        protected override double GenerateSample(double time, long offset)
        {
            return Math.Sin(2 * Math.PI * time * TransmitterFreq);
        }

        protected override void ProcessAudioData(float[] collectedSoundData)
        {
            var transmittedBin = DFT(collectedSoundData, (int)(TransmitterFreq / FreqPerFourierBin), true);
            var receivedBin = DFT(collectedSoundData, (int)(TransmitterFreq / FreqPerFourierBin), false);
            var transmittedPhase = transmittedBin.Phase;
            var receivedPhase = receivedBin.Phase;
            var delta = transmittedPhase - receivedPhase;
            if (delta < 0)
            {
                delta = 2 * Math.PI + delta;
            }

            var waveLength = GetAirSoundSpeed(Interlocked.CompareExchange(ref _temperature, 0, 0)) / TransmitterFreq;
            var phaseOffsetMillimeters = waveLength * delta * 1000 / Math.PI / (ReflectedMode ? 4 : 2);

            OnDataAvalable(phaseOffsetMillimeters);
        }

        private static Complex DFT(float[] signalInterleaved, int k, bool even)
        {
            double re = 0, im = 0;
            var count = signalInterleaved.Length / 2;
            var offset = even ? 0 : 1;
            for (var n = 0; n < count; n++)
            {
                var s = signalInterleaved[n * 2 + offset];
                re += s * Math.Cos(2 * Math.PI * k * n / count);
                im += s * -Math.Sin(2 * Math.PI * k * n / count);
            }
            return new Complex(re, im);
        }

    }
}
