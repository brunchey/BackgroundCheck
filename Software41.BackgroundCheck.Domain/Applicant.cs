using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software41.BackgroundCheck.Domain
{
    public class Applicant
    {
        public int Id { get; set; }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String MiddleNamme { get; set; }

        public List<AddressHistory> AddressHistory { get; set; }

        public List<EducationHistory> EducationHistory { get; set; }


    }
}
