using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.Add;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.DTO;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.Add.AddSportCommand_Should
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CallCompanyAddMethodOnce_WhenInvokedWithValidParameters()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportServiceMock = new Mock<ISportService>();

            var sportName = "Gym";
            var expectedSport = new SportDto()
            {
                Name = sportName
            };

            sportscardFactoryMock
                .Setup(x => x.CreateSportDto(sportName))
                .Returns(expectedSport);

            var addCompanyCommand = new AddSportCommand(sportscardFactoryMock.Object, sportServiceMock.Object);
            var parameters = new List<string>()
            {
                sportName
            };

            //Act
            addCompanyCommand.Execute(parameters);

            //Assert
            sportServiceMock.Verify(x => x.AddSport(expectedSport), Times.Once);
        }

        [TestMethod]
        public void ReturnSuccessMessage_WhenInvokedWithValidParameters()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportServiceMock = new Mock<ISportService>();

            var sportName = "Gym";
            var expectedMessage = $"{sportName} sport was added to database.";
            var expectedSport = new SportDto()
            {
                Name = sportName
            };

            sportscardFactoryMock
                .Setup(x => x.CreateSportDto(sportName))
                .Returns(expectedSport);

            var addSportCommand = new AddSportCommand(sportscardFactoryMock.Object, sportServiceMock.Object);
            var parameters = new List<string>()
            {
                sportName
            };

            //Act
            var actualMessage = addSportCommand.Execute(parameters);

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
            var expectedMessage = $"{sportName} sport was added to database.";
            var expectedSport = new SportDto()
            {
                Name = sportName
            };

            sportscardFactoryMock
                .Setup(x => x.CreateSportDto(sportName))
                .Returns(expectedSport);

            var addSportCommand = new AddSportCommand(sportscardFactoryMock.Object, sportServiceMock.Object);
            var parameters = new List<string>()
            {
                null
            };

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => addSportCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptySportNameParameter()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportServiceMock = new Mock<ISportService>();

            var sportName = "Gym";
            var expectedMessage = $"{sportName} sport was added to database.";
            var expectedSport = new SportDto()
            {
                Name = sportName
            };

            sportscardFactoryMock
                .Setup(x => x.CreateSportDto(sportName))
                .Returns(expectedSport);

            var addSportCommand = new AddSportCommand(sportscardFactoryMock.Object, sportServiceMock.Object);
            var parameters = new List<string>()
            {
                string.Empty
            };

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => addSportCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithEmptyParametersCollection()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportServiceMock = new Mock<ISportService>();

            var sportName = "Gym";
            var expectedMessage = $"{sportName} sport was added to database.";
            var expectedSport = new SportDto()
            {
                Name = sportName
            };

            sportscardFactoryMock
                .Setup(x => x.CreateSportDto(sportName))
                .Returns(expectedSport);

            var addSportCommand = new AddSportCommand(sportscardFactoryMock.Object, sportServiceMock.Object);
            var parameters = new List<string>();

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => addSportCommand.Execute(parameters));
        }
    }
}
