using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software41.BackgroundCheck.Domain
{
    public class Applicant
    {
        public Applicant()
        {
            this.EmploymentHistory = new List<EmploymentHistory>();
            this.AddressHistory = new List<AddressHistory>();
            this.EducationHistory = new List<EducationHistory>();
        }
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String MiddleName { get; set; }
        public virtual List<AddressHistory> AddressHistory { get; set; }
        public virtual List<EducationHistory> EducationHistory { get; set; }
        public virtual List<EmploymentHistory> EmploymentHistory { get; set; }
    }
}
