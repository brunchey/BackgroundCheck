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
        private IUnitOfWork unitOfWork;
        
        public ApplicantController (IApplicantRepository applicantRepo, IUnitOfWork unitOfWork)
        {
            this.appRepo = applicantRepo;
            this.unitOfWork = unitOfWork;

        }
    
        //
        // GET: /Applicant/
        public ActionResult Index()
        {
            var applicants = this.appRepo.GetAll();
            return View(applicants);
        }

        public ActionResult Applicant(int Id)
        {
            return View(this.appRepo.FindById(Id));
        }

        [HttpPost]
        public ActionResult Applicant(Applicant applicant)
        {
            this.appRepo.Save(applicant);
            this.unitOfWork.Commit();
            return RedirectToAction("Index");
        }
    }
}