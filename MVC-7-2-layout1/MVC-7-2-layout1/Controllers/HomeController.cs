using MVC_7_2_layout1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_7_2_layout1.Controllers
{
    public class HomeController : Controller
    {
        private MVCEntities db = new MVCEntities();

        public ActionResult Index()
        {

            return View(db.devices.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}