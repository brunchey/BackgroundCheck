using System;
using System.Collections;
using Software41.BackgroundCheck.Domain;

namespace Software41.BackgroundCheck.Repository.EF.Tests
{
    public static class DomainHelper
    {
        #region Private Convenience Methods
        public static Applicant CreateApplicant(string firstName,string middleName,string lastName)
        {
            return new Applicant
            {
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName
            };
        }

        public static void AddEmploymentHistory(Applicant applicant,int numRecords)
        {
            for (int i = 1; i <= numRecords;i++ )
            {
                applicant.EmploymentHistory.Add(
                new EmploymentHistory
                {
                    EmployerName = "Benesyst_" + i.ToString(),
                    JobTitle = "Programmer_" + i.ToString(),
                    Salary = 90000 * i,
                    StartDate = new DateTime(2005, 2, 5),
                    EndDate = new DateTime(2006, 6, 5)
                });
            }
        }

        public static void AddEducationHistory(Applicant applicant,int numRecords)
        {
            if (numRecords > 5)
                throw new ArgumentException("Who do you think you are, Einstein?");

            int attendedSeed = 1980;
            for(int i=1;i<=numRecords;i++)
            {
                applicant.EducationHistory.Add(new EducationHistory
                {
                    SchoolName = "School_" + i.ToString(),
                    SchoolType = GetSchoolType(i),
                    DegreeType = GetDegreeType(i),
                    Graduated = true,
                    AttendedFrom = new DateTime(attendedSeed +i,8,30),
                    AttendedTo = new DateTime(attendedSeed + (i+1),6,15)
                });
            }
        }

        public static void AddAddressHistory(Applicant applicant, int numRecords)
        {
            for (int i = 1; i <= numRecords;i++)
            {
                applicant.AddressHistory.Add(new AddressHistory
                {
                    Address1 = "123" + i.ToString() + " Main Street",
                    Address2 = "",
                    City = "Mendota Heights",
                    State = "MN",
                    Zip = "55118",
                    FromDate = "200" + i.ToString() + "/4/4",
                    ToDate = "200" + i+1.ToString() + "/4/4",
                });
            }
        }

        private static SchoolType GetSchoolType(int seed)
        {
            SchoolType retType;

            switch(seed)
            {
                case 1:
                    retType = SchoolType.HighSchool;
                    break;
                case 2:
                    retType = SchoolType.TechnicalSchool;
                    break;
                case 3:
                case 4:
                case 5:
                    retType = SchoolType.University;
                    break;
                default:
                    retType = SchoolType.HighSchool;
                    break;
            }
            return retType;
        }

        private static DegreeType GetDegreeType(int seed)
        {
             DegreeType retType;

            switch(seed)
            {
                case 1:
                    retType = DegreeType.HighSchoolDiploma;
                    break;
                case 2:
                    retType = DegreeType.AssociateOfArts;
                    break;
                case 3:
                    retType = DegreeType.BachelorOfArts;
                    break;
                case 4:
                    retType = DegreeType.Masters;
                    break;
                case 5:
                    retType = DegreeType.Phd;
                    break;
                default:
                    retType = DegreeType.HighSchoolDiploma;
                    break;
            }
            return retType;
        }
        #endregion
    }
}
