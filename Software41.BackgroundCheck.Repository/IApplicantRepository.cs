using System;
using System.Collections.Generic;
using System.Linq;
using Software41.BackgroundCheck.Domain;

namespace Software41.BackgroundCheck.Repository
{
    public interface IApplicantRepository
    {
        IEnumerable<Applicant> GetAll();
        IEnumerable<Applicant> FindBy(System.Linq.Expressions.Expression<Func<Applicant, bool>> predicate);
        Applicant FindById(int id);
        void Save(Applicant applicant);
        void Delete(Applicant applicant);
    }
}
