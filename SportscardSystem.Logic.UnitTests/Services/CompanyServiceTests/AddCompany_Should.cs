using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.Data.Contracts;
using SportscardSystem.Logic.Services;
using SportscardSystem.Models;
using System.Data.Entity;
using SportscardSystem.DTO;

namespace SportscardSystem.Logic.UnitTests.Services.CompanyServiceTests
{
    [TestClass]
    public class AddCompany_Should
    {
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

            var mockSet = new Mock<IDbSet<Company>>();

            mockSet.As<IQueryable<Company>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Company>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Company>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Company>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);

            dbContextMock
                .Setup(x => x.Companies)
                .Returns(mockSet.Object);

            var companyDto = new CompanyDto() { Name = "Company4" };

            mapperMock
                .Setup(x => x.Map<Company>(companyDto))
                .Returns(expectedCompany);

            //Why?
            dbContextMock
                .Setup(x => x.Companies.Add(expectedCompany))
                .Verifiable();

            var companyService = new CompanyService(dbContextMock.Object, mapperMock.Object);
            
            //Act
            companyService.AddCompany(companyDto);

            //Assert
            dbContextMock.Verify(x => x.Companies.Add(It.IsAny<Company>()), Times.Once);
            //Assert.AreEqual(4, dbContextMock.Object.Companies.Count());
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidParameter()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            CompanyDto companyDto = null;
            var companyService = new CompanyService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => companyService.AddCompany(companyDto));
        }
    }
}
