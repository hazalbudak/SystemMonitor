using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor
{
    public class SystemMonitor : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        private float _cpuUsage;
        private float _ramUsage;
        private float _diskUsage;
        private float _networkUsage;

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_cpuUsage, _ramUsage, _diskUsage, _networkUsage);
            }
        }

        //public void CheckSystem()
        //{
        //    _cpuUsage = GetCPUUsage();
        //    _ramUsage = GetRAMUsage();
        //    _diskUsage = GetDiskUsage();
        //    _networkUsage = GetNetworkUsage();

        //    Notify();
        //}
    }

}
