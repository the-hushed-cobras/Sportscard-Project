using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.Architecture.Automapper;
using SportscardSystem.Data.Contracts;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.Logic.Services;
using SportscardSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SportscardSystem.Logic.UnitTests.Services.SportServiceTests
{
    [TestClass]
    public class GetAllSports_Should
    {
        public void ReturnIEnumerableOfSportDto_WhenCollectionIsNotNull()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var data = new List<Sport>
            {
                new Sport { Name = "Gym" },
                new Sport { Name = "Yoga" },
                new Sport { Name = "Pilates" }
            };

            var mockSet = new Mock<DbSet<Sport>>();

            mockSet.SetupData(data);
            Mapper.Reset();
            AutomapperConfiguration.Initialize();

            dbContextMock
                .Setup(x => x.Sports)
                .Returns(mockSet.Object);

            var sportService = new SportService(dbContextMock.Object, mapperMock.Object);

            //Act
            var sports = sportService.GetAllSports();

            //Assert
            Assert.AreEqual(data.Count, sports.Count());
            Assert.IsNotNull(sports);
            Assert.IsInstanceOfType(sports, typeof(IEnumerable<ISportDto>));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenSportsIsNull()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var data = new List<Sport>
            {
                new Sport { Name = "Gym" },
                new Sport { Name = "Yoga" },
                new Sport { Name = "Pilates" }
            };

            var mockSet = new Mock<DbSet<Sport>>();

            mockSet.SetupData(data);
            Mapper.Reset();
            AutomapperConfiguration.Initialize();

            dbContextMock
                .Setup(x => x.Sports)
                .Returns((IDbSet<Sport>)null);

            var sportService = new SportService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportService.GetAllSports());
        }
    }
}
