using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.Data.Contracts;
using SportscardSystem.DTO;
using SportscardSystem.Logic.Services;
using SportscardSystem.Models;

namespace SportscardSystem.Logic.UnitTests.Services.SportServiceTests
{
    [TestClass]
    public class AddSportToSporthall_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidParameter()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            string sportName = null;
            string sportshall = null;
            var sportService = new SportService(dbContextMock.Object, mapperMock.Object);

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportService.AddSportToSportshall(sportName, sportshall));
        }

        [TestMethod]
        public void ThrowsArgumentNullException_WhenNoSportWithThisNameAtDataBase()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();
            string expectedSport = "alabala";

            var dataSports = new List<Sport>
            {
                new Sport() { Name = "Gym"},
                new Sport() { Name = "Fitness"},
                new Sport() { Name = "Yoga"}
            };

            var dataSportshalls = new List<Sportshall>()
            {
                new Sportshall() { Name = "Pulse"},
                new Sportshall() { Name = "Gold"}
            };

            var mockSetSport = new Mock<DbSet<Sport>>();

            mockSetSport.SetupData(dataSports);
            mockSetSport.Setup(m => m.Add(It.IsAny<Sport>()));

            dbContextMock.Setup(x => x.Sports).Returns(mockSetSport.Object);

            var mockSetSportshall = new Mock<DbSet<Sportshall>>();

            mockSetSportshall.SetupData(dataSportshalls);
            mockSetSportshall.Setup(m => m.Add(It.IsAny<Sportshall>()));

            dbContextMock.Setup(x => x.Sportshalls).Returns(mockSetSportshall.Object);

            var sportService = new SportService(dbContextMock.Object, mapperMock.Object);

            //Act&Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportService.AddSportToSportshall(expectedSport, "Pulse"));
        }

        [TestMethod]
        public void ThrowsArgumentNullException_WhenNoSportshallWithThisNameAtDataBase()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();
            string expectedSport = "Gym";
            string expectedSportshall = "alab";

            var dataSports = new List<Sport>
            {
                new Sport() { Name = "Gym"},
                new Sport() { Name = "Fitness"},
                new Sport() { Name = "Yoga"}
            };

            var dataSportshalls = new List<Sportshall>()
            {
                new Sportshall() { Name = "Pulse"},
                new Sportshall() { Name = "Gold"}
            };

            var mockSetSport = new Mock<DbSet<Sport>>();

            mockSetSport.SetupData(dataSports);
            mockSetSport.Setup(m => m.Add(It.IsAny<Sport>()));

            dbContextMock.Setup(x => x.Sports).Returns(mockSetSport.Object);

            var mockSetSportshall = new Mock<DbSet<Sportshall>>();

            mockSetSportshall.SetupData(dataSportshalls);
            mockSetSportshall.Setup(m => m.Add(It.IsAny<Sportshall>()));

            dbContextMock.Setup(x => x.Sportshalls).Returns(mockSetSportshall.Object);

            var sportService = new SportService(dbContextMock.Object, mapperMock.Object);

            //Act&Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportService.AddSportToSportshall(expectedSport, expectedSportshall));
        }

        [TestMethod]
        public void ThrowsArgumentException_WhenSportshallHasSportWithThisNameAtDataBase()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();
            string expectedSport = "Gym";
            string expectedSportshall = "Pulse";

            var dataSports = new List<Sport>
            {
                new Sport() { Name = "Gym"},
                new Sport() { Name = "Fitness"},
                new Sport() { Name = "Yoga"}
            };

            var dataSportshalls = new List<Sportshall>()
            {
                new Sportshall() { Name = "Pulse"},
                new Sportshall() { Name = "Gold"}
            };

            dataSportshalls[0].Sports.Add(new Sport() { Name = "Gym" });

            var mockSetSport = new Mock<DbSet<Sport>>();

            mockSetSport.SetupData(dataSports);
            mockSetSport.Setup(m => m.Add(It.IsAny<Sport>()));

            dbContextMock.Setup(x => x.Sports).Returns(mockSetSport.Object);

            var mockSetSportshall = new Mock<DbSet<Sportshall>>();

            mockSetSportshall.SetupData(dataSportshalls);
            mockSetSportshall.Setup(m => m.Add(It.IsAny<Sportshall>()));

            dbContextMock.Setup(x => x.Sportshalls).Returns(mockSetSportshall.Object);

            var sportService = new SportService(dbContextMock.Object, mapperMock.Object);

            //Act&Assert
            Assert.ThrowsException<ArgumentException>(() => sportService.AddSportToSportshall(expectedSport, expectedSportshall));
        }

        [TestMethod]
        public void InvokeSaveChangesMethod_WhenSportWithTheSameNameDoesNotExistsAtTheSportshall()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            string expectedSport = "Fitness";
            string expectedSportshall = "Pulse";

            var dataSports = new List<Sport>
            {
                new Sport() { Name = "Gym"},
                new Sport() { Name = "Fitness"},
                new Sport() { Name = "Yoga"}
            };

            var dataSportshalls = new List<Sportshall>()
            {
                new Sportshall() { Name = "Pulse"},
                new Sportshall() { Name = "Gold"}
            };

            dataSportshalls[0].Sports.Add(new Sport() { Name = "Gym" });

            var mockSetSport = new Mock<DbSet<Sport>>();

            mockSetSport.SetupData(dataSports);
            mockSetSport.Setup(m => m.Add(It.IsAny<Sport>()));

            dbContextMock.Setup(x => x.Sports).Returns(mockSetSport.Object);

            var mockSetSportshall = new Mock<DbSet<Sportshall>>();

            mockSetSportshall.SetupData(dataSportshalls);
            mockSetSportshall.Setup(m => m.Add(It.IsAny<Sportshall>()));

            dbContextMock.Setup(x => x.Sportshalls).Returns(mockSetSportshall.Object);

            var sportService = new SportService(dbContextMock.Object, mapperMock.Object);

            //Act

            sportService.AddSportToSportshall(expectedSport, expectedSportshall);

            //Assert
            dbContextMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        
    }
}
