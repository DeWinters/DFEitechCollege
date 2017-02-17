using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DFEitechCollege.Models;
using MySql.Data.MySqlClient;

namespace DFEitechCollege.Controllers
{
    public class SubjectController : Controller
    {
        MySQLgenie genie = new MySQLgenie();

        public ActionResult DeleteSubject(int id=0)
        {
            return View(genie.DeleteSubject(id));
        }

        public ActionResult ListSubjects()
        {
            return View(genie.ListSubjects());
        }

        public ActionResult CreateSubject(string name="*empty", Boolean higher=false )
        {
            return View(genie.InsertSubject(name, higher));            
        }

        public ActionResult UpdateSubject(int id, string name, Boolean higher=false)
        {
            return View(genie.UpdateSubject(id, name, higher));
        }

        public ActionResult _ToolSubjects()
        {
            return View();
        }
    }
}