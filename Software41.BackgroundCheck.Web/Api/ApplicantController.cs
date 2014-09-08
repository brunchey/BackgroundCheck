using Software41.BackgroundCheck.Domain;
using Software41.BackgroundCheck.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public IEnumerable<Applicant> Get()
        {
            return appRepo.GetAll();
        }

        // GET api/<controller>/5
        public Applicant Get(int id)
        {
            return appRepo.FindById(id);
        }

        // POST api/<controller>
        public void Post([FromBody] Applicant applicant)
        {
            this.appRepo.Save(applicant);
            this.unitOfWork.Commit();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] Applicant applicant)
        {
            this.appRepo.Save(applicant);
            this.unitOfWork.Commit();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var applicant = this.appRepo.FindById(id);
            if (applicant != null)
            {
                this.appRepo.Delete(applicant);
                this.unitOfWork.Commit();
            }
            
        }
    }
}