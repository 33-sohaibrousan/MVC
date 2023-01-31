 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Mvc_task1.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
      
       
            public string Indexx()
            {

                return "<a href = '/homewho.png' download > <img src='/homewho.png'> </a>\r\n        ";
            }

        public ActionResult AboutUs()
        {
            string html = "<a href='" + Url.Action("Default", "Default") + "'>" +
                            "<img src='/homewho.png' height='100' width='100' alt='Image to download' />" +
                          "</a>" +
                          "<br />" +
                          "This is the About Us page.";
            return Content(html);
        }

        //public ActionResult Contact(string labelText, string textboxText)
        //{
        //   string ViewBag = "Your contact page.";




        //    return Content(ViewBag);
        //}
        public ActionResult contact(string labelText, string textboxText)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div>");
            sb.Append("<label>" + "Name" + "</label>");
            sb.Append("<input type='text' value='" + textboxText + "' />");
            sb.Append("<label>" + "Email" + "</label>");
            sb.Append("<input type='text' value='" + textboxText + "' />");
            sb.Append("<label>" + "coment" + "</label>");
            sb.Append("<input type='text' value='" + textboxText + "' />");
            sb.Append("</div>");

            return Content(sb.ToString(), "text/html");
        }




    }
}