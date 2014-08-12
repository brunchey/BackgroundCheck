using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Software41.BackgroundCheck.Repository;
using Software41.BackgroundCheck.Domain;

namespace Software41.BackgroundCheck.Web.TestingFakes
{
    public class FakeApplicantRepository : IApplicantRepository
    {
        private static List<Applicant> applicants = new List<Applicant>()
            {
                new Applicant { Id = 1, FirstName = "Ben", LastName = "Runchey", MiddleName = "John"},
                new Applicant { Id =2, FirstName = "David", LastName = "O'Brien", MiddleName = "Something Irish?"}
            };

        public List<Applicant> GetAll()
        {
            return applicants;
        }

        public void Save(Applicant applicant)
        {
            applicants[applicants.FindIndex(a => a.Id == applicant.Id)] = applicant;
        }


        public Applicant FindBy(System.Linq.Expressions.Expression<Func<Applicant, bool>> predicate)
        {
            return applicants.AsQueryable().Where(predicate).FirstOrDefault();
        }

        public void Add(Applicant applicant)
        {
            throw new NotImplementedException();
        }

        public void Update(Applicant applicant)
        {
            throw new NotImplementedException();
        }

        public void Delete(Applicant applicant)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Applicant> IApplicantRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Applicant> IApplicantRepository.FindBy(System.Linq.Expressions.Expression<Func<Applicant, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Applicant FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}