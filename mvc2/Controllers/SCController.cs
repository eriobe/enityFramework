using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvc2.Models.db;
using mvc2.Data;

namespace mvc2.Controllers
{
    public class SCController : Controller
    {
        private SkiersEntities db = new SkiersEntities();
        private IDbOperations db2 = new DbOperations();

        // GET: SC
        public ActionResult Index()
        {
            var skier = db2.GetSkiers();
            return View(skier.ToList());
        }

        // GET: SC/Details/5
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

        // GET: SC/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Country, "Id", "Name");
            return View();
        }

        // POST: SC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Firstname,Lastname,CountryId")] Skier skier)
        {
            if (ModelState.IsValid)
            {
                TempData["message"] = "Skidakaren sparades";
                TempData["CssClass"] = "alert-success";
                db.Skier.Add(skier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "Något gick fel, vänligen kontrollera dina inmatningar.";
                ViewBag.CountryId = new SelectList(db.Country, "Id", "Name", skier.CountryId);
                return View(skier);
            }

        }

        // GET: SC/Edit/5
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
            ViewBag.CountryId = new SelectList(db.Country, "Id", "Name", skier.CountryId);
            return View(skier);
        }

        // POST: SC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Firstname,Lastname,CountryId")] Skier skier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Country, "Id", "Name", skier.CountryId);
            return View(skier);
        }

        // GET: SC/Delete/5
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

        // POST: SC/Delete/5
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
