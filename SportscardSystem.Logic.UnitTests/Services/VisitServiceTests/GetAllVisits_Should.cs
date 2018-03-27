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

namespace SportscardSystem.Logic.UnitTests.Services.VisitServiceTests
{
    [TestClass]
    public class GetAllVisits_Should
    {
        [TestMethod]
        public void ReturnIEnumerableOfVisitDto_WhenCollectionIsNotNull()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var data = new List<Visit>
            {
                new Visit { CreatedOn = DateTime.Today.AddDays(-1)  }
            };

            var mockSet = new Mock<DbSet<Visit>>();

            mockSet.SetupData(data);

            Mapper.Reset();
            AutomapperConfiguration.Initialize();

            dbContextMock
                .Setup(x => x.Visits)
                .Returns(mockSet.Object);

            var visitService = new VisitService(dbContextMock.Object, mapperMock.Object);

            //Act
            var visits = visitService.GetAllVisits();

            //Assert
            Assert.AreEqual(data.Count, visits.Count());
            Assert.IsNotNull(visits);
            Assert.IsInstanceOfType(visits, typeof(IEnumerable<IVisitDto>));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenSportshallsIsNull()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var data = new List<Visit>
            {
                new Visit { CreatedOn = DateTime.Today.AddDays(-1)  }
            };

            var mockSet = new Mock<DbSet<Visit>>();

            mockSet.SetupData(data);

            Mapper.Reset();
            AutomapperConfiguration.Initialize();

            dbContextMock
                .Setup(x => x.Visits)
                 .Returns((IDbSet<Visit>)null);

            var visitService = new VisitService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => visitService.GetAllVisits());
        }
    }
}
