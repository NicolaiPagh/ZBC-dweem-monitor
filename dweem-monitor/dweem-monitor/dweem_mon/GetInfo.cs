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
            string username = "Administrator";

            string plaintextpassword = "Pa$$w0rd";

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
            /*
            var allVolumes = Session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_Volume");
            var allPDisks = Session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_DiskDrive");

            // Loop through all volumes
            foreach (CimInstance oneVolume in allVolumes)
            {
                // Show volume information

                if (oneVolume.CimInstanceProperties["DriveLetter"].ToString()[0] > ' ')
                {
                    Console.WriteLine("Volume ‘{0}’ has {1} bytes total, {2} bytes available",
                                      oneVolume.CimInstanceProperties["DriveLetter"],
                                      oneVolume.CimInstanceProperties["Size"],
                                      oneVolume.CimInstanceProperties["SizeRemaining"]);
                }

            }

            // Loop through all physical disks
            foreach (CimInstance onePDisk in allPDisks)
            {
                // Show physical disk information
                Console.WriteLine("Disk {0} is model {1}, serial number {2}",
                                  onePDisk.CimInstanceProperties["DeviceId"],
                                  onePDisk.CimInstanceProperties["Model"].ToString().TrimEnd(),
                                  onePDisk.CimInstanceProperties["SerialNumber"]);
            }

            */
        }
        /*
        public static void wmiConnect()
        {
            ConnectionOptions cOption = new ConnectionOptions();
            ManagementScope scope = null;
            string machine = "192.168.1.27";
            string nameSpaceRoot = "root";
            string managementScope = "cimv2";

            scope = new ManagementScope("\\\\" + machine + "\\" + nameSpaceRoot + "\\" + managementScope, cOption);
            
            scope.Options.Username = ".\\Administrator";
            scope.Options.Password = "Pa$$w0rd";
            
            scope.Options.EnablePrivileges = true;
            scope.Options.Authentication = AuthenticationLevel.PacketPrivacy;
            scope.Options.Impersonation = ImpersonationLevel.Impersonate;
            scope.Connect();
        }*/
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