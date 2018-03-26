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

namespace SportscardSystem.Logic.UnitTests.Services.ClientServiceTests
{
    [TestClass]
    public class GetAllClients_Should
    {
        [TestMethod]
        public void ReturnIEnumerableOfClientsDto_WhenCollectionIsNotNull()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var data = new List<Client>
            {
                new Client { FirstName = "Stamat", LastName = "Stamateev", Age = 26 },
                new Client { FirstName = "Stamat", LastName = "Stamatev", Age = 27 },
                new Client { FirstName = "Stamat", LastName = "Stamatav", Age = 28 }
            };

            var mockSet = new Mock<DbSet<Client>>();

            mockSet.SetupData(data);
            Mapper.Reset();
            AutomapperConfiguration.Initialize();

            dbContextMock
                .Setup(x => x.Clients)
                .Returns(mockSet.Object);

            var clientService = new ClientService(dbContextMock.Object, mapperMock.Object);

            //Act
            var clients = clientService.GetAllClients();

            //Assert
            Assert.AreEqual(data.Count, clients.Count());
            Assert.IsNotNull(clients);
            Assert.IsInstanceOfType(clients, typeof(IEnumerable<IClientDto>));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenClientsIsNull()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var data = new List<Client>
            {
                new Client { FirstName = "Stamat", LastName = "Stamateev", Age = 26 },
                new Client { FirstName = "Stamat", LastName = "Stamatev", Age = 27 },
                new Client { FirstName = "Stamat", LastName = "Stamatav", Age = 28 }
            };

            var mockSet = new Mock<DbSet<Client>>();

            mockSet.SetupData(data);
            Mapper.Reset();
            AutomapperConfiguration.Initialize();

            dbContextMock
                .Setup(x => x.Clients)
                .Returns((IDbSet<Client>)null);

            var clientService = new ClientService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => clientService.GetAllClients());
        }
    }
}
