using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SystemMonitor
{
    public partial class FormCpu : Form
    {
        public ProgressBar ProgressBarFormCpu { get; private set; }
        public Label LabelFormCpu { get; private set; }
        public Chart ChartFormCpu { get; private set; }

        public FormCpu()
        {
            InitializeComponent();
            ProgressBarFormCpu = progressBarFormCpu; // ProgressBar control on the form
            LabelFormCpu = labelFormCpu;             // Label control on the form
            ChartFormCpu = chartFormCpu;
        }

        public void UpdateCpuUsage(float cpuUsage)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<float>(UpdateCpuUsage), cpuUsage);
                return;
            }

            ProgressBarFormCpu.Value = (int)Math.Min(cpuUsage, 100);
            LabelFormCpu.Text = $"{cpuUsage:F2}%";
        }

        private void FormCpu_Load(object sender, EventArgs e)
        {
            // You can initialize any additional UI elements or settings here
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
            base.OnFormClosing(e);
        }
    }
}

    //public partial class FormCpu : Form
    //{
    //    public FormCpu()
    //    {
    //        InitializeComponent();
    //    }

    //    private void FormCpu_Load(object sender, EventArgs e)
    //    {

    //    }
    //}
//}
