using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using codefirst_9_2.Data;
using codefirst_9_2.Models;

namespace codefirst_9_2.Controllers
{
    public class StudentCourcesController : Controller
    {
        private codefirst_9_2Context db = new codefirst_9_2Context();

        // GET: StudentCources
        public ActionResult Index()
        {
            var studentCources = db.StudentCources.Include(s => s.Course).Include(s => s.Student);
            return View(studentCources.ToList());
        }

        // GET: StudentCources/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCource studentCource = db.StudentCources.Find(id);
            if (studentCource == null)
            {
                return HttpNotFound();
            }
            return View(studentCource);
        }

        // GET: StudentCources/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name");
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name");
            return View();
        }

        // POST: StudentCources/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CourseId,note,StudentId")] StudentCource studentCource)
        {
            if (ModelState.IsValid)
            {
                db.StudentCources.Add(studentCource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", studentCource.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", studentCource.StudentId);
            return View(studentCource);
        }

        // GET: StudentCources/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCource studentCource = db.StudentCources.Find(id);
            if (studentCource == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", studentCource.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", studentCource.StudentId);
            return View(studentCource);
        }

        // POST: StudentCources/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CourseId,note,StudentId")] StudentCource studentCource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentCource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", studentCource.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", studentCource.StudentId);
            return View(studentCource);
        }

        // GET: StudentCources/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCource studentCource = db.StudentCources.Find(id);
            if (studentCource == null)
            {
                return HttpNotFound();
            }
            return View(studentCource);
        }

        // POST: StudentCources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentCource studentCource = db.StudentCources.Find(id);
            db.StudentCources.Remove(studentCource);
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
