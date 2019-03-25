using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Management;
using Microsoft.Management.Infrastructure; //C:\Program Files (x86)\Reference Assemblies\Microsoft\WMI\v1.0\Microsoft.Management.Infrastructure.dll
using Microsoft.Management.Infrastructure.Options;
using System.Security;


namespace dweem_monitor
{
    public class Monitor
    {

        public static CimSession wmiProcess()
        {
            string computer = "192.168.1.27";
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
    }
}