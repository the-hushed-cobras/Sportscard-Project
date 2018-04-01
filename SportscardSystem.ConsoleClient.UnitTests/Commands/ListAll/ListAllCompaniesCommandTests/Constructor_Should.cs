using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Commands.ListAll;
using SportscardSystem.Logic.Services.Contracts;
using System;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.ListAll.ListAllCompaniesCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameter()
        {
            //Arrange
            var companyServiceMock = new Mock<ICompanyService>();

            //Act
            var listAllCompaniesCommand = new ListAllCompaniesCommand(companyServiceMock.Object);

            //Assert
            Assert.IsNotNull(listAllCompaniesCommand);
            Assert.IsInstanceOfType(listAllCompaniesCommand, typeof(ICommand));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullClientSeriveParameter()
        {
            //Arrange
            //var clientServiceMock = new Mock<IClientService>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ListAllCompaniesCommand(null));
        }
    }
}
