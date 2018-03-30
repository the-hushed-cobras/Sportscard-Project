using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.Delete;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.Delete.DeleteSportscardCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CallCompanyDeleteMethodOnce_WhenInvokedWithValidParameters()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var companyServiceMock = new Mock<ISportscardService>();

            var clientFirstName = "Pesho";
            var clientLastName = "Peshev";
            var companyName = "Progress";

            var deleteSportscardCommand = new DeleteSportscardCommand(sportscardFactoryMock.Object, companyServiceMock.Object);
            var parameters = new List<string>()
            {
                clientFirstName,
                clientLastName,
                companyName
            };

            //Act
            deleteSportscardCommand.Execute(parameters);

            //Assert
            companyServiceMock.Verify(x => x.DeleteSportscard(clientFirstName, clientLastName, companyName), Times.Once);
        }

        [TestMethod]
        public void ReturnSuccessMessage_WhenInvokedWithValidParameters()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var companyServiceMock = new Mock<ISportscardService>();

            var clientFirstName = "Pesho";
            var clientLastName = "Peshev";
            var companyName = "Progress";
            var expectedMessage = $"The following sportscard was deleted from database.";

            var deleteSportscardCommand = new DeleteSportscardCommand(sportscardFactoryMock.Object, companyServiceMock.Object);
            var parameters = new List<string>()
            {
                clientFirstName,
                clientLastName,
                companyName
            };

            //Act
            var actualMessage = deleteSportscardCommand.Execute(parameters);

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullClientFirstNameParameter()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var companyServiceMock = new Mock<ISportscardService>();

            //var clientFirstName = "Pesho";
            var clientLastName = "Peshev";
            var companyName = "Progress";
            var expectedMessage = $"The following sportscard was deleted from database.";

            var deleteSportscardCommand = new DeleteSportscardCommand(sportscardFactoryMock.Object, companyServiceMock.Object);
            var parameters = new List<string>()
            {
                null,
                clientLastName,
                companyName
            };

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => deleteSportscardCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyClientFirstNameParameter()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var companyServiceMock = new Mock<ISportscardService>();

            //var clientFirstName = "Pesho";
            var clientLastName = "Peshev";
            var companyName = "Progress";
            var expectedMessage = $"The following sportscard was deleted from database.";

            var deleteSportscardCommand = new DeleteSportscardCommand(sportscardFactoryMock.Object, companyServiceMock.Object);
            var parameters = new List<string>()
            {
                string.Empty,
                clientLastName,
                companyName
            };

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => deleteSportscardCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullClientLastNameParameter()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var companyServiceMock = new Mock<ISportscardService>();

            var clientFirstName = "Pesho";
            //var clientLastName = "Peshev";
            var companyName = "Progress";
            var expectedMessage = $"The following sportscard was deleted from database.";

            var deleteSportscardCommand = new DeleteSportscardCommand(sportscardFactoryMock.Object, companyServiceMock.Object);
            var parameters = new List<string>()
            {
                clientFirstName,
                null,
                companyName
            };

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => deleteSportscardCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyClientLastNameParameter()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var companyServiceMock = new Mock<ISportscardService>();

            var clientFirstName = "Pesho";
            //var clientLastName = "Peshev";
            var companyName = "Progress";
            var expectedMessage = $"The following sportscard was deleted from database.";

            var deleteSportscardCommand = new DeleteSportscardCommand(sportscardFactoryMock.Object, companyServiceMock.Object);
            var parameters = new List<string>()
            {
                clientFirstName,
                string.Empty,
                companyName
            };

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => deleteSportscardCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullCompanyNameParameter()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var companyServiceMock = new Mock<ISportscardService>();

            var clientFirstName = "Pesho";
            var clientLastName = "Peshev";
            //var companyName = "Progress";
            var expectedMessage = $"The following sportscard was deleted from database.";

            var deleteSportscardCommand = new DeleteSportscardCommand(sportscardFactoryMock.Object, companyServiceMock.Object);
            var parameters = new List<string>()
            {
                clientFirstName,
                clientLastName,
                null
            };

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => deleteSportscardCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyCompanyNameParameter()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var companyServiceMock = new Mock<ISportscardService>();

            var clientFirstName = "Pesho";
            var clientLastName = "Peshev";
            //var companyName = "Progress";
            var expectedMessage = $"The following sportscard was deleted from database.";

            var deleteSportscardCommand = new DeleteSportscardCommand(sportscardFactoryMock.Object, companyServiceMock.Object);
            var parameters = new List<string>()
            {
                clientFirstName,
                clientLastName,
                string.Empty
            };

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => deleteSportscardCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithEmptyParametersCollection()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var companyServiceMock = new Mock<ISportscardService>();

            var clientFirstName = "Pesho";
            var clientLastName = "Peshev";
            var companyName = "Progress";
            var expectedMessage = $"The following sportscard was deleted from database.";

            var deleteSportscardCommand = new DeleteSportscardCommand(sportscardFactoryMock.Object, companyServiceMock.Object);
            var parameters = new List<string>();

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => deleteSportscardCommand.Execute(parameters));
        }
    }
}
