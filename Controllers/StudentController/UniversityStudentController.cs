using BusinessLayer.UniversityAdmin;
using BusinessLayer.UniversityStudent;
using DAL.Model;
using System.Security.Policy;
using System.Web.Mvc;

namespace UniversityRegistrationMVC.Controllers.StudentController
{
    public class UniversityStudentController : Controller
    {
        public IUniversityUserBL universityStudentBL;
        public IHscSubjectsBL hscSubjectsBL;
        public UniversityStudentController()
        {
            this.universityStudentBL = new UniversityStudentBL();
            this.hscSubjectsBL = new HscSubjectsBL();
        }
        public UniversityStudentController(IUniversityUserBL universityStudentBL, IHscSubjectsBL hscSubjectsBL)
        {
            this.universityStudentBL = universityStudentBL;
            this.hscSubjectsBL = hscSubjectsBL;
        }
        [HttpGet]
        public ActionResult GetSubjects()
        {
            var subjectDatas = hscSubjectsBL.GetSubjects();
            return Json(new { subjectDatas }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UniversityRegistration()
        {
            return View(hscSubjectsBL);
        }
        [HttpPost]
        public ActionResult AddStudent(UniversityUserData usermodel, UniversityStudentData studentmodel)
        {
            universityStudentBL.AddStudent(usermodel, studentmodel);
            return Json(new { url = Url.Action("UniversityLogin", "UniversityLogin") });
        }    
    }
}