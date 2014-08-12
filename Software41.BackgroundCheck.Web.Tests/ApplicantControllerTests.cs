using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Software41.BackgroundCheck.Web.Controllers;
using Software41.BackgroundCheck.Repository;
using Software41.BackgroundCheck.Domain;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq.Expressions;

namespace Software41.BackgroundCheck.Web.Tests
{
    [TestClass]
    public class ApplicantControllerTests
    {
        [TestMethod]
        public void GetIndex_ExpectSuccess()
        {
            //arrange
            var mockApplicantRepo = new Mock<IApplicantRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var applicantList  = new List<Applicant>()
            {
                new Applicant { Id = 1, FirstName = "Ben", LastName = "Runchey", MiddleName = "John"},
                new Applicant { Id =2, FirstName = "David", LastName = "O'Brien", MiddleName = "Something Irish?"}
            };

            mockApplicantRepo.Setup(m => m.GetAll()).Returns(applicantList);
            var appController = new ApplicantController(mockApplicantRepo.Object, mockUnitOfWork.Object);

            //act
            var result = appController.Index() as ViewResult;

            // Assert 
            Assert.IsNotNull(result, "Should have returned a ViewResult");
            Assert.AreEqual("", result.ViewName, "View name should have been blank"); 

            var applicants = result.ViewData.Model;
            Assert.AreSame(applicantList, applicants);

        }

        [TestMethod]
        public void GetApplicant_ExpectSuccess()
        {
            //arrange
            var mockApplicantRepo = new Mock<IApplicantRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var expectedApplicant = new Applicant { Id = 1, FirstName = "Ben", LastName = "Runchey", MiddleName = "John"};

            mockApplicantRepo.Setup(m => m.FindById(It.IsAny<int>())).Returns(expectedApplicant);
            var appController = new ApplicantController(mockApplicantRepo.Object, mockUnitOfWork.Object);

            //act
            var result = appController.Applicant(1) as ViewResult;

            //Assert
            var applicant = result.ViewData.Model;
            Assert.AreSame(expectedApplicant, applicant);

        }

        [TestMethod]
        public void GetApplicant_DoesNotExist_ExpectSuccess()
        {
            //arrange
            var mockApplicantRepo = new Mock<IApplicantRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            Applicant nullApplicant = null;
            mockApplicantRepo.Setup(m => m.FindById(It.IsAny<int>())).Returns(nullApplicant);
            var appController = new ApplicantController(mockApplicantRepo.Object, mockUnitOfWork.Object);

            //act
            var result = appController.Applicant(1) as ViewResult;

            //Assert
            var applicant = result.ViewData.Model;
            Assert.IsNull(applicant);
        }

        [TestMethod]
        public void TestPostApplicant_ExpectSuccess()
        {
            //arrange
            var mockApplicantRepo = new Mock<IApplicantRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockApplicantRepo.Setup(m => m.Save(It.IsAny<Applicant>()));
            var appController = new ApplicantController(mockApplicantRepo.Object, mockUnitOfWork.Object);

            //act
            var applicantToUpdate = new Applicant(){Id=2, FirstName="George", LastName="McFly", MiddleName="X"};
            var result = appController.Applicant(applicantToUpdate) as RedirectToRouteResult;

            //assert
            Assert.AreEqual("Index", result.RouteValues["action"]);

        }

        [TestMethod, Ignore]
        public void TestPostApplicant_DoesNotExist_ExpectException()
        {

        }
    }
}
