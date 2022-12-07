using BusinessLayer.UniversityStudent;
using DAL.Model;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult AddStudent(UniversityUserData usermodel, UniversityStudentData studentmodel, GradesData gradesmodel, SubjectData subjectmodel)
        {
            var results = universityStudentBL.AddStudent(usermodel, studentmodel, gradesmodel, subjectmodel);
            List<string> errMessages = new List<string>();
            if (results.Count > 0)
            {
                for (var i=0; i< results.Count; i++) {
                    errMessages.Add(results[i].ErrorMessage);
                }
            }
            return Json(new 
            {   
                data = results, 
                hasErrors = results.Any(),
                ErrorMessage = errMessages,
                url = Url.Action("UniversityLogin", "UniversityLogin") 
            },
                JsonRequestBehavior.AllowGet);
        }    
    }
}