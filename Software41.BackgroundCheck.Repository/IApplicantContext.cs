using System;
using System.Data.Entity;
using Software41.BackgroundCheck.Domain;

namespace Software41.BackgroundCheck.Repository
{
    public interface IApplicantContext
    {
        IDbSet<Applicant> Applicant {get;}
        IDbSet<AddressHistory> AddressHistory { get;}
        IDbSet<EmploymentHistory> EmploymentHistory { get;}
        IDbSet<EducationHistory> EducationHistory { get;}
    }
}
