using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Emanproject.Models
{
    public class SchoolDB : DbContext
        
    {
        //database
        public SchoolDB() : base("constr")  { }


        //table
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}