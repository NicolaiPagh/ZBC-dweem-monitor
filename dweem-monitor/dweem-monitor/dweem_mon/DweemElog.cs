using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Diagnostics.Eventing;
using System.Threading;
using System.Threading.Tasks;

namespace dweem_monitor
{
    public class DweemELog
    {
        //public static EventLog[] GetEventLogs(string machineName)
        public static System.Diagnostics.EventLog[] GetEventLogs(string machineName)
        {

            System.Diagnostics.EventLog[] EventLogs;

            EventLogs = System.Diagnostics.EventLog.GetEventLogs(machineName);

            int i = 0;
            System.Diagnostics.EventLog[] eLogs = new System.Diagnostics.EventLog[EventLogs.Length];
            
            foreach (System.Diagnostics.EventLog log in EventLogs)
            {
                eLogs[i] = log;
                i++;
            }
            return eLogs;
        }
    }
}