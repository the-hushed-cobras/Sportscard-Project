using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.Add;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.Add.AddSportToSportshallCommand_Should
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CallSportToSportshallAddMethodOnce_WhenInvokedWithValidParameters()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportServiceMock = new Mock<ISportService>();

            var sportName = "Gym";
            var sportshallName = "Topfit";

            var addSportToSportshallCommand = new AddSportToSportshallCommand(sportscardFactoryMock.Object, sportServiceMock.Object);
            var parameters = new List<string>()
            {
                sportName,
                sportshallName
            };

            //Act
            addSportToSportshallCommand.Execute(parameters);

            //Assert
            sportServiceMock.Verify(x => x.AddSportToSportshall(sportName, sportshallName), Times.Once);
        }

        [TestMethod]
        public void ReturnSuccessMessage_WhenInvokedWithValidParameters()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportServiceMock = new Mock<ISportService>();

            var sportName = "Gym";
            var sportshallName = "Topfit";
            var expectedMessage = $"{sportName} were added to {sportshallName} and added to database.";

            var addSportToSportshallCommand = new AddSportToSportshallCommand(sportscardFactoryMock.Object, sportServiceMock.Object);
            var parameters = new List<string>()
            {
                sportName,
                sportshallName
            };

            //Act
            var actualMessage = addSportToSportshallCommand.Execute(parameters);

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullSportNameParameter()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportServiceMock = new Mock<ISportService>();

            var sportName = "Gym";
            var sportshallName = "Topfit";
            var expectedMessage = $"{sportName} were added to {sportshallName} and added to database.";

            var addSportToSportshallCommand = new AddSportToSportshallCommand(sportscardFactoryMock.Object, sportServiceMock.Object);
            var parameters = new List<string>()
            {
                null,
                sportshallName
            };

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => addSportToSportshallCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptySportNameParameter()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportServiceMock = new Mock<ISportService>();

            var sportName = "Gym";
            var sportshallName = "Topfit";
            var expectedMessage = $"{sportName} were added to {sportshallName} and added to database.";

            var addSportToSportshallCommand = new AddSportToSportshallCommand(sportscardFactoryMock.Object, sportServiceMock.Object);
            var parameters = new List<string>()
            {
                string.Empty,
                sportshallName
            };

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => addSportToSportshallCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullSportshallNameParameter()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportServiceMock = new Mock<ISportService>();

            var sportName = "Gym";
            var sportshallName = "Topfit";
            var expectedMessage = $"{sportName} were added to {sportshallName} and added to database.";

            var addSportToSportshallCommand = new AddSportToSportshallCommand(sportscardFactoryMock.Object, sportServiceMock.Object);
            var parameters = new List<string>()
            {
                sportName,
                null
            };

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => addSportToSportshallCommand.Execute(parameters));
        }

        public void ThrowArgumentException_WhenInvokedWithInvalidEmptySportshallNameParameter()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportServiceMock = new Mock<ISportService>();

            var sportName = "Gym";
            var sportshallName = "Topfit";
            var expectedMessage = $"{sportName} were added to {sportshallName} and added to database.";

            var addSportToSportshallCommand = new AddSportToSportshallCommand(sportscardFactoryMock.Object, sportServiceMock.Object);
            var parameters = new List<string>()
            {
                sportName,
                string.Empty
            };

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => addSportToSportshallCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithEmptyParametersCollection()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportServiceMock = new Mock<ISportService>();

            var sportName = "Gym";
            var sportshallName = "Topfit";
            var expectedMessage = $"{sportName} were added to {sportshallName} and added to database.";

            var addSportToSportshallCommand = new AddSportToSportshallCommand(sportscardFactoryMock.Object, sportServiceMock.Object);
            var parameters = new List<string>();

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => addSportToSportshallCommand.Execute(parameters));
        }
    }
}
