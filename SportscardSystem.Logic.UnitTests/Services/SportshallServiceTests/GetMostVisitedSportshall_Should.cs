using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.Data.Contracts;
using SportscardSystem.DTO;
using SportscardSystem.Logic.Services;
using SportscardSystem.Models;

namespace SportscardSystem.Logic.UnitTests.Services.SportshallServiceTests
{
    [TestClass]
    public class GetMostVisitedSportshall_Should
    {
        [TestMethod]
        public void ReturnSporthallDto_WhenThereAreAnyVisits()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var sportsHall = new Sportshall()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                Name = "Gym",
                IsDeleted = false
            };
            var sport = new Sport()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"),
                Name = "Gym",
                IsDeleted = false
            };
            var visit = new Visit()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                IsDeleted = false,
                Sport = sport,
                Sportshall = sportsHall,
                CreatedOn = DateTime.Now.Date
            };

            var sportshallVisits = new List<Visit>();
            sportshallVisits.Add(visit);
            sportsHall.Visits = sportshallVisits;


            var data = new List<Sportshall>()
            {
                    new Sportshall()
                    {
                        Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271321"),
                        IsDeleted = false,
                        Sports = new List<Sport>(),
                        
                        CreatedOn = DateTime.Now.Date
                    }
            };

            data.Add(sportsHall);

            var mockSet = new Mock<DbSet<Sportshall>>();

            mockSet.SetupData(data);

            dbContextMock.Setup(x => x.Sportshalls).Returns(mockSet.Object);

            var expectedSportshallDto = new SportshallDto()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                Name = "Gym",
            };

            mapperMock.Setup(x => x.Map<SportshallDto>(sportsHall)).Returns(expectedSportshallDto);

            var sporthallService = new SportshallService(dbContextMock.Object, mapperMock.Object);

            //Act
            var mostVisitedSportshall = sporthallService.GetMostVisitedSportshall();

            Assert.AreEqual(expectedSportshallDto.Id, mostVisitedSportshall.Id);
        }
    }
}
