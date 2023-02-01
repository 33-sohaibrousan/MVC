using mvc_task2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_task2.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult student()
        {
            List<Models.Student>stu= new List<Models.Student>();
            stu.Add(new Models.Student { Id =1,Name="sohaib",Major="arabic",Faculty="arabic1"});
            stu.Add(new Models.Student { Id = 1, Name = "moamen", Major = "math", Faculty = "math1" });
            stu.Add(new Models.Student { Id = 1, Name = "mayyas", Major = "art", Faculty = "art1" });


            return View(stu);
        }
    }
}