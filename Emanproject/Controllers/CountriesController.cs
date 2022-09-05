using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Emanproject.Models;
using Microsoft.Ajax.Utilities;

namespace Emanproject.Controllers
{
    public class CountriesController : Controller
    {
        private SchoolDB db = new SchoolDB();


        public ActionResult Index()
        {
            return View(db.Countries.ToList());
        }




        // GET : Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CountryName")] Country country)
        {

            if (ModelState.IsValid && db.Countries.Any(p => p.CountryName != country.CountryName))
            {
                db.Countries.Add(country);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {

                ModelState.AddModelError("CustomError", "don't duplicate name");
            }

            return View(country);
        }

        // get Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CountryName")] Country country)
        {


            if (ModelState.IsValid)
            {
                if (db.Countries.Any(p => p.CountryName == country.CountryName))
                {
                    ModelState.AddModelError("CustomError", "don't duplicate name");
                }
                else
                {
                    db.Entry(country).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            return View(country);
        }

        // GET Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Country country = db.Countries.Find(id);
            db.Countries.Remove(country);
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
