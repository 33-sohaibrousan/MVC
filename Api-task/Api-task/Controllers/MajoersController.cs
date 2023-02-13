using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Api_task.Models;

namespace Api_task.Controllers
{
    public class MajoersController : ApiController
    {
        private MVCEntities db = new MVCEntities();

        // GET: api/Majoers
        public IQueryable<Majoer> GetMajoers()
        {
            return db.Majoers;
        }

        // GET: api/Majoers/5
        [ResponseType(typeof(Majoer))]
        public IHttpActionResult GetMajoer(int id)
        {
            Majoer majoer = db.Majoers.Find(id);
            if (majoer == null)
            {
                return NotFound();
            }

            return Ok(majoer);
        }

        // PUT: api/Majoers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMajoer(int id, Majoer majoer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != majoer.id)
            {
                return BadRequest();
            }

            db.Entry(majoer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MajoerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Majoers
        [ResponseType(typeof(Majoer))]
        public IHttpActionResult PostMajoer(Majoer majoer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Majoers.Add(majoer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = majoer.id }, majoer);
        }

        // DELETE: api/Majoers/5
        [ResponseType(typeof(Majoer))]
        public IHttpActionResult DeleteMajoer(int id)
        {
            Majoer majoer = db.Majoers.Find(id);
            if (majoer == null)
            {
                return NotFound();
            }

            db.Majoers.Remove(majoer);
            db.SaveChanges();

            return Ok(majoer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MajoerExists(int id)
        {
            return db.Majoers.Count(e => e.id == id) > 0;
        }
    }
}