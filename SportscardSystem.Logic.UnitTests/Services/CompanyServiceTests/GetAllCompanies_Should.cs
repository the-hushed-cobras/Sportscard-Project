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

namespace SportscardSystem.Logic.UnitTests.Services.CompanyServiceTests
{
    [TestClass]
    public class GetAllCompanies_Should
    {
        [TestMethod]
        public void ReturnIQueryableOfCompaniesDto_WhenCollectionIsNotNull()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var data = new List<Company>
            {
                new Company { Name = "Company1" },
                new Company { Name = "Company2" },
                new Company { Name = "Company3" },
            };

            var mockSet = new Mock<DbSet<Company>>();

            mockSet.SetupData(data);
            Mapper.Reset();
            AutomapperConfiguration.Initialize();

            dbContextMock
                .Setup(x => x.Companies)
                .Returns(mockSet.Object);

            var companyService = new CompanyService(dbContextMock.Object, mapperMock.Object);

            //Act
            var companies = companyService.GetAllCompanies();

            //Assert
            Assert.AreEqual(data.Count, companies.Count());
            Assert.IsNotNull(companies);
            Assert.IsInstanceOfType(companies, typeof(IQueryable<ICompanyDto>));
        }

        [TestMethod]
        public void ThrowNullArgumentException_WhenCompaniesIsNull()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var data = new List<Company>
            {
                new Company { Name = "Company1" },
                new Company { Name = "Company2" },
                new Company { Name = "Company3" },
            };

            var mockSet = new Mock<DbSet<Company>>();
            mockSet.SetupData(data);

            Mapper.Reset();
            AutomapperConfiguration.Initialize();

            dbContextMock
                .Setup(x => x.Companies)
                .Returns((IDbSet<Company>)null);

            var companyService = new CompanyService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<NullReferenceException>(() => companyService.GetAllCompanies());
        }
    }
}
