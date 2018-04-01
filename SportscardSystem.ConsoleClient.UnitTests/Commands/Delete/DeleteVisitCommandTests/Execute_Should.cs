using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.Delete;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.Delete.DeleteVisitCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CallCompanyDeleteMethodOnce_WhenInvokedWithValidParameters()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var visitServiceMock = new Mock<IVisitService>();

            var id = "db97a0eb-9411-4f1d-9ead-3997e6271324";

            var deleteVisitCommand = new DeleteVisitCommand(sportscardFactoryMock.Object, visitServiceMock.Object);
            var parameters = new List<string>()
            {
                id
            };

            //Act
            deleteVisitCommand.Execute(parameters);

            //Assert
            visitServiceMock.Verify(x => x.DeleteVisit(new Guid(id)), Times.Once);
        }

        [TestMethod]
        public void ReturnSuccessMessage_WhenInvokedWithValidParameters()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var visitServiceMock = new Mock<IVisitService>();

            var id = "db97a0eb-9411-4f1d-9ead-3997e6271324";
            var expectedMessage = $"The following visit was deleted from database.";

            var deleteVisitCommand = new DeleteVisitCommand(sportscardFactoryMock.Object, visitServiceMock.Object);
            var parameters = new List<string>()
            {
                id
            };

            //Act
            var actualMessage = deleteVisitCommand.Execute(parameters);

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullIdParameter()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var visitServiceMock = new Mock<IVisitService>();

            //var id = "db97a0eb-9411-4f1d-9ead-3997e6271324";
            var expectedMessage = $"The following visit was deleted from database.";

            var deleteVisitCommand = new DeleteVisitCommand(sportscardFactoryMock.Object, visitServiceMock.Object);
            var parameters = new List<string>()
            {
                null
            };

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => deleteVisitCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyIdParameter()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var visitServiceMock = new Mock<IVisitService>();

            //var id = "db97a0eb-9411-4f1d-9ead-3997e6271324";
            var expectedMessage = $"The following visit was deleted from database.";

            var deleteVisitCommand = new DeleteVisitCommand(sportscardFactoryMock.Object, visitServiceMock.Object);
            var parameters = new List<string>()
            {
                string.Empty
            };

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => deleteVisitCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithEmptyParametersCollection()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var visitServiceMock = new Mock<IVisitService>();

            //var id = "db97a0eb-9411-4f1d-9ead-3997e6271324";
            var expectedMessage = $"The following visit was deleted from database.";

            var deleteVisitCommand = new DeleteVisitCommand(sportscardFactoryMock.Object, visitServiceMock.Object);
            var parameters = new List<string>();

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => deleteVisitCommand.Execute(parameters));
        }
    }
}
