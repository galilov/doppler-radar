using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using NAudio.Wave;

namespace SignalLibrary
{
    public abstract class SignalProcessor
    {
        public const int Bits = 32; // bits per sample

        private readonly BlockingCollection<float[]> _dataFromAsioCollection = new BlockingCollection<float[]>();
        private CancellationTokenSource _cancellationTokenSource;
        private AsioOut _asioOut;
        private Thread _recordThread;

        private readonly BufferedWaveProvider _provider;
        private long _currentSampleNo;
        private readonly int _sampleRate; // Bin/s
        private readonly int _nInputChannels;
        private readonly int _inputChannelOffset;
        private readonly int _nSoundSamplesPerBlockPerChannel;

        protected abstract void ProcessAudioData(float[] collectedSoundData);
        protected abstract double GenerateSample(double time, long offset);

        public static float GetAirSoundSpeed(int temperatureCelsius)
        {
            return 331 + 0.6f * temperatureCelsius;
        }

        protected SignalProcessor(int sampleRate, int nInputChannels, int inputChannelOffset, int nOutputChannels, int nSoundSamplesPerBlockPerChannel)
        {
            _sampleRate = sampleRate;
            _nInputChannels = nInputChannels;
            _inputChannelOffset = inputChannelOffset;
            _nSoundSamplesPerBlockPerChannel = nSoundSamplesPerBlockPerChannel;
            _provider = new BufferedWaveProvider(new WaveFormat(_sampleRate, Bits, nOutputChannels));
        }

        public void StartRecord()
        {
            if (_asioOut != null) return;
            _cancellationTokenSource = new CancellationTokenSource();
            _asioOut = PrepareAsioOut();
            TransmitSoundWave();
            var token = _cancellationTokenSource.Token;
            _asioOut.AudioAvailable += delegate (object o, AsioAudioAvailableEventArgs args)
            {
                TransmitSoundWave();
                // Другой размер буфера НЕ ИСПОЛЬЗОВАТЬ! В NAudio есть баг и есть размер буфера
                // больше этого, то остаток места данными НЕ заполняется
                var samples = new float[args.SamplesPerBuffer * args.InputBuffers.Length];
                args.GetAsInterleavedSamples(samples);
                _dataFromAsioCollection.Add(samples, token);
            };
            _recordThread = new Thread(AudioDataHandler);
            _recordThread.Start();
            _asioOut.Play();
        }

        protected void AudioDataHandler()
        {
            var token = _cancellationTokenSource.Token;
            var expectedSamples = _nInputChannels * _nSoundSamplesPerBlockPerChannel;
            var collectedSoundData = new float[expectedSamples];
            var collectedSoundDataLength = 0;
            var sourceDataOffset = 0;
            var data = Array.Empty<float>();
            try
            {
                while (!token.IsCancellationRequested)
                {
                    if (sourceDataOffset == data.Length)
                    {
                        data = _dataFromAsioCollection.Take(token);
                        sourceDataOffset = 0;
                    }

                    var remainedElements = expectedSamples - collectedSoundDataLength;
                    if (remainedElements >= data.Length)
                    {
                        Array.Copy(data, 0, collectedSoundData, collectedSoundDataLength, data.Length);
                        collectedSoundDataLength += data.Length;
                        sourceDataOffset = data.Length;
                    }
                    else
                    {
                        var n = data.Length >= sourceDataOffset + remainedElements
                            ? remainedElements
                            : data.Length - sourceDataOffset;
                        Array.Copy(data, sourceDataOffset, collectedSoundData, collectedSoundDataLength, n);
                        collectedSoundDataLength += n;
                        sourceDataOffset += n;
                    }

                    if (collectedSoundDataLength == expectedSamples)
                    {
                        ProcessAudioData(collectedSoundData);
                        collectedSoundDataLength = 0;
                    }

                    if (collectedSoundDataLength > expectedSamples)
                    {
                        throw new ApplicationException("Bug!");
                    }
                }
            }
            catch (OperationCanceledException exception)
            {
                Debug.WriteLine(exception.Message);
            }
            catch (ApplicationException exception)
            {
                Debug.WriteLine(exception.Message);
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
        }

        private void TransmitSoundWave()
        {
            while (_provider.BufferLength - _provider.BufferedBytes > 0)
            {
                var nSamples = (_provider.BufferLength - _provider.BufferedBytes) * 8 / _provider.WaveFormat.BitsPerSample;
                for (var i = 0; i < nSamples; i++)
                {
                    var offset = i + _currentSampleNo;
                    var time = offset / (double)_sampleRate;
                    var sample = GenerateSample(time, offset);
                    var bytes = DoubleSampleToBytes(sample);
                    _provider.AddSamples(bytes, 0, bytes.Length);
                }
                _currentSampleNo += nSamples;
            }
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
                    throw new NotSupportedException(nameof(_provider.WaveFormat.BitsPerSample) + " should be 32");
            }
        }

        private AsioOut PrepareAsioOut()
        {
            var names = AsioOut.GetDriverNames();
            var asioDriverName = names[0];
            var asioOut = new AsioOut(asioDriverName);
            asioOut.InputChannelOffset = _inputChannelOffset;
            asioOut.InitRecordAndPlayback(_provider, _nInputChannels, _sampleRate);
            return asioOut;
        }
    }
}
