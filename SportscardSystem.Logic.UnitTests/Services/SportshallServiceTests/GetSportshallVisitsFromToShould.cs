using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.Architecture.Automapper;
using SportscardSystem.Data.Contracts;
using SportscardSystem.Logic.Services;
using SportscardSystem.Models;

namespace SportscardSystem.Logic.UnitTests.Services.SportshallServiceTests
{
    [TestClass]
    public class GetSportshallVisitsFromToShould
    {
        [TestMethod]
        public void ReturnCollectionOfIVisitViewDto_WhenThereIsAnyVisitsFromAndToTheGivenDate()
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
                    CreatedOn = DateTime.Parse("2018-03-27")
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
                    CreatedOn = DateTime.Parse("2018-03-29")
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

            var sportshallService = new SportshallService(dbContextMock.Object, mapperMock.Object);

            //Act
            var sportshallVisitsFrom = sportshallService.GetSportshallVisitFromTo("Topfit", "2018-03-27", "2018-03-29");

            //Assert
            Assert.AreEqual(2, sportshallVisitsFrom.Count());
        }

        [TestMethod]
        public void ReturnEmptyCollectionOfIVisitViewDto_WhenThereIsNoVisitsFromAndToTheGivenDate()
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
                    CreatedOn = DateTime.Parse("2018-03-27")
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
                    CreatedOn = DateTime.Parse("2018-03-29")
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

            var sportshallService = new SportshallService(dbContextMock.Object, mapperMock.Object);

            //Act
            var sportshallVisitsFrom = sportshallService.GetSportshallVisitFromTo("Topfit", "2017-03-27", "2017-03-29");

            //Assert
            Assert.AreEqual(0, sportshallVisitsFrom.Count());
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidFromEmptyDateParameter()
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
                    CreatedOn = DateTime.Parse("2018-03-27")
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
                    CreatedOn = DateTime.Parse("2018-03-29")
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

            var sportshallService = new SportshallService(dbContextMock.Object, mapperMock.Object);

            //Act&Assert
            Assert.ThrowsException<ArgumentException>(() => sportshallService.GetSportshallVisitFromTo("Topfit", string.Empty, "2017-03-29"));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyToDateParameter()
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
                    CreatedOn = DateTime.Parse("2018-03-27")
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
                    CreatedOn = DateTime.Parse("2018-03-29")
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

            var sportshallService = new SportshallService(dbContextMock.Object, mapperMock.Object);

            //Act&Assert
            Assert.ThrowsException<ArgumentException>(() => sportshallService.GetSportshallVisitFromTo("Topfit", "2018-03-27", string.Empty));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptySportshallParameter()
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
                    CreatedOn = DateTime.Parse("2018-03-27")
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
                    CreatedOn = DateTime.Parse("2018-03-29")
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

            var sportshallService = new SportshallService(dbContextMock.Object, mapperMock.Object);

            //Act&Assert
            Assert.ThrowsException<ArgumentException>(() => sportshallService.GetSportshallVisitFromTo(String.Empty, "2018-03-27", "2018-03-29"));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenThereIsNoSportshallWithTheGivenName()
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
                    CreatedOn = DateTime.Parse("2018-03-27")
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
                    CreatedOn = DateTime.Parse("2018-03-29")
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

            var sportshallService = new SportshallService(dbContextMock.Object, mapperMock.Object);

            //Act&Assert
            Assert.ThrowsException<ArgumentException>(() => sportshallService.GetSportshallVisitFromTo("Test", "2018-03-27", "2018-03-29"));
        }

        [TestMethod]
        public void ThrowNullArgumentException_WhenInvokedWithInvalidNullFromDateParameter()
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
                    CreatedOn = DateTime.Parse("2018-03-27")
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
                    CreatedOn = DateTime.Parse("2018-03-29")
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

            var sportshallService = new SportshallService(dbContextMock.Object, mapperMock.Object);

            //Act&Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportshallService.GetSportshallVisitFromTo("Test", null, "2018-03-29"));
        }

        [TestMethod]
        public void ThrowNullArgumentException_WhenInvokedWithInvalidNullToDateParameter()
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
                    CreatedOn = DateTime.Parse("2018-03-27")
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
                    CreatedOn = DateTime.Parse("2018-03-29")
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

            var sportshallService = new SportshallService(dbContextMock.Object, mapperMock.Object);

            //Act&Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportshallService.GetSportshallVisitFromTo("Test", "2018-03-27", null));
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
                    CreatedOn = DateTime.Parse("2018-03-27")
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
                    CreatedOn = DateTime.Parse("2018-03-29")
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

            var sportshallService = new SportshallService(dbContextMock.Object, mapperMock.Object);

            //Act&Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportshallService.GetSportshallVisitFromTo(null, "2018-03-27", "2018-03-29"));
        }
    }
}
