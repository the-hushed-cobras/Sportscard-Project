using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Commands.ListAll;
using SportscardSystem.Logic.Services.Contracts;
using System;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.ListAll.ListAllClientsCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameter()
        {
            //Arrange
            var clientServiceMock = new Mock<IClientService>();

            //Act
            var listAllClientsCommand = new ListAllClientsCommand(clientServiceMock.Object);

            //Assert
            Assert.IsNotNull(listAllClientsCommand);
            Assert.IsInstanceOfType(listAllClientsCommand, typeof(ICommand));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullClientSeriveParameter()
        {
            //Arrange
            //var clientServiceMock = new Mock<IClientService>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ListAllClientsCommand(null));
        }
    }
}
