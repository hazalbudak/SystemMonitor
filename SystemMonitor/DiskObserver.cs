using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace SystemMonitor
{
    public class DiskObserver : IObserver
    {
        private ProgressBar _progressBar;
        private Label _labelDisk;
        private Chart _chartDisk;
        private Timer _updateDiskTimer;
        private List<PerformanceCounter> _diskCounters;

        public DiskObserver(ProgressBar progressBar, Label labelDisk, Chart chartDisk)
        {
            _progressBar = progressBar;
            _labelDisk = labelDisk;
            _chartDisk = chartDisk;

            InitializeDiskCounter();

            _updateDiskTimer = new Timer();
            _updateDiskTimer.Interval = 1000; // 1 saniye aralıklarla güncelleme yapar
            _updateDiskTimer.Tick += UpdateDiskUsage;
            _updateDiskTimer.Start();
        }

        private void InitializeDiskCounter()
        {
            _diskCounters = new List<PerformanceCounter>();

            // Bilgisayardaki tüm fiziksel diskleri al
            var category = new PerformanceCounterCategory("PhysicalDisk");
            string[] instanceNames = category.GetInstanceNames();

            foreach (var instanceName in instanceNames)
            {
                // "_Total" adındaki instance'ı atla çünkü bu tüm disklerin toplamını içerir.
                if (instanceName == "_Total") continue;

                // Her disk için bir PerformanceCounter oluştur ve listeye ekle
                var diskCounter = new PerformanceCounter("PhysicalDisk", "% Disk Time", instanceName);
                _diskCounters.Add(diskCounter);
            }
        }

        private void UpdateDiskUsage(object sender, EventArgs e)
        {
            float totalDiskUsage = 0;

            foreach (var diskCounter in _diskCounters)
            {
                totalDiskUsage += diskCounter.NextValue();
            }

            // Disk kullanımı yüzdesini hesapla ve arayüzde göster
            float averageDiskUsage = totalDiskUsage / _diskCounters.Count;

            if (averageDiskUsage < 0) averageDiskUsage = 0;
            if (averageDiskUsage > 100) averageDiskUsage = 100;

            // Observer aracılığıyla güncelleme işlemini gerçekleştir
            Update(0, 0, 0, averageDiskUsage); // Diğer kullanımlar 0 olarak geçildi, çünkü sadece Disk'i güncelliyoruz
        }

        public void Update(float cpuUsage, float ramUsage, float networkUsage, float diskUsage)
        {
            // ProgressBar'ı ve Label'ı güncelle
            _progressBar.Value = (int)diskUsage;
            _labelDisk.Text = $"% {diskUsage:F1}";
            _chartDisk.Series["Disk"].Points.AddY(diskUsage);
        }
    }
}
