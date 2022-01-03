using System;
using System.Windows.Forms;
using SignalLibrary;

namespace PhaseDetector
{
    public partial class MainForm : Form
    {
        private delegate void SafeCallDelegate(double m);
        private readonly PhaseSignalProcessor _signalProcessor = new PhaseSignalProcessor();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            IAsyncResult asyncResult = null;
            _signalProcessor.OnDataAvalable = m =>
            {
                if ((asyncResult == null || asyncResult.IsCompleted))
                {
                    asyncResult = BeginInvoke(new SafeCallDelegate(UIOnAudioDataReceived), m);
                }
            };
            _signalProcessor.StartRecord();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _signalProcessor.StopRecord();
        }

        private void UIOnAudioDataReceived(double millimeters)
        {
            lbAmplitude.Text = millimeters.ToString("F1");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _signalProcessor.StopRecord();
        }

        private void numTemperature_ValueChanged(object sender, EventArgs e)
        {
            _signalProcessor.Temperature = (int) numTemperature.Value;
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
    }
}
