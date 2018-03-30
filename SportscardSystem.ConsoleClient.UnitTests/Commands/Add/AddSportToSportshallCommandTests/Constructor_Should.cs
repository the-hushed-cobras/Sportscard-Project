using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.Add;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.Add.AddSportToSportshallCommand_Should
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters()
        {
            //Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportService = new Mock<ISportService>();

            //Act
            var addSportToSportshallCommand = new AddSportToSportshallCommand(sportscardFactoryMock.Object, sportService.Object);

            //Assert
            Assert.IsNotNull(addSportToSportshallCommand);
            Assert.IsInstanceOfType(addSportToSportshallCommand, typeof(ICommand));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullSportscardFactoryParameter()
        {
            //Arrange
            //var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportService = new Mock<ISportService>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new AddSportToSportshallCommand(null, sportService.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullSportServiceParameter()
        {
            //Arrange
            //var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportService = new Mock<ISportService>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new AddSportToSportshallCommand(null, sportService.Object));
        }
    }
}
