using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Emanproject.Models
{
    public class Class
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Required Enter Class Name!")]
        
        public string ClassName { get; set; }
        public List<Student>  Students { get; set; }
       
    }
}