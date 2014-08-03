using System;
using System.Collections.Generic;
using Software41.BackgroundCheck.Domain;

namespace Software41.BackgroundCheck.Repository
{
    public interface IApplicantRepository
    {
        IEnumerable<Applicant> GetApplicants();

        void Save(Applicant applicant);
    }
}
