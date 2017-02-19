using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DFEitechCollege.Models;

namespace DFEitechCollege.Controllers
{
    public class TeacherController : Controller
    {
        TeacherGenie genie = new TeacherGenie();

        public ActionResult DeleteTeacher(int id = 0)
        {
            return View(genie.DeleteTeacher(id));
        }

        public ActionResult ListTeachers()
        {
            return View(genie.ListTeachers());
        }

        public ActionResult CreateTeacher(string fname = "*empty", string lname = "*empty")
        {
            return View(genie.InsertTeacher(fname, lname));
        }

        public ActionResult UpdateTeacher(int id, string fname, string lname)
        {
            return View(genie.UpdateTeacher(id, fname, lname));
        }

        public ActionResult _ToolTeachers()
        {
            return View();
        }
    }
}