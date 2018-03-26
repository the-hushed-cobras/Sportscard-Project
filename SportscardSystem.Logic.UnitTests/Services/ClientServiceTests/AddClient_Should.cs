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
using System.Linq;

namespace SportscardSystem.Logic.UnitTests.Services.ClientServiceTests
{
    [TestClass]
    public class AddClient_Should
    {
        [TestMethod]
        public void AddClientToDabatase_WhenInvokedWithValidParameters()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();
            var expectedClient = new Client() { FirstName = "Stamat", LastName = "Stamatov", Age = 25 };

            var data = new List<Client>
            {
                new Client { FirstName = "Stamat", LastName = "Stamateev", Age = 26 },
                new Client { FirstName = "Stamat", LastName = "Stamatev", Age = 27 },
                new Client { FirstName = "Stamat", LastName = "Stamatav", Age = 28 }
            };
        
            var mockSet = new Mock<DbSet<Client>>();

            mockSet.SetupData(data);
            mockSet.Setup(m => m.Add(It.IsAny<Client>()));

            dbContextMock
                .Setup(x => x.Clients)
                .Returns(mockSet.Object);

            var clientDto = new ClientDto() { FirstName = "Stamat", LastName = "Stamatov", Age = 25 };

            mapperMock
                .Setup(x => x.Map<Client>(clientDto))
                .Returns(expectedClient);

            var clientService = new ClientService(dbContextMock.Object, mapperMock.Object);

            //Act
            clientService.AddClient(clientDto);

            //Assert
            mockSet.Verify(x => x.Add(expectedClient), Times.Once);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidParameter()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            ClientDto clientDto = null;
            var clientService = new ClientService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => clientService.AddClient(clientDto));
        }
    }
}
