using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DFEitechCollege.Models;

namespace DFEitechCollege.Controllers
{
    public class SubjectController : Controller
    {
        SubjectGenie genie = new SubjectGenie();

        public ActionResult DeleteSubject(int id=0)
        {
            return View(genie.DeleteSubject(id));
        }

        public ActionResult ListSubjects()
        {
            return View(genie.ListSubjects());
        }

        public ActionResult CreateSubject(string name="*empty", Boolean higher=false)
        {
            return View(genie.InsertSubject(name, higher));            
        }

        public ActionResult UpdateSubject(int id, string name, Boolean higher1=false)
        {
            return View(genie.UpdateSubject(id, name, higher1));
        }

        public ActionResult _ToolSubjects()
        {
            var model = new Subject();
            return View(model);
        }
    }
}