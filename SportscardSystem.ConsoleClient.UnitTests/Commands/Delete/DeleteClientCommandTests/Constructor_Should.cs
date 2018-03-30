using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.Add;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Commands.Delete;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.ConsoleClient.Validator;
using SportscardSystem.Logic.Services.Contracts;
using System;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.Delete.DeleteClientCommand_Should
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters()
        {
            //Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var clientServiceMock = new Mock<IClientService>();
            var validatorMock = new Mock<IValidateCore>();

            //Act
            var deleteClientCommand = new DeleteClientCommand(sportscardFactoryMock.Object, clientServiceMock.Object, validatorMock.Object);

            //Assert
            Assert.IsNotNull(deleteClientCommand);
            Assert.IsInstanceOfType(deleteClientCommand, typeof(ICommand));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullSportscardFactoryParameter()
        {
            //Arrange
            //var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var clientServiceMock = new Mock<IClientService>();
            var validatorMock = new Mock<IValidateCore>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new AddClientCommand(null, clientServiceMock.Object, validatorMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullClientServiceParameter()
        {
            //Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            //var clientServiceMock = new Mock<IClientService>();
            var validatorMock = new Mock<IValidateCore>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new DeleteClientCommand(sportscardFactoryMock.Object, null, validatorMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullValidatorCoreParameter()
        {
            //Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var clientServiceMock = new Mock<IClientService>();
            //var validatorMock = new Mock<IValidateCore>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new DeleteClientCommand(sportscardFactoryMock.Object, clientServiceMock.Object, null));
        }
    }
}
