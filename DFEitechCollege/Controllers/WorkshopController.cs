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
        WorkshopGenie genie = new WorkshopGenie();

        public ActionResult CreateWorkshop(int courseId, int year, int teacherId)
        {
            return View(genie.InsertWorkshop(courseId, year, teacherId));
        }

        public ActionResult ListWorkshops()
        {
            return View(genie.ListWorkshops());
        }

        public ActionResult DeleteWorkshop(int id = 0) //potential workshop_student floater entries
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