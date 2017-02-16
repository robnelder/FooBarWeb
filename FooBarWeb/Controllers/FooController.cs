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
    public class FooController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Foo
        public ActionResult Index()
        {
            var viewmodel = new FooBarWeb.ViewModels.FooBar();
            viewmodel.Foos = db.Foos.ToList();
            viewmodel.Bars = db.Bars.ToList();
            //return View(db.Foos.ToList());
            return View(viewmodel);
        }

        // GET: Foo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Foo foo = db.Foos.Find(id);
            if (foo == null)
            {
                return HttpNotFound();
            }
            return View(foo);
        }

        // GET: Foo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Foo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FooID,FooName")] Foo foo)
        {
            if (ModelState.IsValid)
            {
                db.Foos.Add(foo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(foo);
        }

        // GET: Foo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Foo foo = db.Foos.Find(id);
            if (foo == null)
            {
                return HttpNotFound();
            }
            return View(foo);
        }

        // POST: Foo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FooID,FooName")] Foo foo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foo);
        }

        // GET: Foo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Foo foo = db.Foos.Find(id);
            if (foo == null)
            {
                return HttpNotFound();
            }
            return View(foo);
        }

        // POST: Foo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Foo foo = db.Foos.Find(id);
            db.Foos.Remove(foo);
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
