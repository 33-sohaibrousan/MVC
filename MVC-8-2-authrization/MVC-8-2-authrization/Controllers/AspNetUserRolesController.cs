using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_8_2_authrization.Models;

namespace MVC_8_2_authrization.Controllers
{
    [Authorize]
    public class AspNetUserRolesController : Controller
    {
        private MVCEntities1 db = new MVCEntities1();

        // GET: AspNetUserRoles
        public ActionResult Index()
        {
            var aspNetUserRoles = db.AspNetUserRoles.Include(a => a.AspNetRole).Include(a => a.AspNetUser);
            return View(aspNetUserRoles.ToList());
        }

        // GET: AspNetUserRoles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserRole aspNetUserRole = db.AspNetUserRoles.Find(id);
            if (aspNetUserRole == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUserRole);
        }

        // GET: AspNetUserRoles/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.AspNetRoles, "Id", "Name");
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: AspNetUserRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,RoleId,note")] AspNetUserRole aspNetUserRole)
        {
            if (ModelState.IsValid)
            {
                db.AspNetUserRoles.Add(aspNetUserRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.AspNetRoles, "Id", "Name", aspNetUserRole.RoleId);
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", aspNetUserRole.UserId);
            return View(aspNetUserRole);
        }

        // GET: AspNetUserRoles/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserRole aspNetUserRole = db.AspNetUserRoles.Find(id);
            if (aspNetUserRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.AspNetRoles, "Id", "Name", aspNetUserRole.RoleId);
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", aspNetUserRole.UserId);
            return View(aspNetUserRole);
        }

        // POST: AspNetUserRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,RoleId,note")] AspNetUserRole aspNetUserRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspNetUserRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.AspNetRoles, "Id", "Name", aspNetUserRole.RoleId);
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", aspNetUserRole.UserId);
            return View(aspNetUserRole);
        }

        // GET: AspNetUserRoles/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserRole aspNetUserRole = db.AspNetUserRoles.Find(id);
            if (aspNetUserRole == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUserRole);
        }

        // POST: AspNetUserRoles/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AspNetUserRole aspNetUserRole = db.AspNetUserRoles.Find(id);
            db.AspNetUserRoles.Remove(aspNetUserRole);
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
