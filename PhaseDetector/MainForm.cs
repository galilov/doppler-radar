using System;
using System.Windows.Forms;

namespace PhaseDetector
{
    public partial class MainForm : Form
    {
        private readonly PhaseSignalProcessor _signalProcessor = new PhaseSignalProcessor();
        private double _zero, _millimeters;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            IAsyncResult asyncResult = null;
            var d = new Action<double>(UIOnDataReceived);
            _signalProcessor.OnDataAvalable = m =>
            {
                if ((asyncResult == null || asyncResult.IsCompleted))
                {
                    asyncResult = BeginInvoke(d, m);
                }
            };
            _signalProcessor.StartRecord();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _signalProcessor.StopRecord();
        }

        private void UIOnDataReceived(double millimeters)
        {
            _millimeters = millimeters;
            lbAmplitude.Text = (_millimeters - _zero).ToString("F1");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _signalProcessor.StopRecord();
        }

        private void numTemperature_ValueChanged(object sender, EventArgs e)
        {
            _signalProcessor.Temperature = (int)numTemperature.Value;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            numTemperature.Value = _signalProcessor.Temperature;
            _signalProcessor.ReflectedMode = chckReflected.Checked;
        }

        private void chckReflected_CheckedChanged(object sender, EventArgs e)
        {
            _signalProcessor.ReflectedMode = chckReflected.Checked;
        }

        private void chckZeroLevel_CheckedChanged(object sender, EventArgs e)
        {
            if (chckZeroLevel.Checked)
            {
                _zero = _millimeters;
            }
            else
            {
                _zero = 0;
            }
        }
    }
}
