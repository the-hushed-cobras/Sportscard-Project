using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.Architecture.Automapper;
using SportscardSystem.Data.Contracts;
using SportscardSystem.DTO;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.Logic.Services;
using SportscardSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SportscardSystem.Logic.UnitTests.Services.SportscardServiceTests
{
    [TestClass]
    public class GetAllSportscards_Should
    {
        [TestMethod]
        public void ReturnIEnumerableOfSportscardsDto_WhenCollectionIsNotNull()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var data = new List<Sportscard>
            {
                new Sportscard { CreatedOn = DateTime.Today.AddDays(-1)  }
            };

            var mockSet = new Mock<DbSet<Sportscard>>();

            mockSet.SetupData(data);
            Mapper.Reset();
            AutomapperConfiguration.Initialize();

            dbContextMock
                .Setup(x => x.Sportscards)
                .Returns(mockSet.Object);

            var sportscardDto = new SportscardDto() { CompanyId = Guid.NewGuid() };

            var sportscardService = new SportscardService(dbContextMock.Object, mapperMock.Object);

            //Act
            var sportscards = sportscardService.GetAllSportscards();

            //Assert
            Assert.AreEqual(data.Count, sportscards.Count());
            Assert.IsNotNull(sportscards);
            Assert.IsInstanceOfType(sportscards, typeof(IEnumerable<ISportscardDto>));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenSportscardsIsNull()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var data = new List<Sportscard>
            {
                new Sportscard { CreatedOn = DateTime.Today.AddDays(-1)  }
            };

            var mockSet = new Mock<DbSet<Sportscard>>();

            mockSet.SetupData(data);
            Mapper.Reset();
            AutomapperConfiguration.Initialize();

            dbContextMock
                .Setup(x => x.Sportscards)
                .Returns((IDbSet<Sportscard>)null);

            var sportscardDto = new SportscardDto() { CompanyId = Guid.NewGuid() };

            var sportscardService = new SportscardService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportscardService.GetAllSportscards());
        }
    }
}
