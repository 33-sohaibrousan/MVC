using Api2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Api2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


        public ActionResult create()
        {

            ViewBag.Title = "create";

            return View();
        }


        [HttpPost]
        public ActionResult create( Product  product)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44344/api/products");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Product>("Products", product);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(product);
        }

    }

    
}
