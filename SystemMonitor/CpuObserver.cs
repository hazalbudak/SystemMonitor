using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Management;
using System.ServiceProcess;
using System.Linq;
using System.Collections.Generic;

namespace SystemMonitor
{
    public class CpuObserver : IObserver, IDisposable
    {
        private ProgressBar _progressBar;
        private DataGridView _dataGridViewServices;
        private Label _labelCpu;
        private Chart _chartCpu;
        private Timer _updateCpuTimer;
        private ServiceController[] _services;
        private Dictionary<int, PerformanceCounter> _processCounters = new Dictionary<int, PerformanceCounter>();
        private PerformanceCounter _totalCpuCounter;
        private FormCpu _formCpu;

        public CpuObserver(ProgressBar progressBar, DataGridView dataGridViewServices, Label labelCpu, Chart chartCpu)
        {
            _progressBar = progressBar;
            _dataGridViewServices = dataGridViewServices;
            _labelCpu = labelCpu;
            _chartCpu = chartCpu;

            InitializeDataGridView();
            PopulateServices();

            _totalCpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            _updateCpuTimer = new Timer();
            _updateCpuTimer.Interval = 1000;
            _updateCpuTimer.Tick += UpdateCpuUsage;
            _updateCpuTimer.Start();

            _dataGridViewServices.CellClick += OnServiceClicked;

            // Initialize FormCpu but don't show it yet 
            _formCpu = new FormCpu();
        }

        private void InitializeDataGridView()
        {
            _dataGridViewServices.Columns.Add("ServiceName", "Service Name");
            _dataGridViewServices.Columns.Add("Status", "Status");
            _dataGridViewServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dataGridViewServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dataGridViewServices.MultiSelect = false;
        }

        private void PopulateServices()
        {
            _services = ServiceController.GetServices().Where(s => s.Status == ServiceControllerStatus.Running).ToArray();

            _dataGridViewServices.Rows.Add("Total CPU Usage", "N/A");
            foreach (var service in _services)
            {
                _dataGridViewServices.Rows.Add(service.ServiceName, service.Status.ToString());
            }

            if (_dataGridViewServices.Rows.Count > 0)
            {
                _dataGridViewServices.Rows[0].Selected = true;
            }
        }

        private void OnServiceClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedServiceName = _dataGridViewServices.Rows[e.RowIndex].Cells["ServiceName"].Value.ToString();
                if (selectedServiceName != "Total CPU Usage")
                {
                    _formCpu.Show();
                    _formCpu.BringToFront();
                }
            }
        }

        private void UpdateCpuUsage(object sender, EventArgs e)
        {
            if (_dataGridViewServices.SelectedRows.Count > 0)
            {
                var selectedServiceName = _dataGridViewServices.SelectedRows[0].Cells["ServiceName"].Value.ToString();
                if (selectedServiceName == "Total CPU Usage")
                {
                    UpdateTotalCpuUsage();
                }
                else
                {
                    UpdateServiceCpuUsage(selectedServiceName);
                }
            }
        }

        private void UpdateTotalCpuUsage()
        {
            try
            {
                float cpuUsage = _totalCpuCounter.NextValue();
                UpdateUI(cpuUsage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating total CPU usage: {ex.Message}");
            }
        }

        private void UpdateServiceCpuUsage(string selectedServiceName)
        {
            var service = _services.FirstOrDefault(s => s.ServiceName == selectedServiceName);

            if (service != null)
            {
                try
                {
                    var processId = GetServiceProcessId(service.ServiceName);
                    if (processId != -1)
                    {
                        var processCpuUsage = GetCpuUsageForProcess(processId);
                        if (processCpuUsage >= 0)
                        {
                            UpdateUI(processCpuUsage);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating service CPU usage: {ex.Message}");
                }
            }
        }

        private void UpdateUI(float cpuUsage)
        {
            _progressBar.Value = (int)Math.Min(cpuUsage, 100);
            _labelCpu.Text = $"{cpuUsage:F2}%";

            _chartCpu.Series["CPU"].Points.AddY(cpuUsage);
            if (_chartCpu.Series["CPU"].Points.Count > 60)
            {
                _chartCpu.Series["CPU"].Points.RemoveAt(0);
            }
            _chartCpu.ResetAutoValues();

            // Update FormCpu
            _formCpu.UpdateCpuUsage(cpuUsage);
        }

        private int GetServiceProcessId(string serviceName)
        {
            var query = $"SELECT ProcessId FROM Win32_Service WHERE Name = '{serviceName}'";
            using (var searcher = new ManagementObjectSearcher(query))
            {
                foreach (var obj in searcher.Get())
                {
                    return Convert.ToInt32(obj["ProcessId"]);
                }
            }
            return -1;
        }

        private float GetCpuUsageForProcess(int processId)
        {
            try
            {
                if (!_processCounters.TryGetValue(processId, out var cpuCounter))
                {
                    var process = Process.GetProcessById(processId);
                    cpuCounter = new PerformanceCounter("Process", "% Processor Time", process.ProcessName, true);
                    _processCounters[processId] = cpuCounter;
                }

                cpuCounter.NextValue(); // First call will always return 0
                System.Threading.Thread.Sleep(100); // Wait a bit
                return cpuCounter.NextValue() / Environment.ProcessorCount;
            }
            catch (ArgumentException)
            {
                // Process has exited, remove the counter
                _processCounters.Remove(processId);
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting CPU usage: {ex.Message}");
                return -1;
            }
        }

        public void Update(float cpuUsage, float ramUsage, float networkUsage, float diskUsage)
        {
            // This method is not used in this implementation
        }

        public void Dispose()
        {
            _updateCpuTimer?.Stop();
            _updateCpuTimer?.Dispose();
            _totalCpuCounter?.Dispose();
            foreach (var counter in _processCounters.Values)
            {
                counter.Dispose();
            }
            _formCpu?.Dispose();
        }
    }
}


