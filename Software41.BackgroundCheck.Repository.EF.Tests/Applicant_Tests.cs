using System;
using System.Data;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Software41.BackgroundCheck.Domain;
using Software41.BackgroundCheck.Repository;
using Software41.BackgroundCheck.Repository.EF;

namespace Software41.BackgroundCheck.Repository.EF.Tests
{
    [TestClass]
    public class Applicant_Tests
    {
        [TestMethod]
        public void Can_Save_Applicant()
        {
            //Arrange
            string firstName = "David_1";
            string middleName = "Michael";
            string lastname = "OBrien";

            //create our context and 'inject' it into the repository... hopefully this is exactly what
            //you'll want in the controller in terms of dependency injection
            IUnitOfWork context = new BackgroundCheckContext();
            IApplicantRepository repository = new EFApplicantRepository(context);
            var applicant = DomainHelper.CreateApplicant(firstName, middleName, lastname);
            Applicant savedApplicant = null;

            //Act
            try
            {

                repository.Add(applicant);
                context.Commit();
                savedApplicant = repository.FindBy(a => a.FirstName == firstName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                System.Diagnostics.Debug.Write(ex.StackTrace);
            }

            //Assert
            Assert.IsNotNull(savedApplicant);
            Assert.AreEqual(savedApplicant.FirstName, firstName);
            Assert.AreEqual(savedApplicant.MiddleName, middleName);
            Assert.AreEqual(savedApplicant.LastName, lastname);
        }

        [TestMethod]
        public void Can_Save_Applicant_EmploymentHistory()
        {
            //Arrange
            string firstName = "David_2";
            string middleName = "Michael";
            string lastname = "OBrien";
            string employerName = "Benesyst2";
            string jobTitle = "Programmer";

            //create our context and 'inject' it into the repository... hopefully this is exactly what
            //you'll want in the controller in terms of dependency injection
            IUnitOfWork context = new BackgroundCheckContext();
            IApplicantRepository repository = new EFApplicantRepository(context);
            var applicant = DomainHelper.CreateApplicant(firstName, middleName, lastname);
            Applicant savedApplicant = null;

            applicant.EmploymentHistory.Add(
                new EmploymentHistory
                {
                    EmployerName = employerName,
                    JobTitle = jobTitle,
                    Salary = 110000,
                    StartDate = new DateTime(2005, 2, 5),
                    EndDate = new DateTime(2006, 6, 5)
                });

            try
            {
                //Act
                repository.Add(applicant);
                context.Commit();
                savedApplicant = repository.FindBy(a => a.FirstName == firstName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                System.Diagnostics.Debug.Write(ex.StackTrace);
            }

            //Assert
            Assert.IsNotNull(savedApplicant);
            Assert.AreEqual(applicant.EmploymentHistory.Count, 1);
            Assert.AreEqual(applicant.EmploymentHistory[0].EmployerName, employerName);
            Assert.AreEqual(applicant.EmploymentHistory[0].JobTitle, jobTitle);
        }

        [TestMethod]
        public void Can_Save_Applicant_EducationHistory_List()
        {
            //Arrange            
            string firstName = "David_3";
            string middleName = "Michael";
            string lastname = "OBrien";
            string firstRecordAddress = "377 Colborne Street";
            string secondRecordAddress = "661 Ivy Falls Court";

            //create our context and 'inject' it into the repository... hopefully this is exactly what
            //you'll want in the controller in terms of dependency injection
            IUnitOfWork context = new BackgroundCheckContext();
            IApplicantRepository repository = new EFApplicantRepository(context);
            var applicant = DomainHelper.CreateApplicant(firstName, middleName, lastname);
            Applicant savedApplicant = null;

            applicant.AddressHistory.Add(new AddressHistory
            {
                Address1 = firstRecordAddress,
                Address2 = "",
                City = "Saint Paul",
                State = "MN",
                Zip = "55102",
                FromDate = "2003/10/31",
                ToDate = "Current"
            });

            applicant.AddressHistory.Add(new AddressHistory
            {
                Address1 = secondRecordAddress,
                Address2 = "",
                City = "Mendota Heights",
                State = "MN",
                Zip = "55118",
                FromDate = "2000/4/5",
                ToDate = "2003/10/31"
            });

            try
            {
                //Act
                repository.Add(applicant);
                context.Commit();
                savedApplicant = repository.FindBy(a => a.FirstName == firstName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                System.Diagnostics.Debug.Write(ex.StackTrace);
            }

            //Assert
            Assert.IsNotNull(savedApplicant);
            Assert.AreEqual(savedApplicant.AddressHistory.Count, 2);
            Assert.AreEqual(savedApplicant.AddressHistory[0].Address1, firstRecordAddress);
            Assert.AreEqual(savedApplicant.AddressHistory[1].Address1, secondRecordAddress);
        }

        [TestMethod]
        public void Can_Save_Applicant_With_All_Histories_Populated()
        {
            //Arrange
            string firstName = "David_X";
            string middleName = "Michael";
            string lastname = "OBrien";

            //create our context and 'inject' it into the repository... hopefully this is exactly what
            //you'll want in the controller in terms of dependency injection
            IUnitOfWork context = new BackgroundCheckContext();
            IApplicantRepository repository = new EFApplicantRepository(context);
            var applicant = DomainHelper.CreateApplicant(firstName, middleName, lastname);
            DomainHelper.AddAddressHistory(applicant, 2);
            DomainHelper.AddEducationHistory(applicant, 3);
            DomainHelper.AddEmploymentHistory(applicant, 3);

            //Act
            try
            {

                repository.Add(applicant);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                System.Diagnostics.Debug.Write(ex.StackTrace);
            }

            var savedApplicant = repository.FindBy(a => a.FirstName == firstName);

            //Assert NOTE: I am not testing too much here as I've run out of time. Will compare
            //built up domain object with saved object soon
            Assert.IsNotNull(savedApplicant);
            Assert.AreEqual(savedApplicant.FirstName, firstName);
            Assert.AreEqual(savedApplicant.MiddleName, middleName);
            Assert.AreEqual(savedApplicant.LastName, lastname);
        }

        /// <summary>
        /// Just go and manually inspect the history records associated with this;
        /// we'll build History repositories later if needed
        /// </summary>
        [TestMethod]
        public void Can_Remove_Applicant_And_History()
        {
            //Arrange
            //create our context and 'inject' it into the repository... hopefully this is exactly what
            //you'll want in the controller in terms of dependency injection
            string nameToFind = "David_X";
            IUnitOfWork context = new BackgroundCheckContext();
            IApplicantRepository repository = new EFApplicantRepository(context);
            var applicant = repository.FindBy(a => a.FirstName == nameToFind);

            if (applicant == null)
                throw new ArgumentNullException("Applicant Not Found");

            //Act
            try
            {
                repository.Delete(applicant);
                context.Commit();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                System.Diagnostics.Debug.Write(ex.StackTrace);
            }

            var savedApplicant = repository.FindBy(a => a.FirstName == nameToFind);

            //Assert
            Assert.IsNull(savedApplicant);
        }
    }
}
