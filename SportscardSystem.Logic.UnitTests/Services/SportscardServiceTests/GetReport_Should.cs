using AutoMapper;
using AutoMapper.QueryableExtensions;
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

namespace SportscardSystem.Logic.UnitTests.Services.SportscardServiceTests
{
    [TestClass]
    public class GetReport_Should
    {
        [TestMethod]
        public void ReturnCollectionOfISportscardViewDto_WhenAnySportscardsExist()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var firstClient = new Client()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                FirstName = "Georgi",
                LastName = "Georgiev",
                IsDeleted = false,
            };

            var secondClient = new Client()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"),
                FirstName = "Pesho",
                LastName = "Peshev",
                IsDeleted = false
            };

            var firstCompany = new Company()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271320"),
                Name = "Progress",
                IsDeleted = false
            };

            var secondCompany = new Company()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271319"),
                Name = "Telerik",
                IsDeleted = false
            };

            var data = new List<Sportscard>
            {
                new Sportscard
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271322"),
                    Client = firstClient,
                    ClientId = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                    Company = firstCompany,
                    CompanyId = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271320"),
                    IsDeleted = false
                    
                },
                new Sportscard
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271321"),
                    Client = secondClient,
                    ClientId = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"),
                    Company = secondCompany,
                    CompanyId = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271319"),
                    IsDeleted = false
                }
            };

            var dataClients = new List<Client>();
            dataClients.Add(firstClient);
            dataClients.Add(secondClient);

            var dataCompanies = new List<Company>();
            dataCompanies.Add(firstCompany);
            dataCompanies.Add(secondCompany);

            var mockSet = new Mock<DbSet<Sportscard>>();
            var mockSetClients = new Mock<DbSet<Client>>();
            var mockSetCompanies = new Mock<DbSet<Company>>();

            mockSet.SetupData(data);
            mockSetClients.SetupData(dataClients);
            mockSetCompanies.SetupData(dataCompanies);

            Mapper.Reset();
            AutomapperConfiguration.Initialize();

            dbContextMock
                .Setup(x => x.Clients)
                .Returns(mockSetClients.Object);

            dbContextMock
                .Setup(x => x.Sportscards)
                .Returns(mockSet.Object);

            dbContextMock
                .Setup(x => x.Companies)
                .Returns(mockSetCompanies.Object);

            var sportscardService = new SportscardService(dbContextMock.Object, mapperMock.Object);

            //Act
            var sportscardsReport = sportscardService.GetReport();

            //Assert
            Assert.AreEqual(2, sportscardsReport.Count());
        }

        [TestMethod]
        public void ThrowArgumentException_WhenThereIsNoSportscards()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var firstClient = new Client()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                FirstName = "Georgi",
                LastName = "Georgiev",
                IsDeleted = false,
            };

            var secondClient = new Client()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"),
                FirstName = "Pesho",
                LastName = "Peshev",
                IsDeleted = false
            };

            var firstCompany = new Company()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271320"),
                Name = "Progress",
                IsDeleted = false
            };

            var secondCompany = new Company()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271319"),
                Name = "Telerik",
                IsDeleted = false
            };

            var data = new List<Sportscard>();
            //{
            //    new Sportscard
            //    {
            //        Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271322"),
            //        Client = firstClient,
            //        ClientId = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
            //        Company = firstCompany,
            //        CompanyId = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271320"),
            //        IsDeleted = false

            //    },
            //    new Sportscard
            //    {
            //        Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271321"),
            //        Client = secondClient,
            //        ClientId = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"),
            //        Company = secondCompany,
            //        CompanyId = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271319"),
            //        IsDeleted = false
            //    }
            //};

            var mockSet = new Mock<DbSet<Sportscard>>();

            mockSet.SetupData(data);

            Mapper.Reset();
            AutomapperConfiguration.Initialize();

            dbContextMock
                .Setup(x => x.Sportscards)
                .Returns(mockSet.Object);

            var sportscardService = new SportscardService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => sportscardService.GetReport());
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenSportscardsIsNull()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var firstClient = new Client()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                FirstName = "Georgi",
                LastName = "Georgiev",
                IsDeleted = false,
            };

            var secondClient = new Client()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"),
                FirstName = "Pesho",
                LastName = "Peshev",
                IsDeleted = false
            };

            var firstCompany = new Company()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271320"),
                Name = "Progress",
                IsDeleted = false
            };

            var secondCompany = new Company()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271319"),
                Name = "Telerik",
                IsDeleted = false
            };

            var data = new List<Sportscard>();
            //{
            //    new Sportscard
            //    {
            //        Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271322"),
            //        Client = firstClient,
            //        ClientId = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
            //        Company = firstCompany,
            //        CompanyId = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271320"),
            //        IsDeleted = false

            //    },
            //    new Sportscard
            //    {
            //        Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271321"),
            //        Client = secondClient,
            //        ClientId = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"),
            //        Company = secondCompany,
            //        CompanyId = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271319"),
            //        IsDeleted = false
            //    }
            //};

            var mockSet = new Mock<DbSet<Sportscard>>();

            mockSet.SetupData(data);

            Mapper.Reset();
            AutomapperConfiguration.Initialize();

            dbContextMock
                 .Setup(x => x.Sportscards)
                 .Returns((IDbSet<Sportscard>)null);

            var sportscardService = new SportscardService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportscardService.GetReport());
        }
    }
}
