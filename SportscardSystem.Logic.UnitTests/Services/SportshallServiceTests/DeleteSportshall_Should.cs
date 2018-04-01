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
using SportscardSystem.Logic.Services;
using SportscardSystem.Models;

namespace SportscardSystem.Logic.UnitTests.Services.SportshallServiceTests
{   
    [TestClass]
    public class DeleteSportshall_Should
    {
        [TestMethod]
        public void InvokeSaveChangesMethod_WhenSportshallExistAtDb()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var expectedSportshall = new Sportshall()
            {
                Name = "Pulse",
                IsDeleted = true
            };

            var data = new List<Sportshall>()
            {
                new Sportshall()
                {
                    Name = "Pulse",
                    IsDeleted = false
                }
            };

            var mockSet = new Mock<DbSet<Sportshall>>();
            mockSet.SetupData(data);
            dbContextMock.Setup(x => x.Sportshalls).Returns(mockSet.Object);

            var sportshallService = new SportshallService(dbContextMock.Object, mapperMock.Object);

            //Act
            sportshallService.DeleteSportshall(expectedSportshall.Name);

            //Assert
            dbContextMock.Verify(x => x.SaveChanges(), Times.Once);
            Assert.AreEqual(expectedSportshall.IsDeleted, true);
        }

        [TestMethod]
        public void ThrowArgumentException_WhenSportshallNameIsEmpty()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var expectedSportshall = new Sportshall()
            {
                Name = "",
                IsDeleted = true
            };

            var data = new List<Sportshall>()
            {
                new Sportshall()
                {
                    Name = "Pulse",
                    IsDeleted = false
                }
            };

            var mockSet = new Mock<DbSet<Sportshall>>();
            mockSet.SetupData(data);
            dbContextMock.Setup(x => x.Sportshalls).Returns(mockSet.Object);

            var sportshallService = new SportshallService(dbContextMock.Object, mapperMock.Object);

            //Act&Assert
            Assert.ThrowsException<ArgumentException>(() => sportshallService.DeleteSportshall(expectedSportshall.Name));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenSportshallNameIsNull()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var expectedSportshall = new Sportshall()
            {
                Name = null,
                IsDeleted = true
            };

            var data = new List<Sportshall>()
            {
                new Sportshall()
                {
                    Name = "Pulse",
                    IsDeleted = false
                }
            };

            var mockSet = new Mock<DbSet<Sportshall>>();
            mockSet.SetupData(data);
            dbContextMock.Setup(x => x.Sportshalls).Returns(mockSet.Object);

            var sportshallService = new SportshallService(dbContextMock.Object, mapperMock.Object);

            //Act&Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportshallService.DeleteSportshall(expectedSportshall.Name));
        }

        [TestMethod]
        public void ThrowArgumenNullException_WhenThereIsNoSportshallWithThisNameAtDb()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var expectedSportshall = new Sportshall()
            {
                Name = "AlaBala",
                IsDeleted = true
            };

            var data = new List<Sportshall>()
            {
                new Sportshall()
                {
                    Name = "Pulse",
                    IsDeleted = false
                }
            };

            var mockSet = new Mock<DbSet<Sportshall>>();
            mockSet.SetupData(data);
            dbContextMock.Setup(x => x.Sportshalls).Returns(mockSet.Object);

            var sportshallService = new SportshallService(dbContextMock.Object, mapperMock.Object);

            //Act&Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportshallService.DeleteSportshall(expectedSportshall.Name));
        }
    }
}
