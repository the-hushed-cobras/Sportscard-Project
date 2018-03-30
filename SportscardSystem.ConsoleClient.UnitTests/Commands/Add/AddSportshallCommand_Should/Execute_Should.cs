using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.Add;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.DTO;
using SportscardSystem.Logic.Services.Contracts;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.Add.AddSportshallCommand_Should
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CallSportshallAddMethodOnce_WhenInvokedWithValidParameters()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportshallServiceMock = new Mock<ISportshallService>();

            var sportshallName = "Topfit";
            var expectedSportshall = new SportshallDto()
            {
                Name = sportshallName
            };

            sportscardFactoryMock
                .Setup(x => x.CreateSportshallDto(sportshallName))
                .Returns(expectedSportshall);

            var addSportshallCommand = new AddSportshallCommand(sportscardFactoryMock.Object, sportshallServiceMock.Object);
            var parameters = new List<string>()
            {
                sportshallName
            };

            //Act
            addSportshallCommand.Execute(parameters);

            //Assert
            sportshallServiceMock.Verify(x => x.AddSportshall(expectedSportshall), Times.Once);
        }

        [TestMethod]
        public void ReturnSuccessMessage_WhenInvokedWithValidParameters()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportshallServiceMock = new Mock<ISportshallService>();

            var sportshallName = "Topfit";
            var expectedMessage = $"{sportshallName} sportshall was added to database.";
            var expectedSportshall = new SportshallDto()
            {
                Name = sportshallName
            };

            sportscardFactoryMock
                .Setup(x => x.CreateSportshallDto(sportshallName))
                .Returns(expectedSportshall);

            var addSportshallCommand = new AddSportshallCommand(sportscardFactoryMock.Object, sportshallServiceMock.Object);
            var parameters = new List<string>()
            {
                sportshallName
            };

            //Act
            var actualMessage = addSportshallCommand.Execute(parameters);

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullSportshallNameParameter()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportshallServiceMock = new Mock<ISportshallService>();

            var sportshallName = "Topfit";
            var expectedMessage = $"{sportshallName} sportshall was added to database.";
            var expectedSportshall = new SportshallDto()
            {
                Name = sportshallName
            };

            sportscardFactoryMock
                .Setup(x => x.CreateSportshallDto(sportshallName))
                .Returns(expectedSportshall);

            var addSportshallCommand = new AddSportshallCommand(sportscardFactoryMock.Object, sportshallServiceMock.Object);
            var parameters = new List<string>()
            {
                null
            };

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => addSportshallCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptySportshallNameParameter()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportshallServiceMock = new Mock<ISportshallService>();

            var sportshallName = "Topfit";
            var expectedMessage = $"{sportshallName} sportshall was added to database.";
            var expectedSportshall = new SportshallDto()
            {
                Name = sportshallName
            };

            sportscardFactoryMock
                .Setup(x => x.CreateSportshallDto(sportshallName))
                .Returns(expectedSportshall);

            var addSportshallCommand = new AddSportshallCommand(sportscardFactoryMock.Object, sportshallServiceMock.Object);
            var parameters = new List<string>()
            {
                string.Empty
            };

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => addSportshallCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithEmptyParametersCollection()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportshallServiceMock = new Mock<ISportshallService>();

            var sportshallName = "Topfit";
            var expectedMessage = $"{sportshallName} sportshall was added to database.";
            var expectedSportshall = new SportshallDto()
            {
                Name = sportshallName
            };

            sportscardFactoryMock
                .Setup(x => x.CreateSportshallDto(sportshallName))
                .Returns(expectedSportshall);

            var addSportshallCommand = new AddSportshallCommand(sportscardFactoryMock.Object, sportshallServiceMock.Object);
            var parameters = new List<string>();

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => addSportshallCommand.Execute(parameters));
        }
    }
}
