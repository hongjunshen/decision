using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecisionWebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DecisionWebAPI.Models;
using DecisionWebAPI.Repository;
using Moq;
using System.Web.Http.Results;

namespace DecisionWebAPI.Tests.Controllers
{
    [TestClass]
    public class ApplicantControllerTest
    {
        [TestMethod]
        public void TestGetApplicants()
        {
            List<Applicant> applicantList = new List<Applicant>();
            var applicant1 = new Applicant {Id=1, FirstName = "john", LastName = "papa", DOB = DateTime.Parse("1988/01/01"), GPA = 3.9m };
            var applicant2 = new Applicant {Id=2, FirstName = "ward", LastName = "bell", DOB = DateTime.Parse("1988/01/01"), GPA = 3.9m };

            applicantList.Add(applicant1);
            applicantList.Add(applicant2);

            IQueryable<Applicant> queryableAppplicants = applicantList.AsQueryable();

            var Repository = new Mock<IRepository>();
            Repository.Setup(x => x.GetAllApplicants()).Returns(queryableAppplicants);

            // Arrange
            ApplicantController controller = new ApplicantController(Repository.Object);

            // Act
            var result = controller.GetApplicants();

            // Assert
            var response = result as OkNegotiatedContentResult<IQueryable<Applicant>>;
            Assert.IsNotNull(response);
            var applicants = response.Content;
            Assert.AreEqual(2, applicants.Count());
        }

        [TestMethod]
        public void TestGetApplicant()
        {
            List<Applicant> applicantList = new List<Applicant>();
            var applicant1 = new Applicant { Id = 1, FirstName = "john", LastName = "papa", DOB = DateTime.Parse("1988/01/01"), GPA = 3.9m };
            var applicant2 = new Applicant { Id = 2, FirstName = "ward", LastName = "bell", DOB = DateTime.Parse("1988/01/01"), GPA = 3.9m };

            applicantList.Add(applicant1);
            applicantList.Add(applicant2);

            IQueryable<Applicant> queryableAppplicants = applicantList.AsQueryable();

            var Repository = new Mock<IRepository>();
            Repository.Setup(x => x.GetApplicant(1)).Returns(queryableAppplicants.FirstOrDefault(a=>a.Id==1));

            // Arrange
            ApplicantController controller = new ApplicantController(Repository.Object);

            // Act
            var result = controller.GetApplicant(1);

            // Assert
            var response = result as OkNegotiatedContentResult<Applicant>;
            Assert.IsNotNull(response);
            var applicant = response.Content;
            Assert.AreEqual(1, applicant.Id);
        }

        [TestMethod]
        public void TestPost()
        {

            List<Applicant> applicantList = new List<Applicant>();
            var newapplicant = new Applicant { Id = 3, FirstName = "ward", LastName = "bell", DOB = DateTime.Parse("1988/01/01"), GPA = 3.9m };
            applicantList.Add(newapplicant);

            IQueryable<Applicant> queryableAppplicants = applicantList.AsQueryable();

            var Repository = new Mock<IRepository>();
            Repository.Setup(x => x.CreateApplicant(newapplicant));

            // Arrange
            ApplicantController controller = new ApplicantController(Repository.Object);

            // Act
            var result = controller.PostApplicant(newapplicant);

            // Assert
            var response = result as OkNegotiatedContentResult<Applicant>;
            Assert.IsNotNull(response);
            var applicant = response.Content;
            Assert.AreEqual(3, applicant.Id);
        }

       
    }
}
