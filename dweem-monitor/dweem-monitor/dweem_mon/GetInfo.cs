using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dweem_monitor.dweem_mon
{
    public class GetInfo
    {
        public static dynamic get_cpus()
        {
            dynamic returndata = new ExpandoObject();

            var scope = new ManagementScope(Functions.GetServerName());
            var query = new SelectQuery("Select Name, NumberOfCores, NumberOfLogicalProcessors from Win32_Processor");
            var searcher = new ManagementObjectSearcher(scope, query);

            foreach (var x in searcher.Get())
            {
                returndata.name = x["Name"].ToString(); // CPU Name
                returndata.cores = x["NumberOfCores"].ToString(); // Cores
                returndata.threads = x["NumberOfLogicalProcessors"].ToString(); // Threads
            }

            return returndata;
        }
    }
}