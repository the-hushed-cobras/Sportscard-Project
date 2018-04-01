using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.ListAll;
using SportscardSystem.DTO;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.ListAll.ListAllCompaniesCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CallCompaniesListAllMethodOnce_WhenInvokedWithValidParameters()
        {
            // Arrange
            var companyServiceMock = new Mock<ICompanyService>();

            var listAllCompaniesCommand = new ListAllCompaniesCommand(companyServiceMock.Object);
            var parameters = new List<string>();

            //Act
            listAllCompaniesCommand.Execute(parameters);

            //Assert
            companyServiceMock.Verify(x => x.GetAllCompanies(), Times.Once);
        }

        [TestMethod]
        public void ReturnListOfAllCompaniesString_WhenInvokedWithValidParameters()
        {
            // Arrange
            var companyServiceMock = new Mock<ICompanyService>();

            var listAllCompaniesCommand = new ListAllCompaniesCommand(companyServiceMock.Object);
            var parameters = new List<string>();

            var companies = new List<CompanyDto>()
            {
                new CompanyDto() {Name = "Telerik"},
                new CompanyDto() {Name = "Progress"}
            };

            companyServiceMock
                .Setup(x => x.GetAllCompanies())
                .Returns(companies);

            var expectedMessage = string.Join(Environment.NewLine, companies);

            //Act
            var actualMessage = listAllCompaniesCommand.Execute(parameters);

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ReturnNoCompaniesMessageString_WhenInvokedWithValidParameters()
        {
            // Arrange
            var companyServiceMock = new Mock<ICompanyService>();

            var listAllCompaniesCommand = new ListAllCompaniesCommand(companyServiceMock.Object);
            var parameters = new List<string>();

            var companies = new List<CompanyDto>();

            companyServiceMock
                .Setup(x => x.GetAllCompanies())
                .Returns(companies);

            var expectedMessage = "There are no registered companies.";

            //Act
            var actualMessage = listAllCompaniesCommand.Execute(parameters);

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenMethodReturnsNull()
        {
            // Arrange
            var companyServiceMock = new Mock<ICompanyService>();

            var listAllCompaniesCommand = new ListAllCompaniesCommand(companyServiceMock.Object);
            var parameters = new List<string>();

            var companies = new List<CompanyDto>();

            companyServiceMock
                .Setup(x => x.GetAllCompanies())
                .Returns((IEnumerable<CompanyDto>)null);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => listAllCompaniesCommand.Execute(parameters));
        }
    }
}
