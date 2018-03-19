using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.Data;
using SportscardSystem.Data.Contracts;
using SportscardSystem.Logic.Services;
using SportscardSystem.Logic.Services.Contracts;
using System;

namespace SportscardSystem.Logic.UnitTests.Services.CompanyServiceTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            //Act
            var companyService = new CompanyService(dbContextMock.Object, mapperMock.Object);

            //Assert
            Assert.IsNotNull(companyService);
            Assert.IsInstanceOfType(companyService, typeof(ICompanyService));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullDbContextParameter()
        {
            //Arrange
            //var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CompanyService(null, mapperMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullMapperParameter()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            //var mapperMock = new Mock<IMapper>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CompanyService(dbContextMock.Object, null));
        }
    }
}
