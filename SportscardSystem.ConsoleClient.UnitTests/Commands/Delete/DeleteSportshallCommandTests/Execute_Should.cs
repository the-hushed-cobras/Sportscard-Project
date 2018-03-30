using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.Delete;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.Delete.DeleteSportshallCommand_Should
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CallSportshallDeleteMethodOnce_WhenInvokedWithValidParameters()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportshallServiceMock = new Mock<ISportshallService>();

            var sportshallName = "Topfit";

            var deleteSportshallCommand = new DeleteSportshallCommand(sportscardFactoryMock.Object, sportshallServiceMock.Object);
            var parameters = new List<string>()
            {
                sportshallName
            };

            //Act
            deleteSportshallCommand.Execute(parameters);

            //Assert
            sportshallServiceMock.Verify(x => x.DeleteSportshall(sportshallName), Times.Once);
        }

        [TestMethod]
        public void ReturnSuccessMessage_WhenInvokedWithValidParameters()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportshallServiceMock = new Mock<ISportshallService>();

            var sportshallName = "Topfit";
            var expectedMessage = $"Sportshall \"{sportshallName}\" was deleted from database.";

            var deleteSportshallCommand = new DeleteSportshallCommand(sportscardFactoryMock.Object, sportshallServiceMock.Object);
            var parameters = new List<string>()
            {
                sportshallName
            };

            //Act
            var actualMessage = deleteSportshallCommand.Execute(parameters);

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
            var expectedMessage = $"Sportshall \"{sportshallName}\" was deleted from database.";

            var deleteSportshallCommand = new DeleteSportshallCommand(sportscardFactoryMock.Object, sportshallServiceMock.Object);
            var parameters = new List<string>()
            {
                null
            };

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => deleteSportshallCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptySportshallNameParameter()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportshallServiceMock = new Mock<ISportshallService>();

            var sportshallName = "Topfit";
            var expectedMessage = $"Sportshall \"{sportshallName}\" was deleted from database.";

            var deleteSportshallCommand = new DeleteSportshallCommand(sportscardFactoryMock.Object, sportshallServiceMock.Object);
            var parameters = new List<string>()
            {
                string.Empty
            };

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => deleteSportshallCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithEmptyParametersCollection()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportshallServiceMock = new Mock<ISportshallService>();

            var sportshallName = "Topfit";
            var expectedMessage = $"Sportshall \"{sportshallName}\" was deleted from database.";

            var deleteSportshallCommand = new DeleteSportshallCommand(sportscardFactoryMock.Object, sportshallServiceMock.Object);
            var parameters = new List<string>();

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => deleteSportshallCommand.Execute(parameters));
        }
    }
}
