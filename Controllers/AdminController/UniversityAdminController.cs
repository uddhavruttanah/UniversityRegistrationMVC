using BusinessLayer.UniversityAdmin;
using BusinessLayer.UniversityStudent;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityRegistrationMVC.Controllers.AdminController
{
    public class UniversityAdminController : Controller
    {
        public IUniversityAdminBL universityAdminBL;
        public UniversityAdminController()
        {
            this.universityAdminBL = new UniversityAdminBL();
        }
        [HttpGet]
        public ActionResult UniversityAdminGetrecords()
        {
           var students =  universityAdminBL.GetStudents();
            return Json(new { students }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult UniversityAdmin()
        {
            var students = universityAdminBL.GetStudents();
            return View(universityAdminBL);
        }
    }
}