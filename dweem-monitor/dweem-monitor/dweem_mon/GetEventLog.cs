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
    public class GetEventLog
    {
        //public static EventLog[] GetEventLogs(string machineName)
        public static EventLog[] GetEventLogs(string machineName)
        {

            EventLog[] EventLogs;

            EventLogs = EventLog.GetEventLogs(machineName);

            int i = 0;
            EventLog[] eLogs = new EventLog[EventLogs.Length];
            
            foreach (EventLog log in EventLogs)
            {
                eLogs[i] = log;
                i++;
            }
            return eLogs;
        }
    }
}