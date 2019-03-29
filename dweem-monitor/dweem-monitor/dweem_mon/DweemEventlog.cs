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
    public class DweemEventLog
    {
        public static EventLog[] getEventNames(string machineName = ".")
        //returns names of all event logs on specified machine
        {
            EventLog[] eventLogs;
            eventLogs = EventLog.GetEventLogs(machineName);
            EventLog[] eLogs = new EventLog[eventLogs.Length];

            int i = 0;
            foreach (EventLog log in eventLogs)
            {
                eLogs[i] = log;
                i++;
            }
            return eLogs;
        }
        public static List<string> getSystemEvents(string machineName = ".", string eventLogName = "System", string entryType = "Information", int samples = 10)
        {
            //machineName = hostname/IP of computer you want to pull from, entryType specifices which event entries to search for, samples defines how many entries to pull from the database
            //entryTypes possible are as follows in order of lowest importance to highest, Information, Warning, Error, Critical
            EventLog eventLogs = new EventLog(eventLogName, machineName);
            EventLogEntryCollection eventLogEntryCollection = eventLogs.Entries;

            int eventCount = eventLogEntryCollection.Count;
            List<string> eventsOfInterst = new List<string>();

            for (int i = eventCount -1; i > 0; i--)
            {

                EventLogEntry eventLogEntry = eventLogEntryCollection[i];
                int sampleSize = eventsOfInterst.Count;

                if (eventLogEntry.EntryType.ToString().Equals(entryType) && sampleSize < samples)
                {
                        string eventOfInterest = eventLogEntry.EntryType + ", " + eventLogEntry.Source;
                        eventsOfInterst.Add(eventOfInterest);

                }
            }
            //eventsOfInterst.Reverse(); 
            return eventsOfInterst;
        }
    }
}