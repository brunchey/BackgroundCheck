using System;
using System.Collections.Generic;
using Software41.BackgroundCheck.Domain;

namespace Software41.BackgroundCheck.Repository
{
    interface IApplicantRepository
    {
        public IEnumerable<Applicant> GetApplicants();

        public void Save(Applicant applicant);
    }
}
