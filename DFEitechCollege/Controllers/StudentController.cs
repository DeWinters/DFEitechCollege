using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DFEitechCollege.Models;

namespace DFEitechCollege.Controllers
{
    public class StudentController : Controller
    {
        StudentGenie genie = new StudentGenie();

        public ActionResult DeleteStudent(int id = 0) //student
        {
            return View(genie.DeleteStudent(id));
        }

        public ActionResult ListStudents()
        {
            return View(genie.ListStudents());
        }

        public ActionResult CreateStudent(string fname = "*empty", string lname = "*empty")
        {
            return View(genie.InsertStudent(fname, lname));
        }

        public ActionResult UpdateStudent(int id, string fname, string lname)
        {
            return View(genie.UpdateStudent(id, fname, lname));
        }

        public ActionResult _ToolStudents()
        {
            return View();
        }
    }
}