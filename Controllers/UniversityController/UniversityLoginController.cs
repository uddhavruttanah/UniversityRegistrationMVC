using System;
using System.Web.Mvc;
using BusinessLayer;
using BusinessLayer.UniversityAdmin;
using BusinessLayer.UniversityUser;
using DAL.Model;

namespace UniversityRegistrationMVC.Controllers
{
    public class UniversityLoginController : Controller
    {
        public IUniversityUserBL UniversityUserBL;
        public UniversityLoginController()
        {
            UniversityUserBL = new UniversityUserBL();
        }
        public UniversityLoginController(IUniversityUserBL universityUserBL)
        {
            UniversityUserBL = universityUserBL;
        }
        public ActionResult UniversityLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UniversityLogin(UniversityUserData universityUserData)
        {
            bool userIsValid = UniversityUserBL.AuthenticateUser(universityUserData);
            bool checkAdmin = UniversityUserBL.CheckAdminRole(universityUserData);
            if (checkAdmin)
                return Json(new { result = userIsValid, url = Url.Action("UniversityAdmin", "UniversityAdmin") });
            return Json(new { result = userIsValid, url = Url.Action("UniversitySuccessfulLogin", "UniversitySuccessfulLogin") });
        }
        public ActionResult UniversitySignup()
        {
            return Json(new {url = Url.Action("UniversityRegistration", "UniversityStudent") });
        }
    }
}