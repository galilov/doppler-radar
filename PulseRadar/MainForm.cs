using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using GraphLibrary;
using SignalLibrary;

namespace PulseRadar
{
    public partial class MainForm : Form
    {
        private DirectBitmap _dbm;
        private readonly PulseSignalProcessor _signalProcessor = new PulseSignalProcessor();
        private readonly Font _font = new Font("Arial", 24, FontStyle.Bold);
        private int _temperature = 20;
        private float _distance, _zeroLevel;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            IAsyncResult asyncResult = null;
            var d = new Action<double[][]>(UIOnDataReceived);
            _signalProcessor.OnDataAvalable += data =>
            {
                if (asyncResult == null || asyncResult.IsCompleted)
                {
                    asyncResult = BeginInvoke(d, new object[] { data });
                }
            };
            _signalProcessor.StartRecord();
        }

        private void UIOnDataReceived(double[][] data)
        {
            using (var g = Graphics.FromImage(_dbm.Bitmap))
            {
                g.FillRectangle(Brushes.Black, 0, 0, _dbm.Width, _dbm.Height);

                var maxPosDirect = MaxAndPos(data[0]);
                var maxDirect = maxPosDirect.Item1;
                var posMaxDirect = maxPosDirect.Item2;

                var maxPosReflected = MaxAndPos(data[1]);
                var maxReflected = maxPosReflected.Item1;
                var posMaxReflected = maxPosReflected.Item2;

                var zeroLevel = _dbm.Height / 2;
                var directScale = maxDirect == 0 ? 0 : (_dbm.Height - 10) / 2f / maxDirect;
                var reflectedScale = maxReflected == 0 ? 0 : (_dbm.Height - 10) / 2f / maxReflected;
                var horizontalScale = (float)pb.Width / data[0].Length;
                float xPrevReflected = 0, yPrevReflected = zeroLevel - 2;
                float xPrevDirect = 0, yPrevDirect = zeroLevel + 2;
                for (var i = 0; i < data[0].Length; i++)
                {
                    var d = CorrectXPos(posMaxDirect);
                    var index = (i + d) % data[0].Length;

                    var x = horizontalScale * i;
                    var yDirect = (float)(zeroLevel + data[0][index] * directScale) + 2;
                    var yReflected = (float)(zeroLevel - data[1][index] * reflectedScale) - 2;
                    g.DrawLine(Pens.Red, xPrevDirect, yPrevDirect, x, yDirect);
                    g.DrawLine(Pens.GreenYellow, xPrevReflected, yPrevReflected, x, yReflected);
                    xPrevDirect = x;
                    yPrevDirect = yDirect;
                    xPrevReflected = x;
                    yPrevReflected = yReflected;
                }

                var delta = posMaxReflected >= posMaxDirect ? posMaxReflected - posMaxDirect : data[0].Length - posMaxDirect + posMaxReflected;
                _distance = delta * SignalProcessor.GetAirSoundSpeed(_temperature) /
                               PulseSignalProcessor.SampleRate / 2;
                var sDistance = ((_distance - _zeroLevel) * 100).ToString("F1") + " cm";
                g.DrawString(sDistance,
                    _font,
                    Brushes.White,
                    delta * horizontalScale,
                    zeroLevel + 5);

            }
            pb.Invalidate();
        }

        private static int CorrectXPos(int pos)
        {
            if (pos > PulseSignalProcessor.FourieBlockSize / 2)
            {
                return pos - PulseSignalProcessor.FourieBlockSize / 2;
            }
            return pos;
        }

        private static Tuple<double, int> MaxAndPos(double[] data)
        {
            var max = data[0];
            var pos = 0;
            for (var i = 0; i < data.Length; i++)
            {
                var x = data[i];
                if (x > max)
                {
                    max = x;
                    pos = i;
                }
            }

            return new Tuple<double, int>(max, pos);
        }

        private void pb_Resize(object sender, EventArgs e)
        {
            _dbm = new DirectBitmap(pb.Width, pb.Height);
        }

        private void pb_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(_dbm.Bitmap, 0, 0);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _dbm = new DirectBitmap(pb.Width, pb.Height);
            numTemperature.Value = _temperature;
        }

        private void numTemperature_ValueChanged(object sender, EventArgs e)
        {
            _temperature = (int)numTemperature.Value;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _signalProcessor.StopRecord();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _signalProcessor.StopRecord();
        }

        private void chckZeroLevel_CheckedChanged(object sender, EventArgs e)
        {
            if (chckZeroLevel.Checked)
            {
                _zeroLevel = _distance;
            }
            else
            {
                _zeroLevel = 0;
            }
        }
    }
}