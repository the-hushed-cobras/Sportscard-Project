using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.Architecture.Automapper;
using SportscardSystem.Data.Contracts;
using SportscardSystem.DTO;
using SportscardSystem.Logic.Services;
using SportscardSystem.Models;

namespace SportscardSystem.Logic.UnitTests.Services.VisitServiceTests
{
    [TestClass]
    public class GetVisitsByClient_Should
    {
        [TestMethod]
        public void ReturnCollectionOfIVisitViewDto_WhenTheGivenClientExists()
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
                    Sportshall = new Sportshall() { Name = "Pulse" },
                    CreatedOn = DateTime.Now.Date
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

            var visitService = new VisitService(dbContextMock.Object, mapperMock.Object);

            //Act
            var visitsByClient = visitService.GetVisitsByClient(client.FirstName, client.LastName);

            //Assert
            Assert.AreEqual(client.Id, visitsByClient.FirstOrDefault().Id);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullFirstNameParameter()
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
                    Sportshall = new Sportshall() { Name = "Pulse" },
                    CreatedOn = DateTime.Now.Date
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

            var visitService = new VisitService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => visitService.GetVisitsByClient(null, client.LastName));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyFirstNameParameter()
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
                    Sportshall = new Sportshall() { Name = "Pulse" },
                    CreatedOn = DateTime.Now.Date
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

            var visitService = new VisitService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => visitService.GetVisitsByClient(string.Empty, client.LastName));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullLastNameParameter()
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
                    Sportshall = new Sportshall() { Name = "Pulse" },
                    CreatedOn = DateTime.Now.Date
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

            var visitService = new VisitService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => visitService.GetVisitsByClient(client.FirstName, null));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyLastNameParameter()
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
                    Sportshall = new Sportshall() { Name = "Pulse" },
                    CreatedOn = DateTime.Now.Date
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

            var visitService = new VisitService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => visitService.GetVisitsByClient(client.FirstName, string.Empty));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidParameters()
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
                    Sportshall = new Sportshall() { Name = "Pulse" },
                    CreatedOn = DateTime.Now.Date
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

            var visitService = new VisitService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => visitService.GetVisitsByClient("Gosho", "Goshev"));
        }
    }
}
