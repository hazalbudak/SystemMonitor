using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor
{
    public interface IObserver
    {
        void Update(float cpuUsage, float ramUsage, float diskusage, float networkUsage);
    }

}
