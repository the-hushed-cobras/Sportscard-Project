using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.Data.Contracts;
using SportscardSystem.Logic.Services;
using SportscardSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace SportscardSystem.Logic.UnitTests.Services.SportscardServiceTests
{
    [TestClass]
    public class DeleteSportscard_Should
    {
        [TestMethod]
        public void InvokeSaveChangesMethod_WhenSportscardWithTheSameClientNameAndCompanyExists()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var client = new Client()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                FirstName = "Pesho",
                LastName = "Peshev"
            };

            var company = new Company()
            {
                Id = new Guid("aa992eab-b53c-4f7d-a5f3-a204d560eb93"),
                Name = "Meka M"
            };


            var expectedSportscard = new Sportscard()
            {
                ClientId = client.Id,
                CompanyId = company.Id,
                IsDeleted = true
            };

            var data = new List<Sportscard>
            {
                new Sportscard
                {
                    ClientId = client.Id,
                    Client = client,
                    CompanyId = company.Id,
                    Company = company,
                    IsDeleted = false,
                    DeletedOn = DateTime.Now.Date
                }
            };

            var mockSet = new Mock<DbSet<Sportscard>>();

            mockSet.SetupData(data);

            dbContextMock
                .Setup(x => x.Sportscards)
                .Returns(mockSet.Object);

            var sportscardService = new SportscardService(dbContextMock.Object, mapperMock.Object);

            //Act
            sportscardService.DeleteSportscard(client.FirstName, client.LastName, company.Name);

            //Assert
            dbContextMock.Verify(x => x.SaveChanges(), Times.Once);
            Assert.AreEqual(expectedSportscard.IsDeleted, true);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidFirstNameParameter()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var client = new Client()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                FirstName = "Pesho",
                LastName = "Peshev"
            };

            var company = new Company()
            {
                Id = new Guid("aa992eab-b53c-4f7d-a5f3-a204d560eb93"),
                Name = "Meka M"
            };

            var expectedSportscard = new Sportscard()
            {
                ClientId = client.Id,
                CompanyId = company.Id,
                IsDeleted = true
            };

            var data = new List<Sportscard>
            {
                new Sportscard
                {
                    ClientId = client.Id,
                    Client = client,
                    CompanyId = company.Id,
                    Company = company,
                    IsDeleted = false,
                    DeletedOn = DateTime.Now.Date
                }
            };

            var mockSet = new Mock<DbSet<Sportscard>>();

            mockSet.SetupData(data);

            dbContextMock
                .Setup(x => x.Sportscards)
                .Returns(mockSet.Object);

            var sportscardService = new SportscardService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportscardService.DeleteSportscard(null, client.LastName, company.Name));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidLastNameParameter()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var client = new Client()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                FirstName = "Pesho",
                LastName = "Peshev"
            };

            var company = new Company()
            {
                Id = new Guid("aa992eab-b53c-4f7d-a5f3-a204d560eb93"),
                Name = "Meka M"
            };

            var expectedSportscard = new Sportscard()
            {
                ClientId = client.Id,
                CompanyId = company.Id,
                IsDeleted = true
            };

            var data = new List<Sportscard>
            {
                new Sportscard
                {
                    ClientId = client.Id,
                    Client = client,
                    CompanyId = company.Id,
                    Company = company,
                    IsDeleted = false,
                    DeletedOn = DateTime.Now.Date
                }
            };

            var mockSet = new Mock<DbSet<Sportscard>>();

            mockSet.SetupData(data);

            dbContextMock
                .Setup(x => x.Sportscards)
                .Returns(mockSet.Object);

            var sportscardService = new SportscardService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportscardService.DeleteSportscard(client.FirstName, null, company.Name));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidCompanyNameParameter()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var client = new Client()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                FirstName = "Pesho",
                LastName = "Peshev"
            };

            var company = new Company()
            {
                Id = new Guid("aa992eab-b53c-4f7d-a5f3-a204d560eb93"),
                Name = "Meka M"
            };

            var expectedSportscard = new Sportscard()
            {
                ClientId = client.Id,
                CompanyId = company.Id,
                IsDeleted = true
            };

            var data = new List<Sportscard>
            {
                new Sportscard
                {
                    ClientId = client.Id,
                    Client = client,
                    CompanyId = company.Id,
                    Company = company,
                    IsDeleted = false,
                    DeletedOn = DateTime.Now.Date
                }
            };

            var mockSet = new Mock<DbSet<Sportscard>>();

            mockSet.SetupData(data);

            dbContextMock
                .Setup(x => x.Sportscards)
                .Returns(mockSet.Object);

            var sportscardService = new SportscardService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportscardService.DeleteSportscard(client.FirstName, client.LastName, null));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenSportscardWithTheGivenClientFirstNameDoesNotExist()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var client = new Client()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                FirstName = "Pesho",
                LastName = "Peshev"
            };

            var company = new Company()
            {
                Id = new Guid("aa992eab-b53c-4f7d-a5f3-a204d560eb93"),
                Name = "Meka M"
            };


            var expectedSportscard = new Sportscard()
            {
                ClientId = client.Id,
                CompanyId = company.Id,
                IsDeleted = true
            };

            var data = new List<Sportscard>
            {
                new Sportscard
                {
                    ClientId = client.Id,
                    Client = client,
                    CompanyId = company.Id,
                    Company = company,
                    IsDeleted = false,
                    DeletedOn = DateTime.Now.Date
                }
            };

            var mockSet = new Mock<DbSet<Sportscard>>();

            mockSet.SetupData(data);

            dbContextMock
                .Setup(x => x.Sportscards)
                .Returns(mockSet.Object);

            var sportscardService = new SportscardService(dbContextMock.Object, mapperMock.Object);

            //Act
            Assert.ThrowsException<ArgumentNullException>(() => sportscardService.DeleteSportscard("TEST", client.LastName, company.Name));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenSportscardWithTheGivenClientLastNameDoesNotExist()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var client = new Client()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                FirstName = "Pesho",
                LastName = "Peshev"
            };

            var company = new Company()
            {
                Id = new Guid("aa992eab-b53c-4f7d-a5f3-a204d560eb93"),
                Name = "Meka M"
            };


            var expectedSportscard = new Sportscard()
            {
                ClientId = client.Id,
                CompanyId = company.Id,
                IsDeleted = true
            };

            var data = new List<Sportscard>
            {
                new Sportscard
                {
                    ClientId = client.Id,
                    Client = client,
                    CompanyId = company.Id,
                    Company = company,
                    IsDeleted = false,
                    DeletedOn = DateTime.Now.Date
                }
            };

            var mockSet = new Mock<DbSet<Sportscard>>();

            mockSet.SetupData(data);

            dbContextMock
                .Setup(x => x.Sportscards)
                .Returns(mockSet.Object);

            var sportscardService = new SportscardService(dbContextMock.Object, mapperMock.Object);

            //Act
            Assert.ThrowsException<ArgumentNullException>(() => sportscardService.DeleteSportscard(client.FirstName, "TEST", company.Name));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenSportscardWithTheGivenCompanyNameDoesNotExist()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var client = new Client()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                FirstName = "Pesho",
                LastName = "Peshev"
            };

            var company = new Company()
            {
                Id = new Guid("aa992eab-b53c-4f7d-a5f3-a204d560eb93"),
                Name = "Meka M"
            };


            var expectedSportscard = new Sportscard()
            {
                ClientId = client.Id,
                CompanyId = company.Id,
                IsDeleted = true
            };

            var data = new List<Sportscard>
            {
                new Sportscard
                {
                    ClientId = client.Id,
                    Client = client,
                    CompanyId = company.Id,
                    Company = company,
                    IsDeleted = false,
                    DeletedOn = DateTime.Now.Date
                }
            };

            var mockSet = new Mock<DbSet<Sportscard>>();

            mockSet.SetupData(data);

            dbContextMock
                .Setup(x => x.Sportscards)
                .Returns(mockSet.Object);

            var sportscardService = new SportscardService(dbContextMock.Object, mapperMock.Object);

            //Act
            Assert.ThrowsException<ArgumentNullException>(() => sportscardService.DeleteSportscard(client.FirstName, client.LastName, "TEST"));
        }
    }
}
