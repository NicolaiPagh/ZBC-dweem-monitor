using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace dweem_monitor
{
    public class Monitor
    {
        public static int getCurrentCpuUsage()
        {
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            cpuCounter.NextValue();
            //return cpu usage as an int in percent
            return Convert.ToInt32(cpuCounter.NextValue());
        }

        public static int getAvailableRAM()
        {
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            //return ram available as an int in MB
            return Convert.ToInt32(ramCounter.NextValue());
        }

        public static float getCommitedRAM()
        {
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");
            //return ram available as an int in MB
            return ramCounter.NextValue();
        }
    }
}