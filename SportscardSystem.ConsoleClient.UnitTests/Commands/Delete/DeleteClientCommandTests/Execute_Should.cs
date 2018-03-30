using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.Delete;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.ConsoleClient.Validator;
using SportscardSystem.Logic.Services.Contracts;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.Delete.DeleteClientCommand_Should
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CallClientDeleteMethodOnce_WhenInvokedWithValidParameters()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var clientServiceMock = new Mock<IClientService>();
            var validatorMock = new Mock<IValidateCore>();

            var clientFirstName = "Pesho";
            var clientLastName = "Peshev";

            var deleteClientCommand = new DeleteClientCommand(sportscardFactoryMock.Object, clientServiceMock.Object, validatorMock.Object);

            var parameters = new List<string>()
            {
                clientFirstName,
                clientLastName
            };

            //Act
            deleteClientCommand.Execute(parameters);

            //Assert
            clientServiceMock.Verify(x => x.DeleteClient(clientFirstName, clientLastName, null), Times.Once);
        }

        [TestMethod]
        public void ReturnStringSuccessMessage_WhenInvokedWithValidParameters()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var clientServiceMock = new Mock<IClientService>();
            var validatorMock = new Mock<IValidateCore>();

            var clientFirstName = "Pesho";
            var clientLastName = "Peshev";
            var expectedMessage = $"{clientFirstName} was deleted from database.";

            var deleteClientCommand = new DeleteClientCommand(sportscardFactoryMock.Object, clientServiceMock.Object, validatorMock.Object);

            var parameters = new List<string>()
            {
                clientFirstName,
                clientLastName
            };

            //Act
            var successMessage = deleteClientCommand.Execute(parameters);

            //Assert
            Assert.AreEqual(expectedMessage, successMessage);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullFistNameParameter()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var clientServiceMock = new Mock<IClientService>();
            var validatorMock = new Mock<IValidateCore>();

            var clientFirstName = "Pesho";
            var clientLastName = "Peshev";

            var deleteClientCommand = new DeleteClientCommand(sportscardFactoryMock.Object, clientServiceMock.Object, validatorMock.Object);

            var parameters = new List<string>()
            {
                null,
                clientLastName
            };

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => deleteClientCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyFistNameParameter()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var clientServiceMock = new Mock<IClientService>();
            var validatorMock = new Mock<IValidateCore>();

            var clientFirstName = "Pesho";
            var clientLastName = "Peshev";

            var deleteClientCommand = new DeleteClientCommand(sportscardFactoryMock.Object, clientServiceMock.Object, validatorMock.Object);

            var parameters = new List<string>()
            {
                string.Empty,
                clientLastName
            };

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => deleteClientCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullLastNameParameter()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var clientServiceMock = new Mock<IClientService>();
            var validatorMock = new Mock<IValidateCore>();

            var clientFirstName = "Pesho";
            var clientLastName = "Peshev";

            var deleteClientCommand = new DeleteClientCommand(sportscardFactoryMock.Object, clientServiceMock.Object, validatorMock.Object);

            var parameters = new List<string>()
            {
                clientFirstName,
                null
            };

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => deleteClientCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyLastNameParameter()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var clientServiceMock = new Mock<IClientService>();
            var validatorMock = new Mock<IValidateCore>();

            var clientFirstName = "Pesho";
            var clientLastName = "Peshev";

            var deleteClientCommand = new DeleteClientCommand(sportscardFactoryMock.Object, clientServiceMock.Object, validatorMock.Object);

            var parameters = new List<string>()
            {
                clientFirstName,
                string.Empty
            };

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => deleteClientCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentOutOfRangeException_WhenInvokedWithEmptyParametersCollection()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var clientServiceMock = new Mock<IClientService>();
            var validatorMock = new Mock<IValidateCore>();

            var clientFirstName = "Pesho";
            var clientLastName = "Peshev";

            var deleteClientCommand = new DeleteClientCommand(sportscardFactoryMock.Object, clientServiceMock.Object, validatorMock.Object);

            var parameters = new List<string>();

            //Act && Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => deleteClientCommand.Execute(parameters));
        }
    }
}
