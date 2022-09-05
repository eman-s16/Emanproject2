using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Emanproject.Models;

namespace Emanproject.Controllers
{
    public class ClassesController : Controller
    {
        private SchoolDB db = new SchoolDB();

        // GET: Classes
        public ActionResult Index()
        {
            return View(db.Classes.ToList());
        }



        // GET Create
        public ActionResult Create()
        {
            return View();
        }

        // POST Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ClassName")] Class @class)
        {
            if (ModelState.IsValid && db.Classes.Any(p => p.ClassName != @class.ClassName))
            {

                db.Classes.Add(@class);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {

                ModelState.AddModelError("CustomErrorofClass", "don't duplicate Class name");
            }

            return View(@class);
        }

        // GET Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        // POST Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ClassName")] Class @class)
        {
            if (ModelState.IsValid && db.Classes.Any(p => p.ClassName != @class.ClassName))
            {
                db.Entry(@class).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {

                ModelState.AddModelError("CustomErrorofClass2", "don't duplicate Class name");
            }



            return View(@class);
        }

        // GET Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        // POST Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Class @class = db.Classes.Find(id);
            db.Classes.Remove(@class);
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
