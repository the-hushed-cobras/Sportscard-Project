using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.ListAll;
using SportscardSystem.DTO;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.ListAll.ListAllVisitsCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CallVisitListAllMethodOnce_WhenInvokedWithValidParameters()
        {
            //Arrange
            var visitServiceMock = new Mock<IVisitService>();

            var listAllVisitsCommand = new ListAllVisitsCommand(visitServiceMock.Object);
            var parameters = new List<string>();

            //Act
            listAllVisitsCommand.Execute(parameters);

            //Assert
            visitServiceMock.Verify(x => x.GetAllVisits(), Times.Once);
        }

        [TestMethod]
        public void ReturnListOfAllVisitsString_WhenInvokedWithValidParameters()
        {
            //Arrange
            var visitServiceMock = new Mock<IVisitService>();

            var listAllVisitsCommand = new ListAllVisitsCommand(visitServiceMock.Object);
            var parameters = new List<string>();

            var visits = new List<VisitViewDto>()
            {
                new VisitViewDto() {Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324")},
                new VisitViewDto() {Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323")}
            };

            visitServiceMock
                .Setup(x => x.GetAllVisits())
                .Returns(visits);

            var expectedMessage = string.Join(Environment.NewLine, visits);

            //Act
            var actualMessage = listAllVisitsCommand.Execute(parameters);

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ReturnNoVisitsMessageString_WhenInvokedWithValidParameters()
        {
            //Arrange
            var visitServiceMock = new Mock<IVisitService>();

            var listAllVisitsCommand = new ListAllVisitsCommand(visitServiceMock.Object);
            var parameters = new List<string>();

            var visits = new List<VisitViewDto>();

            visitServiceMock
                .Setup(x => x.GetAllVisits())
                .Returns(visits);

            var expectedMessage = "There are no visits.";

            //Act
            var actualMessage = listAllVisitsCommand.Execute(parameters);

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenMethodReturnsNull()
        {
            //Arrange
            var visitServiceMock = new Mock<IVisitService>();

            var listAllVisitsCommand = new ListAllVisitsCommand(visitServiceMock.Object);
            var parameters = new List<string>();

            var sports = new List<VisitDto>();

            visitServiceMock
                .Setup(x => x.GetAllVisits())
                .Returns((IEnumerable<VisitViewDto>)null);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => listAllVisitsCommand.Execute(parameters));
        }
    }
}
