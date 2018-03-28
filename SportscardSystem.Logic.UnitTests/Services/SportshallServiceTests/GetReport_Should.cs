using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.Architecture.Automapper;
using SportscardSystem.Data.Contracts;
using SportscardSystem.Logic.Services;
using SportscardSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SportscardSystem.Logic.UnitTests.Services.SportshallServiceTests
{
    [TestClass]
    public class GetReport_Should
    {
        [TestMethod]
        public void ReturnCollectionOfISportscardViewDto_WhenAnySportscardsExist()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var firstSport = new Sport()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                Name = "Gym",
                IsDeleted = false
            };

            var secondSport = new Sport()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                Name = "Yoga",
                IsDeleted = false
            };

            var sports = new List<Sport>();
            sports.Add(firstSport);
            sports.Add(secondSport);

            var data = new List<Sportshall>
            {
                new Sportshall
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271322"),
                    Name = "Topfit",
                    Sports = sports,
                    IsDeleted = false

                },
                new Sportshall
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271321"),
                    Name = "Pulse",
                    Sports = sports,
                    IsDeleted = false
                }
            };

            var mockSet = new Mock<DbSet<Sportshall>>();
            var mockSetSports = new Mock<DbSet<Sport>>();

            mockSet.SetupData(data);
            mockSetSports.SetupData(sports);

            Mapper.Reset();
            AutomapperConfiguration.Initialize();

            dbContextMock
                .Setup(x => x.Sports)
                .Returns(mockSetSports.Object);

            dbContextMock
                .Setup(x => x.Sportshalls)
                .Returns(mockSet.Object);

            var sportscardService = new SportshallService(dbContextMock.Object, mapperMock.Object);

            //Act
            var sportscardsReport = sportscardService.GetReport();

            //Assert
            Assert.AreEqual(2, sportscardsReport.Count());
        }

        [TestMethod]
        public void ThrowArgumentException_WhenThereIsNoSportshalls()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var firstSport = new Sport()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                Name = "Gym",
                IsDeleted = false
            };

            var secondSport = new Sport()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                Name = "Yoga",
                IsDeleted = false
            };

            var sports = new List<Sport>();
            sports.Add(firstSport);
            sports.Add(secondSport);

            var data = new List<Sportshall>();
            //{
            //    new Sportshall
            //    {
            //        Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271322"),
            //        Name = "Topfit",
            //        Sports = sports,
            //        IsDeleted = false

            //    },
            //    new Sportshall
            //    {
            //        Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271321"),
            //        Name = "Pulse",
            //        Sports = sports,
            //        IsDeleted = false
            //    }
            //};

            var mockSet = new Mock<DbSet<Sportshall>>();
            var mockSetSports = new Mock<DbSet<Sport>>();

            mockSet.SetupData(data);
            mockSetSports.SetupData(sports);

            Mapper.Reset();
            AutomapperConfiguration.Initialize();

            dbContextMock
                .Setup(x => x.Sports)
                .Returns(mockSetSports.Object);

            dbContextMock
                .Setup(x => x.Sportshalls)
                .Returns(mockSet.Object);

            var sportscardService = new SportshallService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => sportscardService.GetReport());
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenSportshallsIsNull()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var firstSport = new Sport()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                Name = "Gym",
                IsDeleted = false
            };

            var secondSport = new Sport()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                Name = "Yoga",
                IsDeleted = false
            };

            var sports = new List<Sport>();
            sports.Add(firstSport);
            sports.Add(secondSport);

            var data = new List<Sportshall>()
            {
                new Sportshall
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271322"),
                    Name = "Topfit",
                    Sports = sports,
                    IsDeleted = false

                },
                new Sportshall
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271321"),
                    Name = "Pulse",
                    Sports = sports,
                    IsDeleted = false
                }
            };

            var mockSet = new Mock<DbSet<Sportshall>>();
            var mockSetSports = new Mock<DbSet<Sport>>();

            mockSet.SetupData(data);
            mockSetSports.SetupData(sports);

            Mapper.Reset();
            AutomapperConfiguration.Initialize();

            dbContextMock
                .Setup(x => x.Sports)
                .Returns(mockSetSports.Object);

            dbContextMock
                .Setup(x => x.Sportshalls)
                .Returns((IDbSet<Sportshall>)null);

            var sportscardService = new SportshallService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportscardService.GetReport());
        }
    }
}
