using MVC_8_2_authrization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_8_2_authrization.Controllers
{

    public class HomeController : Controller
    {
        private MVCEntities1 db = new MVCEntities1();
        [Authorize]

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