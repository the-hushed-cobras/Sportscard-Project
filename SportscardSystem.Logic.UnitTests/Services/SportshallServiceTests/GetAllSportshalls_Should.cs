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

namespace SportscardSystem.Logic.UnitTests.Services.SportshallServiceTests
{
    [TestClass]
    public class GetAllSportshalls_Should
    {
        [TestMethod]
        public void ReturnIEnumerableOfSportshallsDto_WhenCollectionIsNotNull()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var data = new List<Sportshall>
            {
                new Sportshall { Name = "Sportshall1" },
                new Sportshall { Name = "Sportshall2" },
                new Sportshall { Name = "Sportshall3" }
            };

            var mockSet = new Mock<DbSet<Sportshall>>();

            mockSet.SetupData(data);
            Mapper.Reset();
            AutomapperConfiguration.Initialize();

            dbContextMock
                .Setup(x => x.Sportshalls)
                .Returns(mockSet.Object);

            var sportshallService = new SportshallService(dbContextMock.Object, mapperMock.Object);

            //Act
            var sportshalls = sportshallService.GetAllSportshalls();

            //Assert
            Assert.AreEqual(data.Count, sportshalls.Count());
            Assert.IsNotNull(sportshalls);
            Assert.IsInstanceOfType(sportshalls, typeof(IEnumerable<ISportshallDto>));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenSportshallsIsNull()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var data = new List<Sportshall>
            {
                new Sportshall { Name = "Sportshall1" },
                new Sportshall { Name = "Sportshall2" },
                new Sportshall { Name = "Sportshall3" }
            };

            var mockSet = new Mock<DbSet<Sportshall>>();

            mockSet.SetupData(data);
            Mapper.Reset();
            AutomapperConfiguration.Initialize();

            dbContextMock
                .Setup(x => x.Sportshalls)
                .Returns((IDbSet<Sportshall>)null);

            var sportService = new SportshallService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportService.GetAllSportshalls());
        }
    }
}
