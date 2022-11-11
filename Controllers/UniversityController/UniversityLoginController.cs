using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DAL.Model;

namespace UniversityRegistrationMVC.Controllers
{
    public class UniversityLoginController : Controller
    {
        DBContext dbContext = new DBContext();
        //public ActionResult UniversityLogin()
        //{
        //    return View();
        //}
        public ActionResult UniversityLogin()
        {
            return View();
        }
        //[HttpGet]
        //public ActionResult UniversityLogin(UniversityUserData universityUserData, DBContext dBContext)
        //{
        //    var data = dBContext.GetUniversityUser();
        //    return View(data.ToList());
        //}
        [HttpPost]
        public ActionResult UniversityLogin(UniversityUserData universityUserData)
        {
            bool userIsValid = true;
            if (userIsValid)
            {
                
            }
            //return Json(new { JsonRequestBehavior.AllowGet });
            return Json(new { result = userIsValid, url = Url.Action("UniversitySuccessfulLogin", "UniversitySuccessfulLogin") });

        }
    }
}