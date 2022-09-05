using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Emanproject.Models
{
    public class Student
    {
       
        public int ID { get; set; }
        [Required(ErrorMessage = "Required Enter Name!")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Required(ErrorMessage = "Required Choose Birth!")]
        public DateTime Date_of_birith { get; set; }
        [Required(ErrorMessage = "Required Select Class!")]
        public int ClassID { get; set; }
        public virtual Class Class { get; set; }
        [Required(ErrorMessage = "Required Select Country!")]
        public int CountryID { get; set; }

        
        public virtual Country Country { get; set; }


    }
}