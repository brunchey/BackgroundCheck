using Software41.BackgroundCheck.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Software41.BackgroundCheck.Repository;

namespace Software41.BackgroundCheck.Web.Controllers
{
    public class ApplicantController : Controller
    {

        private IApplicantRepository appRepo;
        
        public ApplicantController (IApplicantRepository applicantRepo)
        {
            appRepo = applicantRepo;

        }
    
        //
        // GET: /Applicant/
        public ActionResult Index()
        {
            var applicants = appRepo.GetApplicants();
            return View(applicants);
        }

        public ActionResult Applicant(int Id)
        {
            return View(this.appRepo.GetApplicants().Where(a => a.Id == Id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Applicant(Applicant applicant)
        {
            this.appRepo.Save(applicant);
            return RedirectToAction("Index");
        }


    }
}