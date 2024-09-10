using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemMonitor
{
    public partial class FormCpu : Form
    {
        public ProgressBar ProgressBarFormCpu { get; set; }
        public Label LabelFormCpu { get; set; }

        public FormCpu()
        {
            InitializeComponent();
            ProgressBarFormCpu = progressBarFormCpu; // Form üzerindeki ProgressBar kontrolü
            LabelFormCpu = labelFormCpu;             // Form üzerindeki Label kontrolü
        }

        public void UpdateCpuUsage(float cpuUsage)
        {
            ProgressBarFormCpu.Value = (int)Math.Min(cpuUsage, 100);
            LabelFormCpu.Text = $"%{cpuUsage:F2}";
        }

        private void FormCpu_Load(object sender, EventArgs e)
        {

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
}
