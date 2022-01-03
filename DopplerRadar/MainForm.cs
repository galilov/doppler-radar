using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GraphLibrary;
using NAudio.Dsp;
using SignalLibrary;

namespace DopplerRadar
{
    public partial class MainForm : Form
    {
        private delegate void SafeCallDelegate(float[] soundData, Complex[] spectrum);

        private readonly DopplerSignalProcessor _dopplerSignalProcessor = new DopplerSignalProcessor();
        private int _windowFreq = 200;
        private DirectBitmap _dbmSpectrum;
        private readonly Font _drawFont = new Font("Arial", 24, FontStyle.Bold);
        private readonly Pen _whitePen = new Pen(Brushes.White, 4);
        private float _soundSpeed;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            IAsyncResult asyncResult = null;
            _dopplerSignalProcessor.OnDataAvailable += (soundData, spectrum) =>
            {
                if ((asyncResult == null || asyncResult.IsCompleted))
                {
                    asyncResult = BeginInvoke(new SafeCallDelegate(UIOnAudioDataReceived), soundData, spectrum);
                }
            };
            _dopplerSignalProcessor.StartRecord();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _dopplerSignalProcessor.StopRecord();
        }

        private void UIOnAudioDataReceived(float[] soundData, Complex[] spectrum)
        {
            const float frameFreq = (float)DopplerSignalProcessor.SampleRate / DopplerSignalProcessor.FftBlockSize;
            var lowFreqToShow = DopplerSignalProcessor.CentralFreq - _windowFreq;
            var highFreqToShow = DopplerSignalProcessor.CentralFreq + _windowFreq;
            var lowBinToShow = (int)(lowFreqToShow / frameFreq);
            var highBinToShow = (int)(highFreqToShow / frameFreq);

            var amplitudes = new float[highBinToShow - lowBinToShow];
            for (var i = 0; i < amplitudes.Length; i++)
            {
                var bin = spectrum[i + lowBinToShow];
                var binAmplitude = (float)Math.Sqrt(bin.X * bin.X + bin.Y * bin.Y);
                amplitudes[i] = binAmplitude;
            }

            var maxAmplitude = amplitudes.Max();
            var yScale = _dbmSpectrum.Height / maxAmplitude;
            var xScale = (float)_dbmSpectrum.Width / amplitudes.Length;

            using (var g = Graphics.FromImage(_dbmSpectrum.Bitmap))
            {
                g.FillRectangle(Brushes.Black, 0, 0, _dbmSpectrum.Width, _dbmSpectrum.Height);

                lbAmplitude.Text = maxAmplitude.ToString("N6");
                var showSpeed = chckBoxSpeed.Checked;

                for (var i = 0; i < amplitudes.Length; i++)
                {
                    var scaledAmplitude = amplitudes[i] * yScale;
                    var toY = _dbmSpectrum.Height - scaledAmplitude;
                    var toX = i * xScale;
                    g.DrawLine(_whitePen,
                        i * xScale, _dbmSpectrum.Height, toX,
                        toY + 10);
                    if (scaledAmplitude > _dbmSpectrum.Height / 3f)
                    {
                        var freq = (i + lowBinToShow) * frameFreq;
                        if (showSpeed)
                        {
                            var rf = freq / DopplerSignalProcessor.CentralFreq;
                            var speed = (_soundSpeed * (rf - 1) / (rf + 1));
                            var captionSpeed = speed.ToString("F2");
                            g.DrawString(captionSpeed, _drawFont, Brushes.LawnGreen, toX, toY);
                        }
                        else
                        {
                            var captionFreq = freq.ToString("F2");
                            g.DrawString(captionFreq, _drawFont, Brushes.Yellow, toX, toY);
                        }
                    }
                }

            }
            pbxSpectrum.Invalidate();
        }

        private void pbxSpectrum_Resize(object sender, EventArgs e)
        {
            _dbmSpectrum = new DirectBitmap(pbxSpectrum.Width, pbxSpectrum.Height);
        }

        private void pbxSpectrum_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(_dbmSpectrum.Bitmap, 0, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _dbmSpectrum = new DirectBitmap(pbxSpectrum.Width, pbxSpectrum.Height);
            UpdateSoundSpeed();
        }

        private void numTemperature_ValueChanged(object sender, EventArgs e)
        {
            UpdateSoundSpeed();
        }

        private void UpdateSoundSpeed()
        {
            _soundSpeed = 331 + 0.6f * (int)numTemperature.Value;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _dopplerSignalProcessor.StopRecord();
        }
    }
}
