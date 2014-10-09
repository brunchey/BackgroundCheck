using Software41.BackgroundCheck.Domain;
using Software41.BackgroundCheck.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Software41.BackgroundCheck.Web.Api
{
    public class ApplicantController : ApiController
    {

        private IApplicantRepository appRepo;
        private IUnitOfWork unitOfWork;

        public ApplicantController(IApplicantRepository appRepo, IUnitOfWork unitOfWork)
        {
            this.appRepo = appRepo;
            this.unitOfWork = unitOfWork;
        }

        
        // GET api/<controller>
        [Route("applicant")]
        [HttpGet]
        public IEnumerable<Applicant> GetAll()
        {
            return appRepo.GetAll();
        }

        // GET api/<controller>/5
        [Route("applicant/{id}")]
        [HttpGet]
        public Applicant Get(int id)
        {
            return appRepo.FindById(id);
        }

        // POST <controller>
        [Route("applicant")]
        [HttpPost]
        public void Create(Applicant applicant)
        {
            this.appRepo.Save(applicant);
            this.unitOfWork.Commit();
            HttpContext.Current.Response.AddHeader("Location", "applicant/" + applicant.Id);
        }

        [Route("applicant/{id}")]
        [HttpPut]
        public void Update(int id, Applicant applicant)
        {
            this.appRepo.Save(applicant);
            this.unitOfWork.Commit();
        }

    }
}