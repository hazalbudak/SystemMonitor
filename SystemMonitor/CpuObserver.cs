using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Management; // CPU bilgilerini almak için gerekli
using System.ServiceProcess; // ServiceController için gerekli

namespace SystemMonitor
{
    public class CpuObserver : IObserver
    {
        private ProgressBar _progressBar;
        private Label _labelCpu;
        private Chart _chartCpu;
        private Timer _updateCpuTimer;
        private PerformanceCounter _cpuCounter;

        public CpuObserver(ProgressBar progressBar, Label labelCpu, Chart chartCpu)
        {
            _progressBar = progressBar;
            _labelCpu = labelCpu;
            _chartCpu = chartCpu;
            InitializeCpuCounter();

            _updateCpuTimer = new Timer();
            _updateCpuTimer.Interval = 1000; // 1 saniye aralıklarla güncelleme yapar
            _updateCpuTimer.Tick += UpdateCpuUsage;
            _updateCpuTimer.Start();
        }

        private void InitializeCpuCounter()
        {
            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        }

        private void UpdateCpuUsage(object sender, EventArgs e)
        {
            float cpuUsage = _cpuCounter.NextValue();

            // Eğer cpuUsage değeri 0-100 aralığında değilse, ProgressBar'ın Value özelliğine atanamayacağı için sınırlandırıyoruz.
            if (cpuUsage < 0) cpuUsage = 0;
            if (cpuUsage > 100) cpuUsage = 100;

            // Observer aracılığıyla güncelleme işlemini gerçekleştir
            Update(cpuUsage, 0, 0, 0); // RAM, Network, Disk kullanımları 0 olarak geçildi, çünkü sadece CPU'yu güncelliyoruz
        }

        public void Update(float cpuUsage, float ramUsage, float networkUsage, float diskUsage)
        {
            // ProgressBar'ı ve Label'ı güncelle
            _progressBar.Value = (int)cpuUsage;
            _labelCpu.Text = $"% {cpuUsage:F1}";
            _chartCpu.Series["CPU"].Points.AddY(cpuUsage);
        }
    }
}
