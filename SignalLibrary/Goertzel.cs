using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalLibrary
{
    public class Goertzel
    {
        private readonly double _coeff;
        private double _sprev, _sprev2;
        private readonly Queue<float> _signal;
        private readonly double[] _window;

        public Goertzel(int sampleRate, int frameLength, double freq, bool useWindow)
        {
            _signal = new Queue<float>(frameLength);
            _window = new double[frameLength];
            for (var i = 0; i < frameLength; i++)
            {
                _signal.Enqueue(0);
                _window[i] = useWindow ? NAudio.Dsp.FastFourierTransform.BlackmannHarrisWindow(i, frameLength) : 1;
            }
            var omega = 2 * Math.PI * freq / sampleRate;
            var cr = Math.Cos(omega);
            _coeff = 2 * cr;

        }

        public double Power(float sample)
        {
            _signal.Dequeue();
            _signal.Enqueue(sample);
            var i = 0;
            foreach (var x in _signal)
            {
                
                var s = x * _window[i++] + _coeff * _sprev - _sprev2;
                _sprev2 = _sprev;
                _sprev = s;
            }
            var power = _sprev2 * _sprev2 + _sprev * _sprev - _coeff * _sprev * _sprev2;
            _sprev = 0;
            _sprev2 = 0;
            return power;
        }
    }
}
