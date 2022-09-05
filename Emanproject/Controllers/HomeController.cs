using Emanproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emanproject.Controllers
{
    public class HomeController : Controller
    {
        private SchoolDB db = new SchoolDB();
        public ActionResult Index()
        {
            ViewBag.CountClass = db.Classes.Count();
            ViewBag.CountStudents = db.Students.Count();
            ViewBag.CountCountries = db.Countries.Count();

            return View();
        }

        public ActionResult Statistics()
        {
            //Count of students per class
            ViewBag.studentsPerClass = db.Students.GroupBy(p => p.Class.ClassName)
                    .Select(g => new ClassViewModel { Name = g.Key, Count = g.Count() });


            //Count of students per countery
            ViewBag.studentsPerCountry = db.Students.GroupBy(p => p.Country.CountryName)
                   .Select(g => new CountryViewModel { Name = g.Key, Count = g.Count() });


            //average age of students 
            var birth = db.Students.Select(m => m.Date_of_birith).ToList();

            var listOfBirth = new List<int>();
            var result = 0;
            var count = 0;


            //loop of birth list
            foreach (var item in birth)
            {

                int age = (int)((DateTime.Now - item).TotalDays / 365.242199);
                listOfBirth.Add(age);

            }


            //loop of age list
            foreach (var item in listOfBirth)
            {
                result += item;
                count +=1;
            }
                ViewBag.AverageAgeOfStudents = (result / count);
            
            return View();
        }
        public class CountryViewModel
        {
            public string Name { get; set; }
            public int Count { get; set; }
        }
        public class ClassViewModel
        {
            public string Name { get; set; }
            public int Count { get; set; }
        }

        
    }
}