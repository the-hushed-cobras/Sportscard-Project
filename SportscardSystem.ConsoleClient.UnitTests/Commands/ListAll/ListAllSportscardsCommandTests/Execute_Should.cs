using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.ListAll;
using SportscardSystem.DTO;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.ListAll.ListAllSportscardsCommandTests
{
    [TestClass]
    public class Execute_Should
    {

        [TestMethod]
        public void CallSportscardListAllMethodOnce_WhenInvokedWithValidParameters()
        {
            // Arrange
            var sportscardServiceMock = new Mock<ISportscardService>();

            var listAllSportscardsCommand = new ListAllSportscardsCommand(sportscardServiceMock.Object);
            var parameters = new List<string>();

            //Act
            listAllSportscardsCommand.Execute(parameters);

            //Assert
            sportscardServiceMock.Verify(x => x.GetAllSportscards(), Times.Once);
        }

        [TestMethod]
        public void ReturnListOfAllSportscardsString_WhenInvokedWithValidParameters()
        {
            // Arrange
            var sportscardServiceMock = new Mock<ISportscardService>();

            var listAllSportscardsCommand = new ListAllSportscardsCommand(sportscardServiceMock.Object);
            var parameters = new List<string>();

            var sportscards = new List<SportscardDto>()
            {
                new SportscardDto() {Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324")},
                new SportscardDto() {Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323")}
            };

            sportscardServiceMock
                .Setup(x => x.GetAllSportscards())
                .Returns(sportscards);

            var expectedMessage = string.Join(Environment.NewLine, sportscards);

            //Act
            var actualMessage = listAllSportscardsCommand.Execute(parameters);

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ReturnNoCompaniesMessageString_WhenInvokedWithValidParameters()
        {
            // Arrange
            var sportscardServiceMock = new Mock<ISportscardService>();

            var listAllSportscardsCommand = new ListAllSportscardsCommand(sportscardServiceMock.Object);
            var parameters = new List<string>();

            var sportscards = new List<SportscardDto>();

            sportscardServiceMock
                .Setup(x => x.GetAllSportscards())
                .Returns(sportscards);

            var expectedMessage = "There are no registered sportscards.";

            //Act
            var actualMessage = listAllSportscardsCommand.Execute(parameters);

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenMethodReturnsNull()
        {
            // Arrange
            var sportscardServiceMock = new Mock<ISportscardService>();

            var listAllSportscardsCommand = new ListAllSportscardsCommand(sportscardServiceMock.Object);
            var parameters = new List<string>();

            var sportscards = new List<SportscardDto>();

            sportscardServiceMock
                .Setup(x => x.GetAllSportscards())
                .Returns((IEnumerable<SportscardDto>)null);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => listAllSportscardsCommand.Execute(parameters));
        }
    }
}
