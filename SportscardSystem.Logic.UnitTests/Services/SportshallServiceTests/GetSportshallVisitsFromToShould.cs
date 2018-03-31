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
    }
}
