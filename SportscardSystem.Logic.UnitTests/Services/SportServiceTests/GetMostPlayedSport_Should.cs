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

namespace SportscardSystem.Logic.UnitTests.Services.SportServiceTests
{
    [TestClass]
    public class GetMostPlayedSport_Should
    {
        [TestMethod]
        public void ReturnSportDto_WhenThereAreAnySports()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var sport = new Sport()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                Name = "Gym",
                IsDeleted = false
            };

            var visit = new Visit()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                IsDeleted = false,
                Sport = sport,
                Sportshall = new Sportshall() { Name = "Topfit" },
                CreatedOn = DateTime.Now.Date
            };

            var visits = new List<Visit>();
            visits.Add(visit);
            sport.Visits = visits;

            var data = new List<Sport>
            {
                new Sport
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"),
                    Name = "Yoga",
                    IsDeleted = false,
                    Visits = new List<Visit>()
                }
            };
            data.Add(sport);

            var mockSet = new Mock<DbSet<Sport>>();

            mockSet.SetupData(data);

            dbContextMock
                .Setup(x => x.Sports)
                .Returns(mockSet.Object);

            var expectedSportDto = new SportDto()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                Name = "Gym"
            };

            mapperMock
                .Setup(x => x.Map<SportDto>(sport))
                .Returns(expectedSportDto);

            var sportService = new SportService(dbContextMock.Object, mapperMock.Object);

            //Act
            var mostPlayedSport = sportService.GetMostPlayedSport();

            //Assert
            Assert.AreEqual(expectedSportDto.Id, mostPlayedSport.Id);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenThereIsNoSports()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var sport = new Sport()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                Name = "Gym",
                IsDeleted = false
            };

            var visit = new Visit()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                IsDeleted = false,
                Sport = sport,
                Sportshall = new Sportshall() { Name = "Topfit" },
                CreatedOn = DateTime.Now.Date
            };

            var visits = new List<Visit>();
            visits.Add(visit);
            sport.Visits = visits;

            var data = new List<Sport>
            {

            };
            //data.Add(sport);

            var mockSet = new Mock<DbSet<Sport>>();

            mockSet.SetupData(data);

            dbContextMock
                .Setup(x => x.Sports)
                .Returns(mockSet.Object);

            var expectedSportDto = new SportDto()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                Name = "Gym"
            };

            mapperMock
                .Setup(x => x.Map<SportDto>(sport))
                .Returns(expectedSportDto);

            var sportService = new SportService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportService.GetMostPlayedSport());
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenMapperIsUnableToMapSport()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var sport = new Sport()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                Name = "Gym",
                IsDeleted = false
            };

            var visit = new Visit()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                IsDeleted = false,
                Sport = sport,
                Sportshall = new Sportshall() { Name = "Topfit" },
                CreatedOn = DateTime.Now.Date
            };

            var visits = new List<Visit>();
            visits.Add(visit);
            sport.Visits = visits;

            var data = new List<Sport>
            {
                new Sport
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"),
                    Name = "Yoga",
                    IsDeleted = false,
                    Visits = new List<Visit>()
                }
            };
            data.Add(sport);

            var mockSet = new Mock<DbSet<Sport>>();

            mockSet.SetupData(data);

            dbContextMock
                .Setup(x => x.Sports)
                .Returns(mockSet.Object);

            var expectedSportDto = new SportDto()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                Name = "Gym"
            };

            mapperMock
                .Setup(x => x.Map<SportDto>(new Sport()))
                .Returns(expectedSportDto);

            var sportService = new SportService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportService.GetMostPlayedSport());
        }
    }
}
