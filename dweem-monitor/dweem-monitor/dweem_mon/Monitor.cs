using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace dweem_monitor
{
    public class Monitor
    {
        private static float getCurrentCpuUsage()
        {
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            cpuCounter.NextValue();
            //return cpu usage as an int in percent
            return cpuCounter.NextValue();
        }
        private static readonly CancellationTokenSource cts = new CancellationTokenSource();
        public static double getCpuUsageAvg(int samples)
        {
            float[] cpuSamples = new float[samples];
            for (int i = 0; i < samples; i++)
            {
                cpuSamples[i] = Monitor.getCurrentCpuUsage();
                Task.Delay(TimeSpan.FromMilliseconds(10), cts.Token).GetAwaiter().GetResult();
            }
            return Math.Round(cpuSamples.Average(), 0);
        }
        public static float getAvailableRAM()
        {
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            //return ram available as an int in MB
            return ramCounter.NextValue();
        }

        public static float getCommittedRAM()
        {
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Committed Bytes");
            //return ram available as an int in MB
            return ramCounter.NextValue()/1000000;
        }
        public static double getTotalRAM()
        {
            float a = getAvailableRAM();
            float c = getCommittedRAM();

            float r = a + c;

            return Math.Round(r/1000, 0);
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
            PerformanceCounter diskAvgThroughputCounter = new PerformanceCounter("PhysicalDisk", "Avg. Disk Bytes/Transfer", "_Total");
            return diskAvgThroughputCounter.NextValue();
        }
    }
}