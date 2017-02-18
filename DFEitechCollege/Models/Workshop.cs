using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DFEitechCollege.Models
{
    public class Workshop
    {
        public int WorkshopId { get; set; }
        public int Year { get; set; }
        public Subject Course { get; set; }
        public Teacher Instructor { get; set; }
        public List<Student> Students { get; set; }
    }
}