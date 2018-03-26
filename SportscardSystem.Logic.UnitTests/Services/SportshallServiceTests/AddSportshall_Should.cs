using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.Data.Contracts;
using SportscardSystem.DTO;
using SportscardSystem.Logic.Services;
using SportscardSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SportscardSystem.Logic.UnitTests.Services.SportshallServiceTests
{
    [TestClass]
    public class AddSportshall_Should
    {
        [TestMethod]
        public void AddSportshallToDabatase_WhenInvokedWithValidParameterAndCompanyNotAlreadyAddedToDatabase1()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();
            var expectedSportshall = new Sportshall() { Name = "Sportshall4" };

            var data = new List<Sportshall>
            {
                new Sportshall { Name = "Sportshall1" },
                new Sportshall { Name = "Sportshall2" },
                new Sportshall { Name = "Sportshall3" }
            };

            var mockSet = new Mock<DbSet<Sportshall>>();

            mockSet.SetupData(data);
            mockSet.Setup(m => m.Add(It.IsAny<Sportshall>()));

            dbContextMock
                .Setup(x => x.Sportshalls)
                .Returns(mockSet.Object);

            var sportshallDto = new SportshallDto() { Name = "Sportshall4" };

            mapperMock
                .Setup(x => x.Map<Sportshall>(sportshallDto))
                .Returns(expectedSportshall);

            var sportshallService = new SportshallService(dbContextMock.Object, mapperMock.Object);

            //Act
            sportshallService.AddSportshall(sportshallDto);

            //Assert
            mockSet.Verify(x => x.Add(expectedSportshall), Times.Once);
        }

        [TestMethod]
        public void AddSportshallToDabatase_WhenInvokedWithValidParameterAndCompanyNotAlreadyAddedToDatabase()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();
            var expectedSportshall = new Sportshall() { Name = "Sportshall4" };

            var data = new List<Sportshall>
            {
                new Sportshall { Name = "Sportshall1" },
                new Sportshall { Name = "Sportshall2" },
                new Sportshall { Name = "Sportshall3" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Sportshall>>();

            mockSet.As<IQueryable<Sportshall>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Sportshall>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Sportshall>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Sportshall>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);
            mockSet.Setup(m => m.Add(It.IsAny<Sportshall>()));

            dbContextMock
                .Setup(x => x.Sportshalls)
                .Returns(mockSet.Object);


            var sportshallDto = new SportshallDto() { Name = "Sportshall4" };

            mapperMock
                .Setup(x => x.Map<Sportshall>(sportshallDto))
                .Returns(expectedSportshall);

            var sportshallService = new SportshallService(dbContextMock.Object, mapperMock.Object);

            //Act
            sportshallService.AddSportshall(sportshallDto);

            //Assert
            mockSet.Verify(x => x.Add(expectedSportshall), Times.Once);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidParameter()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            SportshallDto sporthallDto = null;
            var sportshallService = new SportshallService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportshallService.AddSportshall(sporthallDto));
        }

        [TestMethod]
        public void ThrowsArgumentException_WhenSportshallWithTheSameNameAlreadyExists()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();
            var expectedSportshall = new Sportshall() { Name = "Sportshall1" };

            var data = new List<Sportshall>
            {
                new Sportshall { Name = "Sportshall1" },
                new Sportshall { Name = "Sportshall2" },
                new Sportshall { Name = "Sportshall3" }
            };

            var mockSet = new Mock<DbSet<Sportshall>>();

            mockSet.SetupData(data);
            mockSet.Setup(m => m.Add(It.IsAny<Sportshall>()));

            dbContextMock
                .Setup(x => x.Sportshalls)
                .Returns(mockSet.Object);

            var sportshallDto = new SportshallDto() { Name = "Sportshall1" };

            mapperMock
                .Setup(x => x.Map<Sportshall>(sportshallDto))
                .Returns(expectedSportshall);

            var sportshallService = new SportshallService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => sportshallService.AddSportshall(sportshallDto));
        }
    }
}
