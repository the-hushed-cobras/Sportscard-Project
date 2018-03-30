using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.Add;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.Delete.DeleteSportshallCommand_Should
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters()
        {
            //Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportshallService = new Mock<ISportshallService>();

            //Act
            var addSportshallCommand = new AddSportshallCommand(sportscardFactoryMock.Object, sportshallService.Object);

            //Assert
            Assert.IsNotNull(addSportshallCommand);
            Assert.IsInstanceOfType(addSportshallCommand, typeof(ICommand));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullSportscardFactoryParameter()
        {
            //Arrange
            //var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportshallService = new Mock<ISportshallService>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new AddSportshallCommand(null, sportshallService.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullSportshallServiceParameter()
        {
            //Arrange
            //var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportshallService = new Mock<ISportshallService>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new AddSportshallCommand(null, sportshallService.Object));
        }
    }
}
