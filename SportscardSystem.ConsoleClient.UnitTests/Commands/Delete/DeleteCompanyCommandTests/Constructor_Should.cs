using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.Add;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Commands.Delete;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.Delete.DeleteCompanyCommand_Should
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters()
        {
            //Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var companyService = new Mock<ICompanyService>();

            //Act
            var deleteCompanyCommand = new DeleteCompanyCommand(sportscardFactoryMock.Object, companyService.Object);

            //Assert
            Assert.IsNotNull(deleteCompanyCommand);
            Assert.IsInstanceOfType(deleteCompanyCommand, typeof(ICommand));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullSportscardFactoryParameter()
        {
            //Arrange
            //var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var companyService = new Mock<ICompanyService>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new DeleteCompanyCommand(null, companyService.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullCompanyServiceParameter()
        {

            //Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            //var companyService = new Mock<ICompanyService>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new DeleteCompanyCommand(sportscardFactoryMock.Object, null));
        }
    }
}
