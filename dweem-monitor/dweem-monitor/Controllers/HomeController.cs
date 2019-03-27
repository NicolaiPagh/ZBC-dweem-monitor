using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;

namespace dweem_monitor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "DWEEM monitoring - An exclusive monitoring tool for your server.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "For contact, please refer to the section below.";

            return View();
        }

        public ActionResult Dashboard()
        {
            ViewBag.Message = "Monitoring page.";

            return View();
        }
        public ActionResult PerfMon()
        {
            ViewBag.Message = "PerfMon test page.";
            return View();
        }
        public ActionResult Sql()
        {
            ViewBag.Message = "SQL test page.";
            return View();
        }
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