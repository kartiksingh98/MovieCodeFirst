using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieCodeFirst.Models;

namespace MovieCodeFirst.Controllers
{
    public class DiscsController : Controller
    {
        private MovieContext db = new MovieContext();

        // GET: Discs
        public ActionResult Index()
        {
            var tblDiscs = db.tblDiscs.Include(t => t.Movie);
            return View(db.tblDiscs.ToList());
        }

        // GET: Discs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discs discs = db.tblDiscs.Find(id);
            if (discs == null)
            {
                return HttpNotFound();
            }
            return View(discs);
        }

        // GET: Discs/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Movies, "Id", "Moviename");
            return View();
        }

        // POST: Discs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, id, Isavailable,Quantity")] Discs discs)
        {
            if (ModelState.IsValid)
            {
                db.tblDiscs.Add(discs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Movies, "Id", "Moviename", discs.Id);
            return View(discs);
        }

        // GET: Discs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discs discs = db.tblDiscs.Find(id);
            if (discs == null)
            {
                return HttpNotFound();
            }
            return View(discs);
        }

        // POST: Discs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Moviename,Isavailable,Quantity")] Discs discs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(discs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(discs);
        }

        // GET: Discs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discs discs = db.tblDiscs.Find(id);
            if (discs == null)
            {
                return HttpNotFound();
            }
            return View(discs);
        }

        // POST: Discs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Discs discs = db.tblDiscs.Find(id);
            db.tblDiscs.Remove(discs);
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
