using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.Data.Contracts;
using SportscardSystem.Logic.Services;
using SportscardSystem.Logic.Services.Contracts;
using System;

namespace SportscardSystem.Logic.UnitTests.Services.SportshallServiceTests
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
            var clientService = new SportshallService(dbContextMock.Object, mapperMock.Object);

            //Assert
            Assert.IsNotNull(clientService);
            Assert.IsInstanceOfType(clientService, typeof(ISportshallService));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullDbContextParameter()
        {
            //Arrange
            //var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new SportshallService(null, mapperMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullMapperParameter()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            //var mapperMock = new Mock<IMapper>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new SportshallService(dbContextMock.Object, null));
        }
    }
}
