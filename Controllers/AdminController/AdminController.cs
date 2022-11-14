using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityRegistrationMVC.Controllers.AdminController
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult UniversityAdmin()
        {
            return View();
        }
        public JsonResult StudentData()
        {
            return Json();
        }
    }
}