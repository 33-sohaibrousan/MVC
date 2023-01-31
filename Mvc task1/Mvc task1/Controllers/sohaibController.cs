using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_task1.Controllers
{
    public class sohaibController : Controller
    {
        // GET: sohaib
        public ActionResult Index()
        {
            return View();
        }
        public string Name()
        {
            var name= "<h1>Sohaib alrousan</h1>\r\n";
            return name;
        }
        public ActionResult Photo()
        {
            return Content("<img src=\"../sohaib.png\" width='300px'>");
        }
        public ActionResult Link()
        {
            return Content("<a href=\"https://www.linkedin.com/in/sohaib-al-rousan-428963223/\">Sohaib alrousan</a>");

        }

    }
}