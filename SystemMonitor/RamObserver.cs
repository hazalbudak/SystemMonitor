using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.VisualBasic.Devices;

namespace SystemMonitor
{
    public class RamObserver : IObserver
    {
        private ProgressBar _progressBar;
        private Label _labelRam;
        private Chart _chartRam;
        private Timer _updateRamTimer;
        private PerformanceCounter _ramCounter;
        private float _totalMemory;

        public RamObserver(ProgressBar progressBar, Label labelRam, Chart chartRam)
        {
            // RAM kullanımı için ProgressBar, Label ve Chart kontrolleri
            _progressBar = progressBar;
            _labelRam = labelRam;
            _chartRam = chartRam;
            InitializeRamCounter();

            _updateRamTimer = new Timer();
            _updateRamTimer.Interval = 1000; // 1 saniye aralıklarla güncelleme yapar
            _updateRamTimer.Tick += UpdateRamUsage;
            _updateRamTimer.Start();
        }

        // PerformanceCounter ve toplam RAM miktarını ayarlayan fonksiyon
        private void InitializeRamCounter()
        {
            _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            _totalMemory = new ComputerInfo().TotalPhysicalMemory / (1024 * 1024); // MB cinsinden
        }

        // RAM kullanımını güncelleyen fonksiyon
        private void UpdateRamUsage(object sender, EventArgs e)
        {
            // Kullanılabilir RAM miktarını al
            float availableMemory = _ramCounter.NextValue();

            // Kullanılan RAM miktarını hesapla
            float usedMemory = _totalMemory - availableMemory;

            // Kullanılan RAM'in toplam RAM'e oranını hesapla (yüzde cinsinden)
            float ramUsage = (usedMemory / _totalMemory) * 100;

            // Eğer ramUsage değeri 0-100 aralığında değilse, ProgressBar'ın Value özelliğine atanamayacağı için sınırlandırıyoruz.
            if (ramUsage < 0) ramUsage = 0;
            if (ramUsage > 100) ramUsage = 100;

            // Observer aracılığıyla güncelleme işlemini gerçekleştir
            Update(0, ramUsage, 0, 0); // CPU, Network, Disk kullanımları 0 olarak geçildi, çünkü sadece RAM'i güncelliyoruz
        }

        // Observer arayüzündeki Update fonksiyonu RAM kullanımıyla UI'ı günceller
        public void Update(float cpuUsage, float ramUsage, float networkUsage, float diskUsage)
        {
            // ProgressBar'ı ve Label'ı güncelle
            _progressBar.Value = (int)ramUsage;
            _labelRam.Text = $" % {ramUsage:F1}";
            _chartRam.Series["RAM"].Points.AddY(ramUsage);
        }
    }
}
