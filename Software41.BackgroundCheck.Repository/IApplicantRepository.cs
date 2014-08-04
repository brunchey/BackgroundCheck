using System;
using System.Collections.Generic;
using System.Linq;
using Software41.BackgroundCheck.Domain;

namespace Software41.BackgroundCheck.Repository
{
    public interface IApplicantRepository
    {
        List<Applicant> GetAll();
        Applicant FindBy(System.Linq.Expressions.Expression<Func<Applicant, bool>> predicate);
        void Add(Applicant applicant);
        void Update(Applicant applicant);
        void Delete(Applicant applicant);
    }
}
