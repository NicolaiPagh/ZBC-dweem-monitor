using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace dweem_monitor.dweem_mon
{
    public class GetInfo
    {

        PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");

        public string getCurrentCpuUsage()
        {
            return cpuCounter.NextValue() + "%";
        }

        public string getAvailableRAM()
        {
            return ramCounter.NextValue() + "MB";
        }
    }
}