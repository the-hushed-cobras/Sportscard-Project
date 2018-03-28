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

namespace SportscardSystem.Logic.UnitTests.Services.ClientServiceTests
{
    [TestClass]
    public class GetMostActiveClient_Should
    {
        [TestMethod]
        public void ReturnClientDto_WhenThereAreAnyClients()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var client = new Client()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                FirstName = "Stamat",
                LastName = "Stamatov",
                Age = 25,
                IsDeleted = false,
            };

            var visit = new Visit()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                Client = client,
                IsDeleted = false,
                Sport = new Sport() { Name = "Gym" },
                Sportshall = new Sportshall() { Name = "Topfit" },
                CreatedOn = DateTime.Now.Date
            };

            var visits = new List<Visit>();
            visits.Add(visit);
            client.Visits = visits;

            var data = new List<Client>
            {
                new Client
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"),
                    FirstName = "Gosho",
                    LastName = "Goshev",
                    Age = 26,
                    IsDeleted = false,
                    Visits = new List<Visit>()
                }
            };
            data.Add(client);

            var mockSet = new Mock<DbSet<Client>>();

            mockSet.SetupData(data);

            dbContextMock
                .Setup(x => x.Clients)
                .Returns(mockSet.Object);

            var expectedClientDto = new ClientDto()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                FirstName = "Stamat",
                LastName = "Stamatov",
                Age = 25,
            };

            mapperMock
                .Setup(x => x.Map<ClientDto>(client))
                .Returns(expectedClientDto);

            var clientService = new ClientService(dbContextMock.Object, mapperMock.Object);

            //Act
            var mostActiveClient = clientService.GetMostActiveClient();

            //Assert
            Assert.AreEqual(expectedClientDto.Id, mostActiveClient.Id);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenThereIsNoClients()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var client = new Client()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                FirstName = "Stamat",
                LastName = "Stamatov",
                Age = 25,
                IsDeleted = false,
            };

            var visit = new Visit()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                Client = client,
                IsDeleted = false,
                Sport = new Sport() { Name = "Gym" },
                Sportshall = new Sportshall() { Name = "Topfit" },
                CreatedOn = DateTime.Now.Date
            };

            var visits = new List<Visit>();
            visits.Add(visit);
            client.Visits = visits;

            var data = new List<Client>
            {
            };

            var mockSet = new Mock<DbSet<Client>>();

            mockSet.SetupData(data);

            dbContextMock
                .Setup(x => x.Clients)
                .Returns(mockSet.Object);

            var expectedClientDto = new ClientDto()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                FirstName = "Stamat",
                LastName = "Stamatov",
                Age = 25,
            };

            mapperMock
                .Setup(x => x.Map<ClientDto>(client))
                .Returns(expectedClientDto);

            var clientService = new ClientService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => clientService.GetMostActiveClient());
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenMapperIsUnableToMapObject()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var client = new Client()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                FirstName = "Stamat",
                LastName = "Stamatov",
                Age = 25,
                IsDeleted = false,
            };

            var visit = new Visit()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                Client = client,
                IsDeleted = false,
                Sport = new Sport() { Name = "Gym" },
                Sportshall = new Sportshall() { Name = "Topfit" },
                CreatedOn = DateTime.Now.Date
            };

            var visits = new List<Visit>();
            visits.Add(visit);
            client.Visits = visits;

            var data = new List<Client>
            {
                new Client
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"),
                    FirstName = "Gosho",
                    LastName = "Goshev",
                    Age = 26,
                    IsDeleted = false,
                    Visits = new List<Visit>()
                }
            };
            data.Add(client);

            var mockSet = new Mock<DbSet<Client>>();

            mockSet.SetupData(data);

            dbContextMock
                .Setup(x => x.Clients)
                .Returns(mockSet.Object);

            var expectedClientDto = new ClientDto()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                FirstName = "Stamat",
                LastName = "Stamatov",
                Age = 25,
            };

            mapperMock
                .Setup(x => x.Map<ClientDto>(new Client()))
                .Returns(expectedClientDto);

            var clientService = new ClientService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => clientService.GetMostActiveClient());
        }
    }
}
