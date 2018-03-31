using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.Data.Contracts;
using SportscardSystem.Logic.Services;
using SportscardSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace SportscardSystem.Logic.UnitTests.Services.ClientServiceTests
{
    [TestClass]
    public class GetCompanyGuidByName_Should
    {
        [TestMethod]
        public void ReturnCorrectCompanyGuid_WhenCompanyWithSuchANameExistsAtDb()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var expectedCompany = new Company()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                Name = "Geek&Sundry",
                IsDeleted = false
            };

            var data = new List<Company>
            {
                new Company
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                    Name = "Geek&Sundry",
                    IsDeleted = false,
                }
            };

            var mockSet = new Mock<DbSet<Company>>();

            mockSet.SetupData(data);

            dbContextMock
                .Setup(x => x.Companies)
                .Returns(mockSet.Object);

            var clientService = new ClientService(dbContextMock.Object, mapperMock.Object);

            //Act
            var GuidOfCompanyWithEnteredName = clientService.GetCompanyGuidByName(expectedCompany.Name);

            //Assert
            Assert.AreEqual(expectedCompany.Id, GuidOfCompanyWithEnteredName);
        }

        [TestMethod]
        public void ThrowArgumentException_WhenCompanyNameIsEmpty()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();
            
            var data = new List<Company>
            {
                new Company
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                    Name = "Meka M",
                    IsDeleted = false,
                }
            };

            var mockSet = new Mock<DbSet<Company>>();

            mockSet.SetupData(data);

            dbContextMock
                .Setup(x => x.Companies)
                .Returns(mockSet.Object);

            var clientService = new ClientService(dbContextMock.Object, mapperMock.Object);

            //Act
            Assert.ThrowsException<ArgumentException>(() => clientService.GetCompanyGuidByName(string.Empty));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenCompanyNameIsNull()
        {
        }

        [TestMethod]
        public void ThrowArgumenNullException_WhenThereIsNoCompanyWithThisNameAtDb()
        {
        }
    }
}
