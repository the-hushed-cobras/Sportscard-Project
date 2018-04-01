using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Commands.ListAll;
using SportscardSystem.Logic.Services.Contracts;
using System;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.ListAll.ListAllSportsCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameter()
        {
            //Arrange
            var sportServiceMock = new Mock<ISportService>();

            //Act
            var listAllSportsCommand = new ListAllSportsCommand(sportServiceMock.Object);

            //Assert
            Assert.IsNotNull(listAllSportsCommand);
            Assert.IsInstanceOfType(listAllSportsCommand, typeof(ICommand));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullClientSeriveParameter()
        {
            //Arrange
            //var sportServiceMock = new Mock<ISportService>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ListAllSportsCommand(null));
        }
    }
}
