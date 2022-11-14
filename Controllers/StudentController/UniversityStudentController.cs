using BusinessLayer.UniversityStudent;
using DAL.Model;
using System.Web.Mvc;

namespace UniversityRegistrationMVC.Controllers.StudentController
{
    public class UniversityStudentController : Controller
    {
        public IUniversityUserBL universityStudentBL;
        public UniversityStudentController()
        {
            this.universityStudentBL = new UniversityStudentBL();
        }
        public UniversityStudentController(IUniversityUserBL universityStudentBL)
        {
            this.universityStudentBL = universityStudentBL;
        }
        [HttpGet]
        public ActionResult UniversityRegistration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(UniversityUserData usermodel, UniversityStudentData studentmodel)
        {
            universityStudentBL.AddStudent(usermodel, studentmodel);
            return Json(new { url = Url.Action("UniversityLogin", "UniversityLogin") });
        }
        //[HttpPost]
        //public ActionResult AddStudentDetails(UniversityStudentData model)
        //{
        //    universityStudentBL.AddStudentDetails(model);
        //    return Json(new { url = Url.Action("UniversityLogin", "UniversityLogin") });
        //}
    }
}