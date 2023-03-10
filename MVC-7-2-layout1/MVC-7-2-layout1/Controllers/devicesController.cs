using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_7_2_layout1.Models;

namespace MVC_7_2_layout1.Controllers
{
    public class devicesController : Controller
    {
        private MVCEntities db = new MVCEntities();

        // GET: devices
        public ActionResult Index()
        {

            return View(db.devices.ToList());
        }

        // GET: devices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            device device = db.devices.Find(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            return View(device);
        }

        // GET: devices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: devices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,deviceName,description,deviceImage")] device device, HttpPostedFileBase deviceImage)
        {
            if (ModelState.IsValid)
            {
                if (deviceImage != null)
                {
                    if (!deviceImage.ContentType.ToLower().StartsWith("image/"))
                    {
                        ModelState.AddModelError("", "file uploaded is not an image");
                        return View(device);
                    }
                    string folderPath = Server.MapPath("~/Content/Images");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string fileName = Path.GetFileName(deviceImage.FileName);
                    string path = Path.Combine(folderPath, fileName);
                    deviceImage.SaveAs(path);
                    device.deviceImage = "../Content/Images/" + fileName;
                }
                else
                {
                    ModelState.AddModelError("", "Please upload an image.");
                    return View(device);
                }



                db.devices.Add(device);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(device);
        }

        // GET: devices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            device device = db.devices.Find(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            return View(device);
        }

        // POST: devices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,deviceName,description,deviceImage")] device device, HttpPostedFileBase deviceImage)
        {
            if (ModelState.IsValid)
            {
                if (deviceImage != null)
                {
                    if (!deviceImage.ContentType.ToLower().StartsWith("image/"))
                    {
                        ModelState.AddModelError("", "file uploaded is not an image");
                        return View(device);
                    }
                    string folderPath = Server.MapPath("~/Content/Images");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string fileName = Path.GetFileName(deviceImage.FileName);
                    string path = Path.Combine(folderPath, fileName);
                    deviceImage.SaveAs(path);
                    device.deviceImage = "../Content/Images/" + fileName;
                }
                else
                {
                    ModelState.AddModelError("", "Please upload an image.");
                    return View(device);
                }
                db.Entry(device).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(device);
        }

        // GET: devices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            device device = db.devices.Find(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            return View(device);
        }

        // POST: devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            device device = db.devices.Find(id);
            db.devices.Remove(device);
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
