using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.ListAll;
using SportscardSystem.DTO;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.ListAll.ListAllClientsCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CallClientListAllMethodOnce_WhenInvokedWithValidParameters()
        {
            // Arrange
            var clientServiceMock = new Mock<IClientService>();

            var listAllClientsCommand = new ListAllClientsCommand(clientServiceMock.Object);
            var parameters = new List<string>();

            //Act
            listAllClientsCommand.Execute(parameters);

            //Assert
            clientServiceMock.Verify(x => x.GetAllClients(), Times.Once);
        }

        [TestMethod]
        public void ReturnListOfAllClientsString_WhenInvokedWithValidParameters()
        {
            // Arrange
            var clientServiceMock = new Mock<IClientService>();

            var listAllClientsCommand = new ListAllClientsCommand(clientServiceMock.Object);
            var parameters = new List<string>();

            var clients = new List<ClientDto>()
            {
                new ClientDto() {FirstName = "Pesho", LastName = "Peshev"},
                new ClientDto() {FirstName = "Gosho", LastName = "Goshev"}
            };

            clientServiceMock
                .Setup(x => x.GetAllClients())
                .Returns(clients);

            var expectedMessage = string.Join(Environment.NewLine, clients);

            //Act
            var actualMessage = listAllClientsCommand.Execute(parameters);

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ReturnNoClientsMessageString_WhenInvokedWithValidParameters()
        {
            // Arrange
            var clientServiceMock = new Mock<IClientService>();

            var listAllClientsCommand = new ListAllClientsCommand(clientServiceMock.Object);
            var parameters = new List<string>();

            var clients = new List<ClientDto>();

            clientServiceMock
                .Setup(x => x.GetAllClients())
                .Returns(clients);

            var expectedMessage = "There are no registered clients.";

            //Act
            var actualMessage = listAllClientsCommand.Execute(parameters);

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenMethodReturnsNull()
        {
            // Arrange
            var clientServiceMock = new Mock<IClientService>();

            var listAllClientsCommand = new ListAllClientsCommand(clientServiceMock.Object);
            var parameters = new List<string>();

            var clients = new List<ClientDto>();

            clientServiceMock
                .Setup(x => x.GetAllClients())
                .Returns((IEnumerable<ClientDto>)null);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => listAllClientsCommand.Execute(parameters));
        }
    }
}
