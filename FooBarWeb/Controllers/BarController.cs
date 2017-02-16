using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FooBarWeb.Models;

namespace FooBarWeb.Controllers
{
    public class BarController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bar
        public ActionResult Index()
        {
            return View(db.Bars.ToList());
        }

        // GET: Bar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bar bar = db.Bars.Find(id);
            if (bar == null)
            {
                return HttpNotFound();
            }
            return View(bar);
        }

        // GET: Bar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BarID,BarName")] Bar bar)
        {
            if (ModelState.IsValid)
            {
                db.Bars.Add(bar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bar);
        }

        // GET: Bar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bar bar = db.Bars.Find(id);
            if (bar == null)
            {
                return HttpNotFound();
            }
            return View(bar);
        }

        // POST: Bar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BarID,BarName")] Bar bar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bar);
        }

        // GET: Bar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bar bar = db.Bars.Find(id);
            if (bar == null)
            {
                return HttpNotFound();
            }
            return View(bar);
        }

        // POST: Bar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bar bar = db.Bars.Find(id);
            db.Bars.Remove(bar);
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
