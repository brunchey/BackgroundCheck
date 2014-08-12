using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Software41.BackgroundCheck.Repository;
using Software41.BackgroundCheck.Domain;

namespace Software41.BackgroundCheck.Repository.EF
{
    public class EFApplicantRepository:IApplicantRepository
    {
        private BackgroundCheckContext _context;

        /// <summary>
        /// We can probably get rid of this but I left it for now
        /// </summary>
        public EFApplicantRepository(IUnitOfWork context)
        {
            this._context = (BackgroundCheckContext) context;
        }
        public IEnumerable<Applicant> GetAll()
        {
            return this._context.Set<Applicant>();
        }
        public IEnumerable<Applicant> FindBy(System.Linq.Expressions.Expression<Func<Applicant, bool>> predicate)
        {
            return this._context.Set<Applicant>().Where(predicate) as IEnumerable<Applicant>;
        }
        public Applicant FindById(int id)
        {
            return this._context.Set<Applicant>().Where(a => a.Id == id).FirstOrDefault();
        }
        public void Save(Applicant applicant)
        {
            bool applicantIsNew = (applicant.Id == null || applicant.Id == 0) ? true:false;
            if (applicantIsNew)
            {
                this._context.Set<Applicant>().Add(applicant);
            }
            else
            {
                this._context.Entry(applicant).State = EntityState.Modified;
            }
        }
        public void Delete(Applicant applicant)
        {
            this._context.Set<Applicant>().Remove(applicant);
        }
    }
}
