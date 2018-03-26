using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.Data;
using SportscardSystem.Data.Contracts;
using SportscardSystem.DTO;
using SportscardSystem.Logic.Services;
using SportscardSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SportscardSystem.Logic.UnitTests.Services.CompanyServiceTests
{
    [TestClass]
    public class AddCompany_Should
    {
        [TestMethod]
        public void AddCompanyToDabatase_WhenInvokedWithValidParameterAndCompanyNotAlreadyAddedToDatabase1()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();
            var expectedCompany = new Company() { Name = "Company4" };

            var data = new List<Company>
            {
                new Company { Name = "Company1" },
                new Company { Name = "Company2" },
                new Company { Name = "Company3" },
            };

            var mockSet = new Mock<DbSet<Company>>();

            mockSet.SetupData(data);
            mockSet.Setup(m => m.Add(It.IsAny<Company>()));

            dbContextMock
                .Setup(x => x.Companies)
                .Returns(mockSet.Object);

            var companyDto = new CompanyDto() { Name = "Company4" };

            mapperMock
                .Setup(x => x.Map<Company>(companyDto))
                .Returns(expectedCompany);

            var companyService = new CompanyService(dbContextMock.Object, mapperMock.Object);

            //Act
            companyService.AddCompany(companyDto);

            //Assert
            mockSet.Verify(x => x.Add(expectedCompany), Times.Once);
            //Assert.AreEqual(4, mockSet.Object.Count());
        }

        [TestMethod]
        public void AddCompanyToDabatase_WhenInvokedWithValidParameterAndCompanyNotAlreadyAddedToDatabase()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();
            var expectedCompany = new Company() { Name = "Company4" };

            var data = new List<Company>
            {
                new Company { Name = "Company1" },
                new Company { Name = "Company2" },
                new Company { Name = "Company3" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Company>>();

            mockSet.As<IQueryable<Company>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Company>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Company>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Company>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);
            mockSet.Setup(m => m.Add(It.IsAny<Company>()));

            dbContextMock
                .Setup(x => x.Companies)
                .Returns(mockSet.Object);


            var companyDto = new CompanyDto() { Name = "Company4" };

            mapperMock
                .Setup(x => x.Map<Company>(companyDto))
                .Returns(expectedCompany);

            var companyService = new CompanyService(dbContextMock.Object, mapperMock.Object);
            
            //Act
            companyService.AddCompany(companyDto);

            //Assert
            mockSet.Verify(x => x.Add(expectedCompany), Times.Once);
           //Assert.AreEqual(4, mockSet.Object.Count());
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidParameter()
        {
            //Arrange
            var dbContextMock = new Mock<SportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            CompanyDto companyDto = null;
            var companyService = new CompanyService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => companyService.AddCompany(companyDto));
        }

        [TestMethod]
        public void ThrowsArgumentException_WhenCompanyWithTheSameNameAlreadyExists()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();
            var expectedCompany = new Company() { Name = "Company1" };

            var data = new List<Company>
            {
                new Company { Name = "Company1" },
                new Company { Name = "Company2" },
                new Company { Name = "Company3" },
            };

            var mockSet = new Mock<DbSet<Company>>();

            mockSet.SetupData(data);
            mockSet.Setup(m => m.Add(It.IsAny<Company>()));

            dbContextMock
                .Setup(x => x.Companies)
                .Returns(mockSet.Object);

            var companyDto = new CompanyDto() { Name = "Company1" };

            mapperMock
                .Setup(x => x.Map<Company>(companyDto))
                .Returns(expectedCompany);

            var companyService = new CompanyService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => companyService.AddCompany(companyDto));
        }
    }
}
