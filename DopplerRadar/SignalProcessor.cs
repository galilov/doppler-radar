using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Dsp;
using NAudio.Wave;

namespace DopplerRadar
{
    internal class SignalProcessor
    {
        public const int SampleRate = 96000; // Bin/s
        public const int NChannels = 1;
        public const int Bits = 32;
        public const int Log2OfBinCount = 14;
        public const float CentralFreq = 39996.09f; // Hz
        public const int FftBlockSize = 1 << Log2OfBinCount;
        private Action<float[], Complex[]> _action;
        private readonly BlockingCollection<float[]> _dataFromAsioCollection = new BlockingCollection<float[]>();
        private CancellationTokenSource _cancellationTokenSource;
        private AsioOut _asioOut;
        private Thread _recordThread;
        private readonly BufferedWaveProvider _provider;
        private readonly byte[] _tone;
        private int _toneIndex;
        private long _t;

        public SignalProcessor()
        {
            _provider = new BufferedWaveProvider(new WaveFormat(SampleRate, Bits, NChannels));
            _tone = new byte[_provider.BufferLength];
        }

        private unsafe byte[] DoubleSampleToBytes(double sample)
        {
            switch (_provider.WaveFormat.BitsPerSample)
            {
                case 32:
                    var result = new byte[4];
                    var scaledSample = (int)(sample * int.MaxValue);
                    fixed (byte* resPtr = &result[0])
                    {
                        *(int*)resPtr = scaledSample;
                    }
                    return result;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_provider.WaveFormat.BitsPerSample),
                        _provider.WaveFormat.BitsPerSample, @"Unsupported size");
            }
        }

        public void StartRecord(Action<float[], Complex[]> action)
        {
            if (_asioOut != null) return;
            _action = action;
            _cancellationTokenSource = new CancellationTokenSource();
            _asioOut = PrepareAsioOut();
            var token = _cancellationTokenSource.Token;
            _asioOut.AudioAvailable += delegate (object o, AsioAudioAvailableEventArgs args)
            {
                TransmitSinusWave();
                var samples = args.GetAsInterleavedSamples();
                _dataFromAsioCollection.Add(samples, token);
            };
            _recordThread = new Thread(ProcessAudioData);
            _recordThread.Start();
            _asioOut.Play();
        }

        private void TransmitSinusWave()
        {
            while (_provider.BufferLength - _provider.BufferedBytes > 0)
            {
                if (_toneIndex == 0)
                {
                    var pos = 0;
                    var nSamples = _tone.Length * 8 / _provider.WaveFormat.BitsPerSample;
                    for (var i = 0; i < nSamples; i++)
                    {
                        var time = (i + _t) / (double)SampleRate;
                        var sample = Math.Sin(2 * Math.PI * time * CentralFreq);
                        var bytes = DoubleSampleToBytes(sample);
                        Array.Copy(bytes, 0, _tone, pos, bytes.Length);
                        pos += bytes.Length;
                    }
                }
                var nFreeBytes = _provider.BufferLength - _provider.BufferedBytes;
                var nUnhandledBytes = _tone.Length - _toneIndex;
                var nBytesToAdd = Math.Min(nUnhandledBytes, nFreeBytes);
                _provider.AddSamples(_tone, _toneIndex, nBytesToAdd);
                _toneIndex += nBytesToAdd;
                _t += (nBytesToAdd * 8 / _provider.WaveFormat.BitsPerSample);
                if (_toneIndex == _tone.Length)
                {
                    _toneIndex = 0;
                }
            }
        }

        public void StopRecord()
        {
            if (_asioOut == null) return;
            _asioOut.Stop();
            _cancellationTokenSource.Cancel();
            _recordThread.Join();
            _asioOut.Dispose();
            _asioOut = null;
            _action = null;
        }

        private void ProcessAudioData()
        {
            var token = _cancellationTokenSource.Token;
            var collectedSoundData = new List<float>(FftBlockSize);
            try
            {
                while (!token.IsCancellationRequested)
                {
                    var data = _dataFromAsioCollection.Take(token);
                    var remainedElements = FftBlockSize - collectedSoundData.Count;
                    if (remainedElements >= data.Length)
                    {
                        collectedSoundData.AddRange(data);
                    }
                    else
                    {
                        for (var i = 0; i < remainedElements; i++)
                        {
                            collectedSoundData.Add(data[i]);
                        }
                    }

                    if (collectedSoundData.Count == FftBlockSize)
                    {
                        var complexData =
                            collectedSoundData
                                .Select(x => new Complex { X = x, Y = 0, })
                                .ToArray();
                        FastFourierTransform.FFT(true, Log2OfBinCount, complexData);
                        if (!token.IsCancellationRequested)
                        {
                            _action?.Invoke(collectedSoundData.ToArray(), complexData);
                        }

                        collectedSoundData.Clear();
                    }
                }
            }
            catch (OperationCanceledException exception)
            {
                Debug.WriteLine(exception.Message);
            }
        }

        private AsioOut PrepareAsioOut()
        {
            var names = AsioOut.GetDriverNames();
            var asioDriverName = names[0];
            var asioOut = new AsioOut(asioDriverName);
            asioOut.InputChannelOffset = 1;
            asioOut.InitRecordAndPlayback(_provider, NChannels, SampleRate);
            return asioOut;
        }
    }
}