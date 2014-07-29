using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software41.BackgroundCheck.Domain
{
    public class EmploymentHistory
    {
        public String EmployerName { get; set; }
        public String JobTitle { get; set; }
        public Double Salary { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
