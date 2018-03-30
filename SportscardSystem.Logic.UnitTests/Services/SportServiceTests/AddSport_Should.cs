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

namespace SportscardSystem.Logic.UnitTests.Services.SportServiceTests
{
    [TestClass]
    public class AddSport_Should
    {
        [TestMethod]
        public void AddSportToDabatase_WhenInvokedWithValidParameterAndCompanyNotAlreadyAddedToDatabase1()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();
            var expectedSport = new Sport() { Name = "Boxing" };

            var data = new List<Sport>
            {
                new Sport { Name = "Gym" },
                new Sport { Name = "Yoga" },
                new Sport { Name = "Pilates" },
                new Sport { Name = "Pilates" },
                new Sport { Name = "Pilates" },
                new Sport { Name = "Pilates" },
                new Sport { Name = "Pilates" },
                new Sport { Name = "Pilates" },
                new Sport { Name = "Pilates" },
            };

            var mockSet = new Mock<DbSet<Sport>>();

            mockSet.SetupData(data);
            mockSet.Setup(m => m.Add(It.IsAny<Sport>()));

            dbContextMock
                .Setup((x) => x.Sports)
                .Returns(mockSet.Object);

            var sportDto = new SportDto() { Name = "Boxing" };

            mapperMock
                .Setup(x => x.Map<Sport>(sportDto))
                .Returns(expectedSport);

            var sportService = new SportService(dbContextMock.Object, mapperMock.Object);

            //Act
            sportService.AddSport(sportDto);

            //Assert
            mockSet.Verify(x => x.Add(expectedSport), Times.Once);
        }


        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidParameter()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            SportDto sportDto = null;
            var sportService = new SportService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportService.AddSport(sportDto));
        }

        [TestMethod]
        public void ThrowsArgumentException_WhenSportWithTheSameNameAlreadyExists()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();
            var expectedSport = new Sport() { Name = "Gym" };

            var data = new List<Sport>
            {
                new Sport { Name = "Gym" },
                new Sport { Name = "Yoga" },
                new Sport { Name = "Pilates" }
            };

            var mockSet = new Mock<DbSet<Sport>>();

            mockSet.SetupData(data);
            mockSet.Setup(m => m.Add(It.IsAny<Sport>()));

            dbContextMock
                .Setup(x => x.Sports)
                .Returns(mockSet.Object);

            var sportDto = new SportDto() { Name = "Gym" };

            mapperMock
                .Setup(x => x.Map<Sport>(sportDto))
                .Returns(expectedSport);

            var sportService = new SportService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => sportService.AddSport(sportDto));
        }

        [TestMethod]
        public void InvokeSaveChangesMethod_WhenSportWithTheSameNameDoesNotExistAtDb()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();
            var expectedSport = new Sport() { Name = "Gym" };

            var data = new List<Sport>
            {
                new Sport { Name = "GymGymy" },
                new Sport { Name = "Yoga" },
                new Sport { Name = "Pilates" }
            };

            var mockSet = new Mock<DbSet<Sport>>();

            mockSet.SetupData(data);
            mockSet.Setup(m => m.Add(It.IsAny<Sport>()));

            dbContextMock
                .Setup(x => x.Sports)
                .Returns(mockSet.Object);

            var sportDto = new SportDto() { Name = "Gym" };

            mapperMock
                .Setup(x => x.Map<Sport>(sportDto))
                .Returns(expectedSport);

            var sportService = new SportService(dbContextMock.Object, mapperMock.Object);

            //Act
            sportService.AddSport(sportDto);
            //Assert
            dbContextMock.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
