using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.Data.Contracts;
using SportscardSystem.Logic.Services;
using SportscardSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace SportscardSystem.Logic.UnitTests.Services.SportServiceTests
{
    [TestClass]
    public class DeleteSport_Should
    {
        [TestMethod]
        public void InvokeSaveChangesMethod_WhenSportscardWithCompanyNameThatExists()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var expectedCompany = new Sport()
            {
                Name = "Gym",
                IsDeleted = true
            };

            var data = new List<Sport>
            {
                new Sport
                {
                    Name = "Gym",
                    IsDeleted = false,
                }
            };

            var mockSet = new Mock<DbSet<Sport>>();

            mockSet.SetupData(data);

            dbContextMock
                .Setup(x => x.Sports)
                .Returns(mockSet.Object);

            var sportService = new SportService(dbContextMock.Object, mapperMock.Object);

            //Act
            sportService.DeleteSport(expectedCompany.Name);

            //Assert
            dbContextMock.Verify(x => x.SaveChanges(), Times.Once);
            Assert.AreEqual(expectedCompany.IsDeleted, true);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullCompanyNameParameter()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var expectedCompany = new Company()
            {
                Name = "Meka M",
                IsDeleted = true
            };

            var data = new List<Company>
            {
                new Company
                {
                    Name = "Meka M",
                    IsDeleted = false,
                }
            };

            var mockSet = new Mock<DbSet<Company>>();

            mockSet.SetupData(data);

            dbContextMock
                .Setup(x => x.Companies)
                .Returns(mockSet.Object);

            var companyService = new CompanyService(dbContextMock.Object, mapperMock.Object);

            //Act
            Assert.ThrowsException<ArgumentNullException>(() => companyService.DeleteCompany(null));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyCompanyNameParameter()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var expectedCompany = new Company()
            {
                Name = "Meka M",
                IsDeleted = true
            };

            var data = new List<Company>
            {
                new Company
                {
                    Name = "Meka M",
                    IsDeleted = false,
                }
            };

            var mockSet = new Mock<DbSet<Company>>();

            mockSet.SetupData(data);

            dbContextMock
                .Setup(x => x.Companies)
                .Returns(mockSet.Object);

            var companyService = new CompanyService(dbContextMock.Object, mapperMock.Object);

            //Act
            Assert.ThrowsException<ArgumentException>(() => companyService.DeleteCompany(string.Empty));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithCompanyNameThatDoesNotExist()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var expectedCompany = new Company()
            {
                Name = "Meka M",
                IsDeleted = true
            };

            var data = new List<Company>
            {
                new Company
                {
                    Name = "Meka M",
                    IsDeleted = false,
                }
            };

            var mockSet = new Mock<DbSet<Company>>();

            mockSet.SetupData(data);

            dbContextMock
                .Setup(x => x.Companies)
                .Returns(mockSet.Object);

            var companyService = new CompanyService(dbContextMock.Object, mapperMock.Object);

            //Act
            Assert.ThrowsException<ArgumentNullException>(() => companyService.DeleteCompany("TEST"));
        }
    }
}
