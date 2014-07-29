using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software41.BackgroundCheck.Domain
{
    public class EducationHistory
    {
        public String SchoolName { get; set; }
        public SchoolType SchoolType { get; set; }
        public DateTime AttendedFrom { get; set; }
        public DateTime AttendedTo { get; set; }
        public bool Graduated { get; set; }
        public DegreeType DegreeType { get; set; }

    }
}
