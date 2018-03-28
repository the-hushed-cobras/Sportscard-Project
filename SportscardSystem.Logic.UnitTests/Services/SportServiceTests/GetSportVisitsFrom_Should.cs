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

namespace SportscardSystem.Logic.UnitTests.Services.SportServiceTests
{
    [TestClass]
    public class GetSportVisitsFrom_Should
    {
        [TestMethod]
        public void ReturnCollectionOfIVisitViewDto_WhenThereIsAnyVisitsFromTheGivenDate()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var client = new Client()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                FirstName = "Georgi",
                LastName = "Georgiev",
                IsDeleted = false,
                Visits = new List<Visit>()
            };

            var visit = new Visit()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                Client = client,
                IsDeleted = false,
                Sport = new Sport() { Name = "Gym" },
                Sportshall = new Sportshall() { Name = "Topfit" },
                CreatedOn = DateTime.Now.Date
            };

            var data = new List<Visit>
            {
                new Visit()
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"),
                    Client = new Client()
                    {
                        FirstName = "Pesho",
                        LastName = "Peshev"
                    },
                    IsDeleted = false,
                    Sport = new Sport() { Name = "Gym" },
                    Sportshall = new Sportshall() { Name = "Topfit" },
                    CreatedOn = DateTime.Now.AddDays(-1)
                },
                new Visit()
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271322"),
                    Client = new Client()
                    {
                        FirstName = "Gosho",
                        LastName = "Goshev"
                    },
                    IsDeleted = false,
                    Sport = new Sport() { Name = "Gym" },
                    Sportshall = new Sportshall() { Name = "Topfit" },
                    CreatedOn = DateTime.Now.AddDays(-10)
                }
            };

            data.Add(visit);

            var mockSet = new Mock<DbSet<Visit>>();

            mockSet.SetupData(data);
            Mapper.Reset();
            AutomapperConfiguration.Initialize();

            dbContextMock
                .Setup(x => x.Visits)
                .Returns(mockSet.Object);

            var sportService = new SportService(dbContextMock.Object, mapperMock.Object);

            //Act
            var sportVisitsFrom = sportService.GetSportVisitsFrom("Gym", "2018-03-27");

            //Assert
            Assert.AreEqual(2, sportVisitsFrom.Count());
        }

        [TestMethod]
        public void ThrowNullArgumentException_WhenInvokedWithInvalidNullSportNameParameter()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var client = new Client()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                FirstName = "Georgi",
                LastName = "Georgiev",
                IsDeleted = false,
                Visits = new List<Visit>()
            };

            var visit = new Visit()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                Client = client,
                IsDeleted = false,
                Sport = new Sport() { Name = "Gym" },
                Sportshall = new Sportshall() { Name = "Topfit" },
                CreatedOn = DateTime.Now.Date
            };

            var data = new List<Visit>
            {
                new Visit()
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"),
                    Client = new Client()
                    {
                        FirstName = "Pesho",
                        LastName = "Peshev"
                    },
                    IsDeleted = false,
                    Sport = new Sport() { Name = "Yoga" },
                    Sportshall = new Sportshall() { Name = "Topfit" },
                    CreatedOn = DateTime.Now.AddDays(-1)
                },
                new Visit()
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271322"),
                    Client = new Client()
                    {
                        FirstName = "Gosho",
                        LastName = "Goshev"
                    },
                    IsDeleted = false,
                    Sport = new Sport() { Name = "Boxing" },
                    Sportshall = new Sportshall() { Name = "Topfit" },
                    CreatedOn = DateTime.Now.AddDays(-10)
                }
            };

            data.Add(visit);

            var mockSet = new Mock<DbSet<Visit>>();

            mockSet.SetupData(data);
            Mapper.Reset();
            AutomapperConfiguration.Initialize();

            dbContextMock
                .Setup(x => x.Visits)
                .Returns(mockSet.Object);

            var sportService = new SportService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportService.GetSportVisitsFrom(null, "2018-03-27"));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptySportNameParameter()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var client = new Client()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                FirstName = "Georgi",
                LastName = "Georgiev",
                IsDeleted = false,
                Visits = new List<Visit>()
            };

            var expectedVisit = new Visit()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                Client = client,
                IsDeleted = false,
                Sport = new Sport() { Name = "Gym" },
                Sportshall = new Sportshall() { Name = "Topfit" },
                CreatedOn = DateTime.Now.Date
            };

            var data = new List<Visit>
            {
                new Visit()
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"),
                    Client = new Client()
                    {
                        FirstName = "Pesho",
                        LastName = "Peshev"
                    },
                    IsDeleted = false,
                    Sport = new Sport() { Name = "Yoga" },
                    Sportshall = new Sportshall() { Name = "Topfit" },
                    CreatedOn = DateTime.Now.AddDays(-1)
                },
                new Visit()
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271322"),
                    Client = new Client()
                    {
                        FirstName = "Gosho",
                        LastName = "Goshev"
                    },
                    IsDeleted = false,
                    Sport = new Sport() { Name = "Boxing" },
                    Sportshall = new Sportshall() { Name = "Topfit" },
                    CreatedOn = DateTime.Now.AddDays(-10)
                }
            };

            data.Add(expectedVisit);

            var mockSet = new Mock<DbSet<Visit>>();

            mockSet.SetupData(data);
            Mapper.Reset();
            AutomapperConfiguration.Initialize();

            dbContextMock
                .Setup(x => x.Visits)
                .Returns(mockSet.Object);

            var sportService = new SportService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => sportService.GetSportVisitsFrom(string.Empty, "2018-03-27"));
        }

        [TestMethod]
        public void ThrowNullArgumentException_WhenInvokedWithInvalidNullDateParameter()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var client = new Client()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                FirstName = "Georgi",
                LastName = "Georgiev",
                IsDeleted = false,
                Visits = new List<Visit>()
            };

            var visit = new Visit()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                Client = client,
                IsDeleted = false,
                Sport = new Sport() { Name = "Gym" },
                Sportshall = new Sportshall() { Name = "Topfit" },
                CreatedOn = DateTime.Now.Date
            };

            var data = new List<Visit>
            {
                new Visit()
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"),
                    Client = new Client()
                    {
                        FirstName = "Pesho",
                        LastName = "Peshev"
                    },
                    IsDeleted = false,
                    Sport = new Sport() { Name = "Yoga" },
                    Sportshall = new Sportshall() { Name = "Topfit" },
                    CreatedOn = DateTime.Now.AddDays(-1)
                },
                new Visit()
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271322"),
                    Client = new Client()
                    {
                        FirstName = "Gosho",
                        LastName = "Goshev"
                    },
                    IsDeleted = false,
                    Sport = new Sport() { Name = "Boxing" },
                    Sportshall = new Sportshall() { Name = "Topfit" },
                    CreatedOn = DateTime.Now.AddDays(-10)
                }
            };

            data.Add(visit);

            var mockSet = new Mock<DbSet<Visit>>();

            mockSet.SetupData(data);
            Mapper.Reset();
            AutomapperConfiguration.Initialize();

            dbContextMock
                .Setup(x => x.Visits)
                .Returns(mockSet.Object);

            var sportService = new SportService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportService.GetSportVisitsFrom("Topfit", null));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyDateParameter()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var client = new Client()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                FirstName = "Georgi",
                LastName = "Georgiev",
                IsDeleted = false,
                Visits = new List<Visit>()
            };

            var visit = new Visit()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                Client = client,
                IsDeleted = false,
                Sport = new Sport() { Name = "Gym" },
                Sportshall = new Sportshall() { Name = "Topfit" },
                CreatedOn = DateTime.Now.Date
            };

            var data = new List<Visit>
            {
                new Visit()
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"),
                    Client = new Client()
                    {
                        FirstName = "Pesho",
                        LastName = "Peshev"
                    },
                    IsDeleted = false,
                    Sport = new Sport() { Name = "Yoga" },
                    Sportshall = new Sportshall() { Name = "Topfit" },
                    CreatedOn = DateTime.Now.AddDays(-1)
                },
                new Visit()
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271322"),
                    Client = new Client()
                    {
                        FirstName = "Gosho",
                        LastName = "Goshev"
                    },
                    IsDeleted = false,
                    Sport = new Sport() { Name = "Boxing" },
                    Sportshall = new Sportshall() { Name = "Topfit" },
                    CreatedOn = DateTime.Now.AddDays(-10)
                }
            };

            data.Add(visit);

            var mockSet = new Mock<DbSet<Visit>>();

            mockSet.SetupData(data);
            Mapper.Reset();
            AutomapperConfiguration.Initialize();

            dbContextMock
                .Setup(x => x.Visits)
                .Returns(mockSet.Object);

            var sportService = new SportService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => sportService.GetSportVisitsFrom("Topfit", string.Empty));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenThereIsNoSportWithTheGivenName()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var client = new Client()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                FirstName = "Georgi",
                LastName = "Georgiev",
                IsDeleted = false,
                Visits = new List<Visit>()
            };

            var visit = new Visit()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                Client = client,
                IsDeleted = false,
                Sport = new Sport() { Name = "Gym" },
                Sportshall = new Sportshall() { Name = "Topfit" },
                CreatedOn = DateTime.Now.Date
            };

            var data = new List<Visit>
            {
                new Visit()
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"),
                    Client = new Client()
                    {
                        FirstName = "Pesho",
                        LastName = "Peshev"
                    },
                    IsDeleted = false,
                    Sport = new Sport() { Name = "Yoga" },
                    Sportshall = new Sportshall() { Name = "Topfit" },
                    CreatedOn = DateTime.Now.AddDays(-1)
                },
                new Visit()
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271322"),
                    Client = new Client()
                    {
                        FirstName = "Gosho",
                        LastName = "Goshev"
                    },
                    IsDeleted = false,
                    Sport = new Sport() { Name = "Boxing" },
                    Sportshall = new Sportshall() { Name = "Topfit" },
                    CreatedOn = DateTime.Now.AddDays(-10)
                }
            };

            data.Add(visit);

            var mockSet = new Mock<DbSet<Visit>>();

            mockSet.SetupData(data);
            Mapper.Reset();
            AutomapperConfiguration.Initialize();

            dbContextMock
                .Setup(x => x.Visits)
                .Returns(mockSet.Object);

            var sportService = new SportService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => sportService.GetSportVisitsFrom("TEST", "2018-03-27"));
        }

        [TestMethod]
        public void ReturnEmptyCollection_WhenThereIsNoVisitsFromTheGivenDate()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var client = new Client()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                FirstName = "Georgi",
                LastName = "Georgiev",
                IsDeleted = false,
                Visits = new List<Visit>()
            };

            var visit = new Visit()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                Client = client,
                IsDeleted = false,
                Sport = new Sport() { Name = "Gym" },
                Sportshall = new Sportshall() { Name = "Topfit" },
                CreatedOn = DateTime.Now.Date
            };

            var data = new List<Visit>
            {
                new Visit()
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"),
                    Client = new Client()
                    {
                        FirstName = "Pesho",
                        LastName = "Peshev"
                    },
                    IsDeleted = false,
                    Sport = new Sport() { Name = "Yoga" },
                    Sportshall = new Sportshall() { Name = "Topfit" },
                    CreatedOn = DateTime.Now.AddDays(-1)
                },
                new Visit()
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271322"),
                    Client = new Client()
                    {
                        FirstName = "Gosho",
                        LastName = "Goshev"
                    },
                    IsDeleted = false,
                    Sport = new Sport() { Name = "Boxing" },
                    Sportshall = new Sportshall() { Name = "Topfit" },
                    CreatedOn = DateTime.Now.AddDays(-10)
                }
            };

            data.Add(visit);

            var mockSet = new Mock<DbSet<Visit>>();

            mockSet.SetupData(data);
            Mapper.Reset();
            AutomapperConfiguration.Initialize();

            dbContextMock
                .Setup(x => x.Visits)
                .Returns(mockSet.Object);

            var sportService = new SportService(dbContextMock.Object, mapperMock.Object);

            //Act
            var sportVisits = sportService.GetSportVisitsFrom("Gym", "2018-03-29");

            //Assert
            Assert.AreEqual(0, sportVisits.Count());
        }
    }
}
