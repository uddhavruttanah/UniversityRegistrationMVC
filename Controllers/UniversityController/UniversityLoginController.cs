using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusinessLayer;
using BusinessLayer.UniversityAdmin;
using BusinessLayer.UniversityStudent;
using BusinessLayer.UniversityUser;
using DAL.Model;

namespace UniversityRegistrationMVC.Controllers
{
    public class UniversityLoginController : Controller
    {
        public IUniversityUserBL universityUserBL;
        public UniversityLoginController()
        {
            universityUserBL = new UniversityUserBL();
        }
        public UniversityLoginController(IUniversityUserBL universityUserBL)
        {
            this.universityUserBL = universityUserBL;
        }
        public ActionResult UniversityLogin()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult UniversityLogin(UniversityUserData universityUserData)
        //{
        //  var userIsValid = UniversityUserBL.AuthenticateUser(universityUserData);
        //    if (userIsValid) {
        //        bool checkAdmin = UniversityUserBL.CheckAdminRole(universityUserData);
        //        if (checkAdmin) {
        //            return Json(new { result = userIsValid, url = Url.Action("UniversityAdmin", "UniversityAdmin") });
        //        } 
        //        return Json(new { result = userIsValid, url = Url.Action("UniversitySuccessfulLogin", "UniversitySuccessfulLogin") });
        //    }
        //    else
        //    {
        //        return Json(new { result = userIsValid, });
        //    }  
        //}
        [HttpPost]
        public ActionResult UniversityLogin(UniversityUserData universityUserData)
        {
            var results = universityUserBL.AuthenticateUser(universityUserData);
            List<string> errMessages = new List<string>();
            if (results.Count > 0)
            {
                for (var i = 0; i < results.Count; i++)
                {
                    errMessages.Add(results[i].ErrorMessage);
                }



            }
            else
            {
                bool checkAdmin = universityUserBL.CheckAdminRole(universityUserData);
                if (checkAdmin)
                {
                    return Json(new
                    {
                        data = results,
                        hasErrors = results.Any(),
                        ErrorMessage = errMessages,
                        url =  Url.Action("UniversityAdmin", "UniversityAdmin")
                    },
                JsonRequestBehavior.AllowGet);
                }

            }



            return Json(new
            {
                data = results,
                hasErrors = results.Any(),
                ErrorMessage = errMessages,
                url = errMessages.Count > 0 ? "" : Url.Action("UniversitySuccessfulLogin", "UniversitySuccessfulLogin")
                //url = Url.Action("UniversitySuccessfulLogin", "UniversitySuccessfulLogin")
            },
                JsonRequestBehavior.AllowGet);
        }
        public ActionResult UniversitySignup()
        {
            return Json(new {url = Url.Action("UniversityRegistration", "UniversityStudent") });
        }
    }
}