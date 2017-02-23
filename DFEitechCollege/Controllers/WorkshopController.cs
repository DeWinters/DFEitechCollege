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

        [HttpPost]
        public ActionResult ListWorkshops()
        {
            return View(genie.ListWorkshops());
        }

        public ActionResult DeleteWorkshop(int id = 0) //potential workshop_student floater entries
        {
            return View(genie.DeleteWorkshop(id));
        }

        public ActionResult UpdateWorkshop(int workshopId=0, int courseId=0, int year=0, int teacherId=0)
        {
            if (year == 0) { year = DateTime.Now.Year; }
            return View(genie.UpdateWorkshop(workshopId, courseId, year, teacherId));
        }

        [HttpPost]
        public ActionResult _ToolWorkshops()
        {
            return View();
        }

        public ActionResult InsertWorkshopStudent(int workshopId, int studentId)
        {            
            return View(genie.InsertWorkshopStudent(workshopId, studentId));
        }
        
    }
}