using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Commands.ListAll;
using SportscardSystem.Logic.Services.Contracts;
using System;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.ListAll.ListAllSportshallsCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameter()
        {
            //Arrange
            var sportshallServiceMock = new Mock<ISportshallService>();

            //Act
            var listAllSportshallsCommand = new ListAllSportshallsCommand(sportshallServiceMock.Object);

            //Assert
            Assert.IsNotNull(listAllSportshallsCommand);
            Assert.IsInstanceOfType(listAllSportshallsCommand, typeof(ICommand));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullClientSeriveParameter()
        {
            //Arrange
            //var sportshallServiceMock = new Mock<ISportshallService>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ListAllSportshallsCommand(null));
        }
    }
}
