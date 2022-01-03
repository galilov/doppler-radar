using System;
using System.Linq;
using NAudio.Dsp;

namespace SignalLibrary
{
    public class DopplerSignalProcessor : SignalProcessor
    {
        public const int SampleRate = 96000; // Bin/s
        public const int Log2OfBinCount = 14;
        public const float CentralFreq = 39996.09f; // Hz
        public const int FftBlockSize = 1 << Log2OfBinCount;

        public DopplerSignalProcessor() : base(SampleRate, 1, 1, 1, FftBlockSize)
        {
        }

        public Action<float[], Complex[]> OnDataAvailable { get; set; }

        protected override void ProcessAudioData(float[] collectedSoundData)
        {
            var complexData = collectedSoundData
                    .Select(x => new Complex { X = x, Y = 0 })
                    .ToArray();
            FastFourierTransform.FFT(true, Log2OfBinCount, complexData);
            OnDataAvailable?.Invoke(collectedSoundData.ToArray(), complexData);
        }

        protected override double GenerateSample(double time, long offset)
        {
            return Math.Sin(2 * Math.PI * time * CentralFreq);
        }
    }
}
