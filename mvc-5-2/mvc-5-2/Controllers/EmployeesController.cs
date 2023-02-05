using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using mvc_5_2.Models;

namespace mvc_5_2.Controllers
{
    public class EmployeesController : Controller
    {
        private MVCEntities1 db = new MVCEntities1();
        public ActionResult Index(string FirstName, string first)
        {
            var emp = db.Employees.ToList();

            if (first == "fname") { emp = db.Employees.Where(x => x.Firsrt_Name.Contains(FirstName)).ToList(); }

            else if (first == "lname") { emp = db.Employees.Where(x => x.LastName.Contains(FirstName)).ToList(); }

            else if (first == "email") { emp = db.Employees.Where(x => x.E_mail.Contains(FirstName)).ToList(); }
            else if (first == "phone") { emp = db.Employees.Where(x => x.Phone.ToString().Contains(FirstName)).ToList(); }


            else if (first == "job") { emp = db.Employees.Where(x => x.Job_Title.ToString().Contains(FirstName)).ToList(); }




            return View(emp);
            //return View(db.Employees.ToList());
        }
       

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //public ActionResult Create([Bind(Include = "ID,Firsrt_Name,LastName,E_mail,Phone,Age,Job_Title,Gender")] Employee employee,HttpPostedFileBase Image , HttpPostedFileBase CV)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        // Check if a file was uploaded
        //        //if (employee.Image != null && employee.Image.ContentLengt > 0)
        //        //{
        //        // Define the folder path to save the image
        //        string folderPath = Server.MapPath("~/img/");

        //        // Create the folder if it does not exist
        //        if (!Directory.Exists(folderPath))
        //        {
        //            Directory.CreateDirectory(folderPath);
        //        }

        //        // Generate a unique file name to prevent overwrite
        //        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(employee.Image);

        //        // Build the full path to the image
        //        var fullPath = Path.Combine(folderPath, fileName);

        //        // Save the image
        //        object value = employee.Image.SaveAs(folderPath);

        //        // Update the employee record with the file name
        //        employee.Image = fileName;
        //        //}

        //        db.Employees.Add(employee);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(employee);
        //}


        public ActionResult Create([Bind(Include = "ID,Firsrt_Name,LastName,E_mail,Phone,Age,Job_Title,Gender")] Employee employee, HttpPostedFileBase Image, HttpPostedFileBase CV)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    if (!Image.ContentType.ToLower().StartsWith("image/"))
                    {
                        ModelState.AddModelError("", "file uploaded is not an image");
                        return View(employee);
                    }
                    string folderPath = Server.MapPath("~/Content/Images");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string fileName = Path.GetFileName(Image.FileName);
                    string path = Path.Combine(folderPath, fileName);
                    Image.SaveAs(path);
                    employee.Image = "../Content/Images/" + fileName;
                }
                else
                {
                    ModelState.AddModelError("", "Please upload an image.");
                    return View(employee);
                }

                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Firsrt_Name,LastName,E_mail,Phone,Age,Job_Title,Gender")] Employee employee, HttpPostedFileBase Image, HttpPostedFileBase CV)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    if (!Image.ContentType.ToLower().StartsWith("image/"))
                    {
                        ModelState.AddModelError("", "file uploaded is not an image");
                        return View(employee);
                    }
                    string folderPath = Server.MapPath("~/Content/Images");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string fileName = Path.GetFileName(Image.FileName);
                    string path = Path.Combine(folderPath, fileName);
                    Image.SaveAs(path);
                    employee.Image = "../Content/Images/" + fileName;
                }
                else
                {
                    ModelState.AddModelError("", "Please upload an image.");
                    return View(employee);
                }


                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
