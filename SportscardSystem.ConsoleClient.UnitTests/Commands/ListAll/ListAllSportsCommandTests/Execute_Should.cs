using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.ListAll;
using SportscardSystem.DTO;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.ListAll.ListAllSportsCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CallSportListAllMethodOnce_WhenInvokedWithValidParameters()
        {
            //Arrange
            var sportServiceMock = new Mock<ISportService>();

            var listAllSportsCommand = new ListAllSportsCommand(sportServiceMock.Object);
            var parameters = new List<string>();

            //Act
            listAllSportsCommand.Execute(parameters);

            //Assert
            sportServiceMock.Verify(x => x.GetAllSports(), Times.Once);
        }

        [TestMethod]
        public void ReturnListOfAllVisitsString_WhenInvokedWithValidParameters()
        {
            //Arrange
            var sportServiceMock = new Mock<ISportService>();

            var listAllSportsCommand = new ListAllSportsCommand(sportServiceMock.Object);
            var parameters = new List<string>();

            var sports = new List<SportDto>()
            {
                new SportDto() {Name = "Gym"},
                new SportDto() {Name = "Yoga"}
            };

            sportServiceMock
                .Setup(x => x.GetAllSports())
                .Returns(sports);

            var expectedMessage = string.Join(Environment.NewLine, sports);

            //Act
            var actualMessage = listAllSportsCommand.Execute(parameters);

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ReturnNoSportsMessageString_WhenInvokedWithValidParameters()
        {
            //Arrange
            var sportServiceMock = new Mock<ISportService>();

            var listAllSportsCommand = new ListAllSportsCommand(sportServiceMock.Object);
            var parameters = new List<string>();

            var sports = new List<SportDto>();

            sportServiceMock
                .Setup(x => x.GetAllSports())
                .Returns(sports);

            var expectedMessage = "There are no registered sports.";

            //Act
            var actualMessage = listAllSportsCommand.Execute(parameters);

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenMethodReturnsNull()
        {
            //Arrange
            var sportServiceMock = new Mock<ISportService>();

            var listAllSportsCommand = new ListAllSportsCommand(sportServiceMock.Object);
            var parameters = new List<string>();

            var sports = new List<SportDto>();

            sportServiceMock
                .Setup(x => x.GetAllSports())
                .Returns((IEnumerable<SportDto>)null);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => listAllSportsCommand.Execute(parameters));
        }
    }
}
