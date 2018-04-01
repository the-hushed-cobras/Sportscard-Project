using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Commands.ListAll;
using SportscardSystem.Logic.Services.Contracts;
using System;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.ListAll.ListAllVisitsCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameter()
        {
            //Arrange
            var visitServiceMock = new Mock<IVisitService>();

            //Act
            var listAllVisitsCommand = new ListAllVisitsCommand(visitServiceMock.Object);

            //Assert
            Assert.IsNotNull(listAllVisitsCommand);
            Assert.IsInstanceOfType(listAllVisitsCommand, typeof(ICommand));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullClientSeriveParameter()
        {
            //Arrange
            //var visitServiceMock = new Mock<IVisitService>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ListAllVisitsCommand(null));
        }
    }
}
