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

        public static float getCommittedRAM()
        {
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");
            //return ram available as an int in MB
            return ramCounter.NextValue();
        }
        public static float getNetworkBandwidthMB()
        {
            PerformanceCounter netBandwidthCounter = new PerformanceCounter("Network Interface", "Current Bandwidth", "JMicron PCI Express Gigabit Ethernet Adapter");
            //return ram available as an int in MB
            return netBandwidthCounter.NextValue();
        }
        public static float getDiskAvgReadBytes()
        {
            PerformanceCounter diskAvgReadCounter = new PerformanceCounter("PhysicalDisk", "Avg. Disk Bytes/Read", "_Total");
            return diskAvgReadCounter.NextValue();
        }
        public static float getDiskAvgWriteBytes()
        {
            PerformanceCounter diskAvgWriteCounter = new PerformanceCounter("PhysicalDisk", "Avg. Disk Bytes/Write", "_Total");
            return diskAvgWriteCounter.NextValue();
        }
        public static float getDiskAvgThroughput()
        {
            PerformanceCounter diskAvgThroughput = new PerformanceCounter("PhysicalDisk", "Avg. Disk Bytes/Transfer", "_Total");
            return diskAvgThroughput.NextValue();
        }
        public static float getSysUpTime()
        {
            PerformanceCounter sysUpTime = new PerformanceCounter("System", "System Up Time");
            //gets system up time in miliseconds
            return sysUpTime.NextValue();
        }
    }
}