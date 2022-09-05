using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Emanproject.Models
{
    public class Country
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Required Enter Country Name!")]
        public string CountryName { get; set; }
        public List<Student> Students { get; set; }
    }
}