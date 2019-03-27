using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using Microsoft.Management.Infrastructure;

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
            new Chart(width: 260, height: 260, theme: myTheme)
                .AddSeries(
                    chartType: "pie",
                         xValue: new[] { "Available Ram", "Used Ram" },
                    yValues: new[] { aRAM, uRAM, })
                .Write("png");
            return null;
        }
        public ActionResult DiskChart()
        {
            CimSession session = Monitor.wmiProcess();

            var allVolumes = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_Volume");
            var allPDisks = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_DiskDrive");

            foreach (CimInstance oneVolume in allVolumes)
            {

                if (oneVolume.CimInstanceProperties["DriveLetter"].ToString()[0] > ' ')
                {
                    if (@Convert.ToString(oneVolume.CimInstanceProperties["DriveLetter"]) == "DriveLetter")
                    {

                        String Size = Convert.ToString(oneVolume.CimInstanceProperties["Capacity"]).Split(' ')[2];
                        String fSpace = Convert.ToString(oneVolume.CimInstanceProperties["FreeSpace"]).Split(' ')[2];
                        decimal uDisk = Convert.ToDecimal(Size) - Convert.ToDecimal(fSpace);
                        decimal aDisk = Convert.ToDecimal(fSpace);


                        string myTheme =
                                    @"<Chart BackColor=""Transparent"" >
                                        <ChartAreas>
                                               <ChartArea Name=""Default"" BackColor=""Transparent""></ChartArea>
                                        </ChartAreas>
                                     </Chart>";
                        new Chart(width: 260, height: 260, theme: myTheme)
                            .AddSeries(
                                chartType: "pie",
                                     xValue: new[] { "Available Diskspace", "Used Diskspace" },
                                yValues: new[] { aDisk, uDisk, })
                            .Write("png");
                        
                    }
                }
            }
            return null;
        }
    }
}