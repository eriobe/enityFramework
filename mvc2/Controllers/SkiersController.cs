using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvc2.Models.db;

namespace mvc2.Controllers
{
    public class SkiersController : Controller
    {
        private SkiersEntities db = new SkiersEntities();

        // GET: Skiers
        public ActionResult Index()
        {
            return View(db.Skier.ToList());
        }

        // GET: Skiers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skier skier = db.Skier.Find(id);
            if (skier == null)
            {
                return HttpNotFound();
            }
            return View(skier);
        }

        // GET: Skiers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skiers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Firstname,Lastname")] Skier skier)
        {
            if (ModelState.IsValid)
            {
                db.Skier.Add(skier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skier);
        }

        // GET: Skiers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skier skier = db.Skier.Find(id);
            if (skier == null)
            {
                return HttpNotFound();
            }
            return View(skier);
        }

        // POST: Skiers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Firstname,Lastname")] Skier skier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skier);
        }

        // GET: Skiers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skier skier = db.Skier.Find(id);
            if (skier == null)
            {
                return HttpNotFound();
            }
            return View(skier);
        }

        // POST: Skiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Skier skier = db.Skier.Find(id);
            db.Skier.Remove(skier);
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
