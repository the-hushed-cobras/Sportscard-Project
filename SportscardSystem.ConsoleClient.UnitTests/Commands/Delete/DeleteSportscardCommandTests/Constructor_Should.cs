using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Commands.Delete;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.Delete.DeleteSportscardCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters()
        {
            //Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportscardSerivce = new Mock<ISportscardService>();

            //Act
            var deleteSportscardCommand = new DeleteSportscardCommand(sportscardFactoryMock.Object, sportscardSerivce.Object);

            //Assert
            Assert.IsNotNull(deleteSportscardCommand);
            Assert.IsInstanceOfType(deleteSportscardCommand, typeof(ICommand));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullSportscardFactoryParameter()
        {
            //Arrange
            //var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var sportscardSerivce = new Mock<ISportscardService>();


            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new DeleteSportscardCommand(null, sportscardSerivce.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullCompanyServiceParameter()
        {

            //Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            //var sportscardSerivce = new Mock<ISportscardService>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new DeleteSportscardCommand(sportscardFactoryMock.Object, null));
        }
    }
}
