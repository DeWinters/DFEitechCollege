using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DFEitechCollege.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject
        public ActionResult OpenSubjects()
        {
            return View();
        }
    }
}