using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;

namespace dweem_monitor.dweem_mon
{
    public class Graphs
    {
        public ActionResult RamChart()
        {
            decimal uRAM = Convert.ToDecimal(Monitor.getCommittedRAM());
            decimal aRAM = Monitor.getAvailableRAM();

            string myTheme =
                @"<Chart BackColor=""Transparent"" >
                                        <ChartAreas>
                                               <ChartArea Name=""Default"" BackColor=""Transparent""></ChartArea>
                                        </ChartAreas>
                                     </Chart>";
            new Chart(width: 350, height: 350, theme: myTheme)
                .AddSeries(
                    chartType: "pie",
                         xValue: new[] { "aRAM", "uRAM" },
                    yValues: new[] { aRAM, uRAM, })
                .Write("png");
            return null;
        }
    }
}