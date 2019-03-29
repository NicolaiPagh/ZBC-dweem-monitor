using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Diagnostics.Eventing;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Management.Infrastructure;
using Microsoft.Management.Infrastructure.Options;
using System.Security;

namespace dweem_monitor
{
    public class Monitor
    {
        //--------------------------------CIM SESSION------------------------------------------
        public static CimSession getCimSession(string computer)
        {
            //string computer = "192.168.1.27";
            string domain = "dweem.local";
            string username = "jof";

            string plaintextpassword = "Dromedar44";

            SecureString securepassword = new SecureString();
            foreach (char c in plaintextpassword)
            {
                securepassword.AppendChar(c);
            }

            // create Credentials
            CimCredential Credentials = new CimCredential(PasswordAuthenticationMechanism.Default,
                                                          domain,
                                                          username,
                                                          securepassword);

            // create SessionOptions using Credentials
            WSManSessionOptions SessionOptions = new WSManSessionOptions();
            SessionOptions.AddDestinationCredentials(Credentials);

            // create Session using computer, SessionOptions
            CimSession Session = CimSession.Create(computer, SessionOptions);
            return Session;
        }
        //--------------------------------CIM PROPERTY FORMATTING------------------------------------------
        public static string formatCimString(CimInstance instance, string property)
        {
            return instance.CimInstanceProperties[property].ToString().Split('=')[1].Replace('"', '\0');
        }

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
                Task.Delay(TimeSpan.FromMilliseconds(20), cts.Token).GetAwaiter().GetResult();
            }
            return Math.Round(cpuSamples.Average(), 0);
        }
        public static Task getCpuUsageAvgTask()
        {
            return Task.Factory.StartNew(() => getCpuUsageAvg(100));
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
            return ramCounter.NextValue() / 1000000;
        }
        public static double getTotalRAM()
        {
            float a = getAvailableRAM();
            float c = getCommittedRAM();

            float r = a + c;

            return Math.Round(r, 0);
        }
        public static float getNetworkBandwidthMB()
        {
            PerformanceCounter netBandwidthCounter = new PerformanceCounter("Network Interface", "Current Bandwidth", "Intel[R] Ethernet Connection [2] I219-LM");
            //return current network bandwidth usage in Bytes
            return netBandwidthCounter.NextValue() / 1000000;
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
        public static string getHostName()
        {
            string hostName = System.Environment.MachineName;

            return hostName;
        }
    }
}