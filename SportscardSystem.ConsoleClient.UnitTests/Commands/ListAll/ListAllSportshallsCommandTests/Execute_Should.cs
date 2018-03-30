using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.ListAll;
using SportscardSystem.DTO;
using SportscardSystem.Logic.Services.Contracts;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.ListAll.ListAllSportshallsCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CallSportshallsListAllMethodOnce_WhenInvokedWithValidParameters()
        {
            //Arrange
            var sportshallsServiceMock = new Mock<ISportshallService>();

            var listAllSportshallsCommand = new ListAllSportshallsCommand(sportshallsServiceMock.Object);
            var parameters = new List<string>();

            //Act
            listAllSportshallsCommand.Execute(parameters);

            //Assert
            sportshallsServiceMock.Verify(x => x.GetAllSportshalls(), Times.Once);
        }

        [TestMethod]
        public void ReturnListOfAllCompaniesString_WhenInvokedWithValidParameters()
        {
            //Arrange
            var sportshallServiceMock = new Mock<ISportshallService>();

            var listAllSportshallsCommand = new ListAllSportshallsCommand(sportshallServiceMock.Object);
            var parameters = new List<string>();

            var sportshalls = new List<SportshallDto>()
            {
                new SportshallDto() {Name = "Topfit"},
                new SportshallDto() {Name = "Titanium"}
            };

            sportshallServiceMock
                .Setup(x => x.GetAllSportshalls())
                .Returns(sportshalls);

            var expectedMessage = string.Join(Environment.NewLine, sportshalls);

            //Act
            var actualMessage = listAllSportshallsCommand.Execute(parameters);

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ReturnNoSportsMessageString_WhenInvokedWithValidParameters()
        {
            //Arrange
            var sportshallServiceMock = new Mock<ISportshallService>();

            var listAllSportshallsCommand = new ListAllSportshallsCommand(sportshallServiceMock.Object);
            var parameters = new List<string>();

            var sportshalls = new List<SportshallDto>();

            sportshallServiceMock
                .Setup(x => x.GetAllSportshalls())
                .Returns(sportshalls);

            var expectedMessage = "There are no registered sportshalls.";

            //Act
            var actualMessage = listAllSportshallsCommand.Execute(parameters);

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenMethodReturnsNull()
        {
            //Arrange
            var sportshallServiceMock = new Mock<ISportshallService>();

            var listAllSportshallCommand = new ListAllSportshallsCommand(sportshallServiceMock.Object);
            var parameters = new List<string>();

            var sportshalls = new List<SportshallDto>();

            sportshallServiceMock
                .Setup(x => x.GetAllSportshalls())
                .Returns((IEnumerable<SportshallDto>)null);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => listAllSportshallCommand.Execute(parameters));
        }
    }
}
