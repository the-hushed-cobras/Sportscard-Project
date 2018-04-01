using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.Add;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Commands.Delete;
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
            var deleteSportshallCommand = new DeleteSportshallCommand(sportscardFactoryMock.Object, sportshallService.Object);

            //Assert
            Assert.IsNotNull(deleteSportshallCommand);
            Assert.IsInstanceOfType(deleteSportshallCommand, typeof(ICommand));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullSportscardFactoryParameter()
        {
            //Arrange
            //var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportshallService = new Mock<ISportshallService>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new DeleteSportshallCommand(null, sportshallService.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullSportshallServiceParameter()
        {
            //Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            //var sportshallService = new Mock<ISportshallService>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new DeleteSportshallCommand(sportscardFactoryMock.Object, null));
        }
    }
}
