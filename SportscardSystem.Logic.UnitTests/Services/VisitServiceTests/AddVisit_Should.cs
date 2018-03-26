using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.Data.Contracts;
using SportscardSystem.DTO;
using SportscardSystem.Logic.Services;
using SportscardSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace SportscardSystem.Logic.UnitTests.Services.VisitServiceTests
{
    [TestClass]
    public class AddVisit_Should
    {
        [TestMethod]
        public void AddVisitToDabatase_WhenInvokedWithValidParameters()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();
            var expectedVisit = new Visit() { ClientId = Guid.NewGuid() };

            var data = new List<Visit>
            {
                new Visit { CreatedOn = DateTime.Today.AddDays(-1)  }
            };

            var mockSet = new Mock<DbSet<Visit>>();

            mockSet.SetupData(data);
            mockSet.Setup(m => m.Add(It.IsAny<Visit>()));

            dbContextMock
                .Setup(x => x.Visits)
                .Returns(mockSet.Object);

            var visitDto = new VisitDto() { ClientId = Guid.NewGuid() };

            mapperMock
                .Setup(x => x.Map<Visit>(visitDto))
                .Returns(expectedVisit);

            var visitService = new VisitService(dbContextMock.Object, mapperMock.Object);

            //Act
            visitService.AddVisit(visitDto);

            //Assert
            mockSet.Verify(x => x.Add(expectedVisit), Times.Once);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidParameter()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            VisitDto visitDto = null;
            var visitService = new VisitService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => visitService.AddVisit(visitDto));
        }
    }
}
