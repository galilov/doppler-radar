using System;
using SignalLibrary;

namespace PulseRadar
{
    class PulseSignalProcessor : SignalProcessor
    {
        public const int SampleRate = 192000;
        public const int TransmitterFreq = 38400; // Hz
        public const int FourieBlockSize = 1 * SampleRate / TransmitterFreq;
        private const int _signalWindowBins = 2 * SampleRate / 340 / FourieBlockSize * FourieBlockSize;
        private readonly double[] _pulse = new double[FourieBlockSize];
        private readonly Goertzel _goertzelDirect = new Goertzel(SampleRate, FourieBlockSize, TransmitterFreq);
        private readonly Goertzel _goertzelReflected = new Goertzel(SampleRate, FourieBlockSize, TransmitterFreq);
        private int _nCurrentSample;
        private double[][] _powers = { new double[_signalWindowBins], new double[_signalWindowBins] };

        public Action<double[][]> OnDataAvalable { get; set; }

        public PulseSignalProcessor() : base(SampleRate, 2, 0, 1, FourieBlockSize)
        {
            for (var i = 0; i < FourieBlockSize; i++)
            {
                var omega = 2 * Math.PI * TransmitterFreq * i / SampleRate;
                var k = NAudio.Dsp.FastFourierTransform.BlackmannHarrisWindow(i, FourieBlockSize);
                _pulse[i] = k * Math.Sin(omega);
            }
        }

        protected override void ProcessAudioData(float[] collectedSoundData)
        {
            for (var i = 0; i < collectedSoundData.Length; i += 2)
            {
                var d = _goertzelDirect.Power(collectedSoundData[i]);
                var r = _goertzelReflected.Power(collectedSoundData[i + 1]);
                _powers[0][_nCurrentSample] = d;
                _powers[1][_nCurrentSample] = r;
                _nCurrentSample++;
                if (_nCurrentSample == _powers[0].Length)
                {
                    var powers = _powers;
                    OnDataAvalable(powers);
                    _nCurrentSample = 0;
                    _powers = new[] { new double[_signalWindowBins], new double[_signalWindowBins] };
                }
            }
        }

        protected override double GenerateSample(double time, long offset)
        {
            var windowOffset = (int)(offset % _signalWindowBins);
            if (windowOffset < _pulse.Length)
            {
                return _pulse[windowOffset];
            }
            return 0;
        }
    }
}
