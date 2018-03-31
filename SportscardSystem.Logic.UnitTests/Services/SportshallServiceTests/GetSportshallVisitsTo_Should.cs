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
    public class GetSportshallVisitsFrom_Should
    {
        [TestMethod]
        public void ReturnCollectionOfIVisitViewDto_WhenThereIsAnyVisitsUntilTheGivenDate()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var client = new Client()
            {
                Id = new Guid("19818bfe-7593-4ead-bc03-53a147457e97"),
                FirstName = "Marisha",
                LastName = "Ray",
                Visits = new List<Visit>(),
                IsDeleted = false
            };

            var visit = new Visit()
            {
                Id = new Guid("a4d786fe-08b6-4ed9-9179-fbac9518ecbf"),
                Client = client,
                Sport = new Sport() { Name = "Zumba" },
                Sportshall = new Sportshall() { Name = "MladostGym" },
                CreatedOn = DateTime.Parse("2018-03-31"),
                IsDeleted = false
            };

            var data = new List<Visit>
            {
                new Visit()
                {
                    Id = new Guid("ea4e97d7-cc63-4d94-8893-09520cc61ec7"),
                    Client = new Client()
                    {
                        FirstName = "Laura",
                        LastName = "Bailey"
                    },
                    Sport = new Sport() { Name = "Yoga" },
                    Sportshall = new Sportshall() { Name = "MladostGym" },
                    CreatedOn = DateTime.Parse("2018-03-04"),
                    IsDeleted = false,
                },
                new Visit()
                {
                    Id = new Guid("992fc71d-4055-4b57-84bd-4f28057f212d"),
                    Client = new Client()
                    {
                        FirstName = "Liam",
                        LastName = "O'Brian"
                    },
                    Sport = new Sport() { Name = "Pilates" },
                    Sportshall = new Sportshall() { Name = "MladostGym" },
                    CreatedOn = DateTime.Parse("2018-03-21"),
                    IsDeleted = false,
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
            var sportshallVisitsFrom = sportshallService.GetSportshallVisitsTo("MladostGym", "2018-03-27");

            //Assert
            Assert.AreEqual(2, sportshallVisitsFrom.Count());
        }

        [TestMethod]
        public void ThrowNullArgumentException_WhenInvokedWithInvalidNullSportshallNameParameter()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var client = new Client()
            {
                Id = new Guid("19818bfe-7593-4ead-bc03-53a147457e97"),
                FirstName = "Marisha",
                LastName = "Ray",
                Visits = new List<Visit>(),
                IsDeleted = false
            };

            var visit = new Visit()
            {
                Id = new Guid("a4d786fe-08b6-4ed9-9179-fbac9518ecbf"),
                Client = client,
                Sport = new Sport() { Name = "Zumba" },
                Sportshall = new Sportshall() { Name = "MladostGym" },
                CreatedOn = DateTime.Parse("2018-03-31"),
                IsDeleted = false
            };

            var data = new List<Visit>
            {
                new Visit()
                {
                    Id = new Guid("ea4e97d7-cc63-4d94-8893-09520cc61ec7"),
                    Client = new Client()
                    {
                        FirstName = "Laura",
                        LastName = "Bailey"
                    },
                    Sport = new Sport() { Name = "Yoga" },
                    Sportshall = new Sportshall() { Name = "MladostGym" },
                    CreatedOn = DateTime.Parse("2018-03-04"),
                    IsDeleted = false,
                },
                new Visit()
                {
                    Id = new Guid("992fc71d-4055-4b57-84bd-4f28057f212d"),
                    Client = new Client()
                    {
                        FirstName = "Liam",
                        LastName = "O'Brian"
                    },
                    Sport = new Sport() { Name = "Pilates" },
                    Sportshall = new Sportshall() { Name = "MladostGym" },
                    CreatedOn = DateTime.Parse("2018-03-21"),
                    IsDeleted = false,
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

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportshallService.GetSportshallVisitsTo(null, "2018-03-27"));
        }
    }
}