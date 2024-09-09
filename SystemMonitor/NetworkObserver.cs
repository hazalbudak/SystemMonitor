using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace SystemMonitor
{
    public class NetworkObserver : IObserver
    {
        private ProgressBar _progressBar;
        private Label _labelNetwork;
        private Chart _chartNetwork;
        private Timer _updateNetworkTimer;
        private List<PerformanceCounter> _networkCountersSent;
        private List<PerformanceCounter> _networkCountersReceived;

        public NetworkObserver(ProgressBar progressBar, Label labelNetwork, Chart chartNetwork)
        {
            _progressBar = progressBar;
            _labelNetwork = labelNetwork;
            _chartNetwork = chartNetwork;

            InitializeNetworkCounter();

            _updateNetworkTimer = new Timer();
            _updateNetworkTimer.Interval = 1000; // 1 saniye aralıklarla güncelleme yapar
            _updateNetworkTimer.Tick += UpdateNetworkUsage;
            _updateNetworkTimer.Start();
        }

        private void InitializeNetworkCounter()
        {
            _networkCountersSent = new List<PerformanceCounter>();
            _networkCountersReceived = new List<PerformanceCounter>();

            var category = new PerformanceCounterCategory("Network Interface");
            string[] instanceNames = category.GetInstanceNames();

            foreach (var instanceName in instanceNames)
            {
                // Her ağ arayüzü için gönderilen ve alınan baytları takip eden sayaçlar ekliyoruz
                var sentCounter = new PerformanceCounter("Network Interface", "Bytes Sent/sec", instanceName);
                var receivedCounter = new PerformanceCounter("Network Interface", "Bytes Received/sec", instanceName);

                _networkCountersSent.Add(sentCounter);
                _networkCountersReceived.Add(receivedCounter);
            }
        }

        private void UpdateNetworkUsage(object sender, EventArgs e)
        {
            float totalSentBytes = 0;
            float totalReceivedBytes = 0;

            foreach (var sentCounter in _networkCountersSent)
            {
                totalSentBytes += sentCounter.NextValue();
            }

            foreach (var receivedCounter in _networkCountersReceived)
            {
                totalReceivedBytes += receivedCounter.NextValue();
            }

            float totalNetworkUsage = (totalSentBytes + totalReceivedBytes) / (1024 * 1024); // MB/s cinsinden

            // Observer aracılığıyla güncelleme işlemini gerçekleştir
            Update(0, 0, totalNetworkUsage, 0); // Diğer kullanımlar 0 olarak geçildi, çünkü sadece Network'ü güncelliyoruz
        }

        public void Update(float cpuUsage, float ramUsage, float networkUsage, float diskUsage)
        {
            // ProgressBar'ı ve Label'ı güncelle
            _progressBar.Value = (int)Math.Min(networkUsage, 100); // %100 ile sınırlıyoruz
            _labelNetwork.Text = $"% {networkUsage:F0}";
            _chartNetwork.Series["Ağ"].Points.AddY(networkUsage);
        }
    }
}
