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
                new Applicant { Id = 1, FirstName = "Ben", LastName = "Runchey", MiddleNamme = "John"},
                new Applicant { Id =2, FirstName = "David", LastName = "O'Brien", MiddleNamme = "Something Irish?"}
            };

        public IEnumerable<Applicant> GetApplicants()
        {
            return applicants;
        }

        public void Save(Applicant applicant)
        {
            applicants[applicants.FindIndex(a => a.Id == applicant.Id)] = applicant;
        }

    }
}