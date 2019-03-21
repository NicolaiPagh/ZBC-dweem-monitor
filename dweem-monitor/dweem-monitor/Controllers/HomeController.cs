using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}