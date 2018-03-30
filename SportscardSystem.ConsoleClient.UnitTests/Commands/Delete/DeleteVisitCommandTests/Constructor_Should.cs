using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Commands.Delete;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.Delete.DeleteVisitCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters()
        {
            //Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var visiServiceMock = new Mock<IVisitService>();

            //Act
            var deleteVisitCommand = new DeleteVisitCommand(sportscardFactoryMock.Object, visiServiceMock.Object);

            //Assert
            Assert.IsNotNull(deleteVisitCommand);
            Assert.IsInstanceOfType(deleteVisitCommand, typeof(ICommand));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullSportscardFactoryParameter()
        {
            //Arrange
            //var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var visiServiceMock = new Mock<IVisitService>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new DeleteVisitCommand(null, visiServiceMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullSportshallServiceParameter()
        {
            //Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            //var visiServiceMock = new Mock<IVisitService>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new DeleteVisitCommand(sportscardFactoryMock.Object, null));
        }
    }
}
