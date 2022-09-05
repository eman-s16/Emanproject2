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
    public class StudentsController : Controller
    {
        private SchoolDB db = new SchoolDB();

        //index of student
        public ActionResult Index()
        {

            var students = db.Students.Include(s => s.Class).Include(s => s.Country);
            return View(students.ToList());
        }



        // GET: Create
        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "ClassName");

            ViewBag.CountryID = new SelectList(db.Countries, "ID", "CountryName");
            return View();
        }

        // POST: Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Date_of_birith,ClassID,CountryID")] Student student)
        {
            if (ModelState.IsValid && db.Students.Any(p => p.Name != student.Name))
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {

                ModelState.AddModelError("CustomErrorOfName", "Don't Duplicate Name of Student");
            }


            ViewBag.ClassID = new SelectList(db.Classes, "ID", "ClassName", student.ClassID);
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "CountryName", student.CountryID);
            return View(student);
        }

        // GET Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "ClassName", student.ClassID);
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "CountryName", student.CountryID);
            return View(student);
        }

        // POST Edit 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Date_of_birith,ClassID,CountryID")] Student student)
        {
            if (ModelState.IsValid && db.Students.Any(p => p.Name != student.Name))
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                ModelState.AddModelError("CustomErrorOfName2", "Don't Duplicate Name of Student");


            }

            ViewBag.ClassID = new SelectList(db.Classes, "ID", "ClassName", student.ClassID);
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "CountryName", student.CountryID);
            return View(student);
        }

        // GET Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
