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
        public EFApplicantRepository()
        {
            this._context = new BackgroundCheckContext();
        }

        public EFApplicantRepository(IApplicantContext context)
        {
            this._context = (BackgroundCheckContext)context;
        }

        public List<Applicant> GetAll()
        {
            return this._context.Set<Applicant>().ToList();
        }
        public Applicant FindBy(System.Linq.Expressions.Expression<Func<Applicant, bool>> predicate)
        {
            return this._context.Set<Applicant>().Where(predicate).FirstOrDefault();
        }
        public void Add(Applicant applicant)
        {
            this._context.Set<Applicant>().Add(applicant);
            this._context.SaveChanges();
        }
        public void Update(Applicant applicant)
        {
            this._context.Entry(applicant).State = EntityState.Modified;
            this._context.SaveChanges();
        }
        public void Delete(Applicant applicant)
        {
            this._context.Set<Applicant>().Remove(applicant);
            this._context.SaveChanges();
        }
    }
}
