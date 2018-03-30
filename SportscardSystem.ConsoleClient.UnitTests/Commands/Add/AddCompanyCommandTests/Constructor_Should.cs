using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.Add;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.Add.AddCompanyCommand_Should
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
            var addCompanyCommand = new AddCompanyCommand(sportscardFactoryMock.Object, companyService.Object);

            //Assert
            Assert.IsNotNull(addCompanyCommand);
            Assert.IsInstanceOfType(addCompanyCommand, typeof(ICommand));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullSportscardFactoryParameter()
        {
            //Arrange
            //var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var companyService = new Mock<ICompanyService>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new AddCompanyCommand(null, companyService.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullCompanyServiceParameter()
        {

            //Arrange
            //var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var companyService = new Mock<ICompanyService>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new AddCompanyCommand(null, companyService.Object));
        }
    }
}
