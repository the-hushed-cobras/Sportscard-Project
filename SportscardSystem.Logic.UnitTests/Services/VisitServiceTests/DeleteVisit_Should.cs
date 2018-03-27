using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.Data.Contracts;
using SportscardSystem.Logic.Services;
using SportscardSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace SportscardSystem.Logic.UnitTests.Services.VisitServiceTests
{
    [TestClass]
    public class DeleteVisit_Should
    {
        [TestMethod]
        public void InvokeSaveChangesMethod_WhenSportscardWithVisitIdThatExists()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var expectedVisit = new Visit()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                IsDeleted = true
            };

            var data = new List<Visit>
            {
                new Visit
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                    IsDeleted = false
                }
            };

            var mockSet = new Mock<DbSet<Visit>>();

            mockSet.SetupData(data);

            dbContextMock
                .Setup(x => x.Visits)
                .Returns(mockSet.Object);

            var visitService = new VisitService(dbContextMock.Object, mapperMock.Object);

            //Act
            visitService.DeleteVisit(expectedVisit.Id);

            //Assert
            dbContextMock.Verify(x => x.SaveChanges(), Times.Once);
            Assert.AreEqual(expectedVisit.IsDeleted, true);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullParameter()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var expectedVisit = new Visit()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                IsDeleted = true
            };

            var data = new List<Visit>
            {
                new Visit
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                    IsDeleted = false
                }
            };

            var mockSet = new Mock<DbSet<Visit>>();

            mockSet.SetupData(data);

            dbContextMock
                .Setup(x => x.Visits)
                .Returns(mockSet.Object);

            var visitService = new VisitService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => visitService.DeleteVisit(null));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithVisitIdParameterThatDoesNotExist()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var expectedVisit = new Visit()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                IsDeleted = true
            };

            var data = new List<Visit>
            {
                new Visit
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                    IsDeleted = false
                }
            };

            var mockSet = new Mock<DbSet<Visit>>();

            mockSet.SetupData(data);

            dbContextMock
                .Setup(x => x.Visits)
                .Returns(mockSet.Object);

            var visitService = new VisitService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => visitService.DeleteVisit(new Guid("0097a0eb-9411-4f1d-9ead-3997e6271325")));
        }

        [TestMethod]
        public void ThrowFormatException_WhenInvokedWithInvalidVisitIdFormat()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();

            var expectedVisit = new Visit()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                IsDeleted = true
            };

            var data = new List<Visit>
            {
                new Visit
                {
                    Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                    IsDeleted = false
                }
            };

            var mockSet = new Mock<DbSet<Visit>>();

            mockSet.SetupData(data);

            dbContextMock
                .Setup(x => x.Visits)
                .Returns(mockSet.Object);

            var visitService = new VisitService(dbContextMock.Object, mapperMock.Object);

            //Act && Assert
            Assert.ThrowsException<FormatException>(() => visitService.DeleteVisit(new Guid("TEST")));
        }
    }
}
