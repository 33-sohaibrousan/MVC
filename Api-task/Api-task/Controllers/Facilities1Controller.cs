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
    public class Facilities1Controller : Controller
    {
        private MVCEntities db = new MVCEntities();

        // GET: Facilities1
        public ActionResult Index()
        {
            var facilities = db.Facilities.Include(f => f.Facilities1).Include(f => f.Facility1);
            return View(facilities.ToList());
        }
        public ActionResult show()
        {
            return View();
        }

        // GET: Facilities1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facility facility = db.Facilities.Find(id);
            if (facility == null)
            {
                return HttpNotFound();
            }
            return View(facility);
        }

        // GET: Facilities1/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.Facilities, "id", "Faculity");
            ViewBag.id = new SelectList(db.Facilities, "id", "Faculity");
            return View();
        }

        // POST: Facilities1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Faculity")] Facility facility)
        {
            if (ModelState.IsValid)
            {
                db.Facilities.Add(facility);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.Facilities, "id", "Faculity", facility.id);
            ViewBag.id = new SelectList(db.Facilities, "id", "Faculity", facility.id);
            return View(facility);
        }

        // GET: Facilities1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facility facility = db.Facilities.Find(id);
            if (facility == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.Facilities, "id", "Faculity", facility.id);
            ViewBag.id = new SelectList(db.Facilities, "id", "Faculity", facility.id);
            return View(facility);
        }

        // POST: Facilities1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Faculity")] Facility facility)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facility).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.Facilities, "id", "Faculity", facility.id);
            ViewBag.id = new SelectList(db.Facilities, "id", "Faculity", facility.id);
            return View(facility);
        }

        // GET: Facilities1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facility facility = db.Facilities.Find(id);
            if (facility == null)
            {
                return HttpNotFound();
            }
            return View(facility);
        }

        // POST: Facilities1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Facility facility = db.Facilities.Find(id);
            db.Facilities.Remove(facility);
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
