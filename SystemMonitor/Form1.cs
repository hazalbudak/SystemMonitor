using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management; // CPU bilgilerini almak için gerekli
using System.ServiceProcess; // ServiceController için gerekli
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SystemMonitor
{
    public partial class Form1 : Form
    {
        private SystemMonitor _systemMonitor;
        //private PerformanceCounter cpuCounter;

        //private Timer updateCpuTimer;



        public Form1()
        {
            InitializeComponent();
            _systemMonitor = new SystemMonitor();



            this.Controls.Add(progressBarCpu);
            this.Controls.Add(labelCpu);
            this.Controls.Add(chart1);
            this.Controls.Add(comboBoxServices);

            chart1.Series.Clear();
            chart1.Series.Add("CPU");
            chart1.Series["CPU"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            var cpuObserver = new CpuObserver(progressBarCpu, labelCpu, chart1);
            _systemMonitor.Attach(cpuObserver);


            this.Controls.Add(progressBarRam);
            this.Controls.Add(labelRam);
            this.Controls.Add(chart1);

            chart1.Series.Clear();
            chart1.Series.Add("RAM");
            chart1.Series["RAM"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            var ramObserver = new RamObserver(progressBarRam, labelRam, chart1);
            _systemMonitor.Attach(ramObserver);


            this.Controls.Add(progressBarDisk);
            this.Controls.Add(labelDisk);
            this.Controls.Add(chart1);

            chart1.Series.Clear();
            chart1.Series.Add("Disk");
            chart1.Series["Disk"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            var diskObserver = new DiskObserver(progressBarDisk, labelDisk, chart1);
            _systemMonitor.Attach(diskObserver);


            this.Controls.Add(progressBarNetwork);
            this.Controls.Add(labelNetwork);
            this.Controls.Add(chart1);

            chart1.Series.Clear();
            chart1.Series.Add("Ağ");
            chart1.Series["Ağ"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            var networkObserver = new NetworkObserver(progressBarNetwork, labelNetwork, chart1);
            _systemMonitor.Attach(networkObserver);


            this.Controls.Add(progressBarCpu);
            this.Controls.Add(progressBarRam);
            this.Controls.Add(progressBarDisk);
            this.Controls.Add(progressBarNetwork);
            this.Controls.Add(chart1);

            chart1.Series.Clear();
            chart1.Series.Add("CPU");
            chart1.Series.Add("RAM");
            chart1.Series.Add("Disk");
            chart1.Series.Add("Ağ");

            chart1.Series["CPU"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["RAM"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Disk"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Ağ"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }
    }
}