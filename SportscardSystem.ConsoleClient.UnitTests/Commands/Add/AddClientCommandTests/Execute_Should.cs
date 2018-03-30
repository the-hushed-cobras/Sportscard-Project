using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.Add;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.ConsoleClient.Validator;
using SportscardSystem.DTO;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.Add.AddClientCommand_Should
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CallClientAddMethodOnce_WhenInvokedWithValidParameters()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var clientServiceMock = new Mock<IClientService>();
            var validatorMock = new Mock<IValidateCore>();

            var clientFirstName = "Pesho";
            var clientLastName = "Peshev";
            var companyName = "Progress";
            var companyId = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323");
            var expectedClient = new ClientDto()
            {
                FirstName = clientFirstName,
                LastName = clientLastName,
                CompanyId = companyId
            };

            clientServiceMock
                .Setup(x => x.GetCompanyGuidByName(companyName))
                .Returns(new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"));

            sportscardFactoryMock
                .Setup(x => x.CreateClientDto(clientFirstName, clientLastName, null, companyId))
                .Returns(expectedClient);

            var addClientCommand = new AddClientCommand(sportscardFactoryMock.Object, clientServiceMock.Object, validatorMock.Object);
            var parameters = new List<string>()
            {
                clientFirstName,
                clientLastName,
                companyName
            };

            //Act
            addClientCommand.Execute(parameters);

            //Assert
            clientServiceMock.Verify(x => x.AddClient(expectedClient), Times.Once);
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
            var companyName = "Progress";
            var companyId = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323");
            var expectedClient = new ClientDto()
            {
                FirstName = clientFirstName,
                LastName = clientLastName,
                CompanyId = companyId
            };

            clientServiceMock
                .Setup(x => x.GetCompanyGuidByName(companyName))
                .Returns(new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"));

            sportscardFactoryMock
                .Setup(x => x.CreateClientDto(clientFirstName, clientLastName, null, companyId))
                .Returns(expectedClient);

            var addClientCommand = new AddClientCommand(sportscardFactoryMock.Object, clientServiceMock.Object, validatorMock.Object);
            var parameters = new List<string>()
            {
                clientFirstName,
                clientLastName,
                companyName
            };

            var expectedMessage = $"{clientFirstName} {clientLastName} client was added to database.";

            //Act
            var successMessage = addClientCommand.Execute(parameters);

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
            var companyName = "Progress";
            var companyId = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323");
            var expectedClient = new ClientDto()
            {
                FirstName = clientFirstName,
                LastName = clientLastName,
                CompanyId = companyId
            };

            clientServiceMock
                .Setup(x => x.GetCompanyGuidByName(companyName))
                .Returns(new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"));

            sportscardFactoryMock
                .Setup(x => x.CreateClientDto(clientFirstName, clientLastName, null, companyId))
                .Returns(expectedClient);

            var addClientCommand = new AddClientCommand(sportscardFactoryMock.Object, clientServiceMock.Object, validatorMock.Object);
            var parameters = new List<string>()
            {
                null,
                clientLastName,
                companyName
            };

            var expectedMessage = $"{clientFirstName} {clientLastName} client was added to database.";

            //Act
            Assert.ThrowsException<ArgumentNullException>(() => addClientCommand.Execute(parameters));
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
            var companyName = "Progress";
            var companyId = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323");
            var expectedClient = new ClientDto()
            {
                FirstName = clientFirstName,
                LastName = clientLastName,
                CompanyId = companyId
            };

            clientServiceMock
                .Setup(x => x.GetCompanyGuidByName(companyName))
                .Returns(new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"));

            sportscardFactoryMock
                .Setup(x => x.CreateClientDto(clientFirstName, clientLastName, null, companyId))
                .Returns(expectedClient);

            var addClientCommand = new AddClientCommand(sportscardFactoryMock.Object, clientServiceMock.Object, validatorMock.Object);
            var parameters = new List<string>()
            {
                string.Empty,
                clientLastName,
                companyName
            };

            var expectedMessage = $"{clientFirstName} {clientLastName} client was added to database.";

            //Act
            Assert.ThrowsException<ArgumentException>(() => addClientCommand.Execute(parameters));
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
            var companyName = "Progress";
            var companyId = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323");
            var expectedClient = new ClientDto()
            {
                FirstName = clientFirstName,
                LastName = clientLastName,
                CompanyId = companyId
            };

            clientServiceMock
                .Setup(x => x.GetCompanyGuidByName(companyName))
                .Returns(new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"));

            sportscardFactoryMock
                .Setup(x => x.CreateClientDto(clientFirstName, clientLastName, null, companyId))
                .Returns(expectedClient);

            var addClientCommand = new AddClientCommand(sportscardFactoryMock.Object, clientServiceMock.Object, validatorMock.Object);
            var parameters = new List<string>()
            {
                clientFirstName,
                null,
                companyName
            };

            var expectedMessage = $"{clientFirstName} {clientLastName} client was added to database.";

            //Act
            Assert.ThrowsException<ArgumentNullException>(() => addClientCommand.Execute(parameters));
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
            var companyName = "Progress";
            var companyId = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323");
            var expectedClient = new ClientDto()
            {
                FirstName = clientFirstName,
                LastName = clientLastName,
                CompanyId = companyId
            };

            clientServiceMock
                .Setup(x => x.GetCompanyGuidByName(companyName))
                .Returns(new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"));

            sportscardFactoryMock
                .Setup(x => x.CreateClientDto(clientFirstName, clientLastName, null, companyId))
                .Returns(expectedClient);

            var addClientCommand = new AddClientCommand(sportscardFactoryMock.Object, clientServiceMock.Object, validatorMock.Object);
            var parameters = new List<string>()
            {
                clientFirstName,
                string.Empty,
                companyName
            };

            var expectedMessage = $"{clientFirstName} {clientLastName} client was added to database.";

            //Act
            Assert.ThrowsException<ArgumentException>(() => addClientCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullCompanyNameParameter()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var clientServiceMock = new Mock<IClientService>();
            var validatorMock = new Mock<IValidateCore>();

            var clientFirstName = "Pesho";
            var clientLastName = "Peshev";
            var companyName = "Progress";
            var companyId = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323");
            var expectedClient = new ClientDto()
            {
                FirstName = clientFirstName,
                LastName = clientLastName,
                CompanyId = companyId
            };

            clientServiceMock
                .Setup(x => x.GetCompanyGuidByName(companyName))
                .Returns(new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"));

            sportscardFactoryMock
                .Setup(x => x.CreateClientDto(clientFirstName, clientLastName, null, companyId))
                .Returns(expectedClient);

            var addClientCommand = new AddClientCommand(sportscardFactoryMock.Object, clientServiceMock.Object, validatorMock.Object);
            var parameters = new List<string>()
            {
                clientFirstName,
                clientLastName,
                null
            };

            var expectedMessage = $"{clientFirstName} {clientLastName} client was added to database.";

            //Act
            Assert.ThrowsException<ArgumentNullException>(() => addClientCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyCompanyNameParameter()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var clientServiceMock = new Mock<IClientService>();
            var validatorMock = new Mock<IValidateCore>();

            var clientFirstName = "Pesho";
            var clientLastName = "Peshev";
            var companyName = "Progress";
            var companyId = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323");
            var expectedClient = new ClientDto()
            {
                FirstName = clientFirstName,
                LastName = clientLastName,
                CompanyId = companyId
            };

            clientServiceMock
                .Setup(x => x.GetCompanyGuidByName(companyName))
                .Returns(new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"));

            sportscardFactoryMock
                .Setup(x => x.CreateClientDto(clientFirstName, clientLastName, null, companyId))
                .Returns(expectedClient);

            var addClientCommand = new AddClientCommand(sportscardFactoryMock.Object, clientServiceMock.Object, validatorMock.Object);
            var parameters = new List<string>()
            {
                clientFirstName,
                clientLastName,
                string.Empty
            };

            var expectedMessage = $"{clientFirstName} {clientLastName} client was added to database.";

            //Act
            Assert.ThrowsException<ArgumentException>(() => addClientCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithEmptyParametersCollection()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var clientServiceMock = new Mock<IClientService>();
            var validatorMock = new Mock<IValidateCore>();

            var clientFirstName = "Pesho";
            var clientLastName = "Peshev";
            var companyName = "Progress";
            var companyId = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323");
            var expectedClient = new ClientDto()
            {
                FirstName = clientFirstName,
                LastName = clientLastName,
                CompanyId = companyId
            };

            clientServiceMock
                .Setup(x => x.GetCompanyGuidByName(companyName))
                .Returns(new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"));

            sportscardFactoryMock
                .Setup(x => x.CreateClientDto(clientFirstName, clientLastName, null, companyId))
                .Returns(expectedClient);

            var addClientCommand = new AddClientCommand(sportscardFactoryMock.Object, clientServiceMock.Object, validatorMock.Object);
            var parameters = new List<string>();

            var expectedMessage = $"{clientFirstName} {clientLastName} client was added to database.";

            //Act
            Assert.ThrowsException<ArgumentException>(() => addClientCommand.Execute(parameters));
        }
    }
}
