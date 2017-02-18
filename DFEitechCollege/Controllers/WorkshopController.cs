using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DFEitechCollege.Models;

namespace DFEitechCollege.Controllers
{
    public class WorkshopController : Controller
    {
        MySQLgenie genie = new MySQLgenie();

        public ActionResult CreateWorkshop(int courseId, int year, int teacherId)
        {
            return View(genie.InsertWorkshop(courseId, year, teacherId));
        }

        public ActionResult ListWorkshops()
        {
            return View(genie.ListWorkshops());
        }

        public ActionResult DeleteWorkshop(int id = 0) //student
        {
            return View(genie.DeleteWorkshop(id));
        }

        public ActionResult UpdateWorkshop(int workshopId, int courseId, int year, int teacherId)
        {
            return View(genie.UpdateWorkshop(workshopId, courseId, year, teacherId));
        }

        public ActionResult _ToolWorkshops()
        {
            return View();
        }
    }
}