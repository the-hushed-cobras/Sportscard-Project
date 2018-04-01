using System;
using System.Collections.Generic;
using System.Data.Entity;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.Data.Contracts;
using SportscardSystem.Logic.Services;
using SportscardSystem.Models;

namespace SportscardSystem.Logic.UnitTests.Services.ClientServiceTests
{
    [TestClass]
    public class DeleteClient_Should
    {
        [TestMethod]
        public void InvokeSaveChangesMethod_WhenClientExitAtCompanyWithAgeProperty()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var expectedClient = new Client()
            {
                FirstName = "Pesho",
                LastName = "Gosho",
                Age = 20,
                IsDeleted = true
            };

            var data = new List<Client>()
            {
                new Client()
                {
                    FirstName = "Pesho",
                    LastName = "Gosho",
                    Age = 20,
                    IsDeleted = false
                }
            };

            var mockSet = new Mock<DbSet<Client>>();
            mockSet.SetupData(data);

            dbContextMock.Setup(x => x.Clients).Returns(mockSet.Object);

            var clientService = new ClientService(dbContextMock.Object, mapperMock.Object);

            //Act
            clientService.DeleteClient(expectedClient.FirstName, expectedClient.LastName, expectedClient.Age);

            //Assert
            dbContextMock.Verify(x => x.SaveChanges(), Times.Once);
            Assert.AreEqual(expectedClient.IsDeleted, true);
            
            

        }

        [TestMethod]
        public void InvokeSaveChangesMethod_WhenClientExitAtCompanyWithoutAgeProperty()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var expectedClient = new Client()
            {
                FirstName = "Pesho",
                LastName = "Gosho",
                IsDeleted = true
            };

            var data = new List<Client>()
            {
                new Client()
                {
                    FirstName = "Pesho",
                    LastName = "Gosho",
                    IsDeleted = false
                }
            };

            var mockSet = new Mock<DbSet<Client>>();
            mockSet.SetupData(data);

            dbContextMock.Setup(x => x.Clients).Returns(mockSet.Object);

            var clientService = new ClientService(dbContextMock.Object, mapperMock.Object);

            //Act
            clientService.DeleteClient(expectedClient.FirstName, expectedClient.LastName, null);

            //Assert
            dbContextMock.Verify(x => x.SaveChanges(), Times.Once);
            Assert.AreEqual(expectedClient.IsDeleted, true);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenThereAreNoClientWithThisParamsAtDb()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var expectedClient = new Client()
            {
                FirstName = "Pesho",
                LastName = "Gosho",
                IsDeleted = true
            };

            var data = new List<Client>()
            {
                new Client()
                {
                    FirstName = "Peshoro",
                    LastName = "Goshoro",
                    IsDeleted = false
                }
            };

            var mockSet = new Mock<DbSet<Client>>();
            mockSet.SetupData(data);

            dbContextMock.Setup(x => x.Clients).Returns(mockSet.Object);

            var clientService = new ClientService(dbContextMock.Object, mapperMock.Object);

            //Act&Assert
            Assert.ThrowsException<ArgumentNullException>(() => clientService.DeleteClient(expectedClient.FirstName, expectedClient.LastName, null));
        }

        [TestMethod]
        public void ThowArgumentNullException_WhenClientsFirstNameIsNullOrEmpty()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var expectedClient = new Client()
            {
                FirstName = null,
                LastName = "Gosho",
                IsDeleted = true
            };

            var data = new List<Client>()
            {
                new Client()
                {
                    FirstName = "Peshoro",
                    LastName = "Goshoro",
                    IsDeleted = false
                }
            };

            var mockSet = new Mock<DbSet<Client>>();
            mockSet.SetupData(data);

            dbContextMock.Setup(x => x.Clients).Returns(mockSet.Object);

            var clientService = new ClientService(dbContextMock.Object, mapperMock.Object);

            //Act&Assert
            Assert.ThrowsException<ArgumentNullException>(() => clientService.DeleteClient(expectedClient.FirstName, expectedClient.LastName, null));

        }

        [TestMethod]
        public void ThowArgumentException_WhenClientsLastNameIsEmpty()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var expectedClient = new Client()
            {
                FirstName = "Pesho",
                LastName = "",
                IsDeleted = true
            };

            var data = new List<Client>()
            {
                new Client()
                {
                    FirstName = "Pesho",
                    LastName = "Gosho",
                    IsDeleted = false
                }
            };

            var mockSet = new Mock<DbSet<Client>>();
            mockSet.SetupData(data);

            dbContextMock.Setup(x => x.Clients).Returns(mockSet.Object);

            var clientService = new ClientService(dbContextMock.Object, mapperMock.Object);

            //Act&Assert
            Assert.ThrowsException<ArgumentException>(() => clientService.DeleteClient(expectedClient.FirstName, expectedClient.LastName, null));

        }
    }
}
