using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Api_task.Models;

namespace Api_task.Controllers
{
    public class Majoers1Controller : Controller
    {
        private MVCEntities db = new MVCEntities();

        // GET: Majoers1
        public ActionResult Index(int? id)
        {
            //var majoers = db.Majoers.Include(m => m.Facility);
            var majoers2 = db.Majoers.Where(m => m.FaculityId == id);

            return View(majoers2.ToList());
        }

        // GET: Majoers1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Majoer majoer = db.Majoers.Find(id);
            if (majoer == null)
            {
                return HttpNotFound();
            }
            return View(majoer);
        }

        // GET: Majoers1/Create
        public ActionResult Create()
        {
            ViewBag.FaculityId = new SelectList(db.Facilities, "id", "Faculity");
            return View();
        }

        // POST: Majoers1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Major,FaculityId")] Majoer majoer)
        {
            if (ModelState.IsValid)
            {
                db.Majoers.Add(majoer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FaculityId = new SelectList(db.Facilities, "id", "Faculity", majoer.FaculityId);
            return View(majoer);
        }

        // GET: Majoers1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Majoer majoer = db.Majoers.Find(id);
            if (majoer == null)
            {
                return HttpNotFound();
            }
            ViewBag.FaculityId = new SelectList(db.Facilities, "id", "Faculity", majoer.FaculityId);
            return View(majoer);
        }

        // POST: Majoers1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Major,FaculityId")] Majoer majoer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(majoer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FaculityId = new SelectList(db.Facilities, "id", "Faculity", majoer.FaculityId);
            return View(majoer);
        }

        // GET: Majoers1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Majoer majoer = db.Majoers.Find(id);
            if (majoer == null)
            {
                return HttpNotFound();
            }
            return View(majoer);
        }

        // POST: Majoers1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Majoer majoer = db.Majoers.Find(id);
            db.Majoers.Remove(majoer);
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
