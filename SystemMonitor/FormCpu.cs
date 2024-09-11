using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SystemMonitor
{
    public partial class FormCpu : Form
    {
        public ProgressBar ProgressBarFormCpu { get; private set; }
        public Label LabelFormCpu { get; private set; }
        public Chart ChartFormCpu { get; private set; }

        public FormCpu(string serviceName)
        {
            InitializeComponent();
            ProgressBarFormCpu = progressBarFormCpu;
            LabelFormCpu = labelFormCpu;
            ChartFormCpu = chartFormCpu;

            Text = $"CPU Usage - {serviceName}";
            InitializeChart();
        }

        private void InitializeChart()
        {
            ChartFormCpu.Series.Clear();
            ChartFormCpu.Series.Add("CPU");
            ChartFormCpu.Series["CPU"].ChartType = SeriesChartType.Line;
            ChartFormCpu.ChartAreas[0].AxisY.Maximum = 100;
            ChartFormCpu.ChartAreas[0].AxisY.Minimum = 0;
            //ChartFormCpu.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            // X ekseni için zaman yerine aralık belirlenir (örneğin 0'dan başlayıp 60'a kadar gidiyor)
            ChartFormCpu.ChartAreas[0].AxisX.Minimum = 0;
            ChartFormCpu.ChartAreas[0].AxisX.Maximum = 50; // Bu değeri istediğin genişliğe göre değiştirebilirsin

            // X ekseninin aralığını ayarlıyoruz (örneğin her birim 5 adımda)
            ChartFormCpu.ChartAreas[0].AxisX.Interval = 10;

            // X eksenindeki label formatını kaldırıyoruz
            ChartFormCpu.ChartAreas[0].AxisX.LabelStyle.Format = "";

            ChartFormCpu.Series["CPU"].Color = Color.Red;
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

            ChartFormCpu.Series["CPU"].Points.AddXY(DateTime.Now, cpuUsage);
            if (ChartFormCpu.Series["CPU"].Points.Count > 60)
            {
                ChartFormCpu.Series["CPU"].Points.RemoveAt(0);
            }
            ChartFormCpu.ResetAutoValues();
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
