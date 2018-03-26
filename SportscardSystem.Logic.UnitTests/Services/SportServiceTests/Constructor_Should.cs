using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.Data.Contracts;
using SportscardSystem.Logic.Services;
using SportscardSystem.Logic.Services.Contracts;
using System;

namespace SportscardSystem.Logic.UnitTests.Services.SportServiceTests
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
            var clientService = new SportService(dbContextMock.Object, mapperMock.Object);

            //Assert
            Assert.IsNotNull(clientService);
            Assert.IsInstanceOfType(clientService, typeof(ISportService));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullDbContextParameter()
        {
            //Arrange
            //var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new SportService(null, mapperMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullMapperParameter()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            //var mapperMock = new Mock<IMapper>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new SportService(dbContextMock.Object, null));
        }
    }
}
