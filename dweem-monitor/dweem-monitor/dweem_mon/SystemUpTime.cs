using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace dweem_monitor
{
    public class SystemUpTime
    {
        public static TimeSpan getUptime()
        {
            PerformanceCounter sysUpTimeCounter = new PerformanceCounter("System", "System Up Time");
            //sys up time is a two-read counter, so calling it once to get the data then another time to actually output it is required. Dont ask.
            //gets system up time in miliseconds
            sysUpTimeCounter.NextValue();
            TimeSpan ts = TimeSpan.FromSeconds(sysUpTimeCounter.NextValue());

            return ts;
        }
        public static double totalSeconds()
        {
            TimeSpan ut = SystemUpTime.getUptime();
            return ut.TotalSeconds;
        }
        public static double totalMinutes()
        {
            TimeSpan ut = SystemUpTime.getUptime();
            return ut.TotalMinutes;
        }
        public static double totalHours()
        {
            TimeSpan ut = SystemUpTime.getUptime();
            return ut.TotalHours;
        }
        public static double totalDays()
        {
            TimeSpan ut = SystemUpTime.getUptime();
            return ut.TotalDays;
        }
        public static int seconds()
        {
            TimeSpan ut = SystemUpTime.getUptime();
            return ut.Seconds;
        }
        public static int minutes()
        {
            TimeSpan ut = SystemUpTime.getUptime();
            return ut.Minutes;
        }
        public static int hours()
        {
            TimeSpan ut = SystemUpTime.getUptime();
            return ut.Hours;
        }
        public static int days()
        {
            TimeSpan ut = SystemUpTime.getUptime();
            return ut.Days;
        }
    }
}