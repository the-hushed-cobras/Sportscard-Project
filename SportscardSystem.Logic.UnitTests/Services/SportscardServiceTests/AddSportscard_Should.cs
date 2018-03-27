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

namespace SportscardSystem.Logic.UnitTests.Services.SportscardServiceTests
{
    [TestClass]
    public class AddSportscard_Should
    {
        [TestMethod]
        public void AddSportscardToDabatase_WhenInvokedWithValidParameters()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();
            var expectedSportscard = new Sportscard() { CompanyId = Guid.NewGuid() };

            var data = new List<Sportscard>
            {
                new Sportscard { CreatedOn = DateTime.Today.AddDays(-1)  }
            };

            var mockSet = new Mock<DbSet<Sportscard>>();

            mockSet.SetupData(data);
            mockSet.Setup(m => m.Add(It.IsAny<Sportscard>()));

            dbContextMock
                .Setup(x => x.Sportscards)
                .Returns(mockSet.Object);

            var sportscardDto = new SportscardDto() { CompanyId = Guid.NewGuid() };

            mapperMock
                .Setup(x => x.Map<Sportscard>(sportscardDto))
                .Returns(expectedSportscard);

            var sportscardService = new SportscardService(dbContextMock.Object, mapperMock.Object);

            //Act
            sportscardService.AddSportscard(sportscardDto);

            //Assert
            mockSet.Verify(x => x.Add(expectedSportscard), Times.Once);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidParameter()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            SportscardDto sportscardDto = null;
            var sportscardService = new SportscardService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportscardService.AddSportscard(sportscardDto));
        }
    }
}
