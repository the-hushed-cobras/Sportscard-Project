//using AutoMapper;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using SportscardSystem.Data;
//using SportscardSystem.Data.Contracts;
//using SportscardSystem.DTO;
//using SportscardSystem.Logic.Services;
//using SportscardSystem.Models;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;

//namespace SportscardSystem.Logic.UnitTests.Services.SportscardServiceTests
//{
//    [TestClass]
//    public class DeleteSportscard_Should
//    {
//        [TestMethod]
//        public void CallSaveChangesMethod_WhenSportscardWithTheSameClientNameAndCompanyExists()
//        {
//            //Arrange
//            var dbContextMock = new Mock<ISportscardSystemDbContext>();
//            var mapperMock = new Mock<IMapper>();
//            var expectedSportscard = new Sportscard()
//            {
//                ClientId = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
//                CompanyId = new Guid("aa992eab-b53c-4f7d-a5f3-a204d560eb93")
//            };

//            var client = new Client()
//            {
//                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
//                FirstName = "Pesho",
//                LastName = "Peshev"
//            };

//            var company = new Company()
//            {
//                Id = new Guid("aa992eab-b53c-4f7d-a5f3-a204d560eb93"),
//                Name = "Meka M"
//            };

//            //var clientMock = new Mock<Client>();
//            //var companyMock = new Mock<Company>();

//            //clientMock.SetupGet(c => c.FirstName)
//            //    .Returns("Pesho");
//            //clientMock.SetupGet(c => c.LastName)
//            //    .Returns("Peshev");
//            //clientMock.SetupGet(c => c.Id)
//            //    .Returns(new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"));

//            //companyMock.SetupGet(c => c.Name)
//            //    .Returns("Meka M");
//            //companyMock.SetupGet(c => c.Id)
//            //    .Returns(new Guid("aa992eab-b53c-4f7d-a5f3-a204d560eb93"));

//            var data = new List<Sportscard>
//            {
//                new Sportscard { ClientId = client.Id, CompanyId = company.Id  }
//            };

//            var mockSet = new Mock<DbSet<Sportscard>>();

//            mockSet.SetupData(data);

//            dbContextMock
//                .Setup(x => x.Sportscards)
//                .Returns(mockSet.Object);

//            var sportscardService = new SportscardService(dbContextMock.Object, mapperMock.Object);

//            //Act
//            sportscardService.DeleteSportscard(client.FirstName, client.LastName, company.Name);

//            //Assert
//            dbContextMock.Verify(x => x.SaveChanges(), Times.Once);
//        }

//        public void ThrowArgumentNullException_WhenInvokedWithInvalidParameter()
//        {
//            //Arrange
//            var dbContextMock = new Mock<ISportscardSystemDbContext>();
//            var mapperMock = new Mock<IMapper>();

//            SportscardDto sportscardDto = null;
//            var sportscardService = new SportscardService(dbContextMock.Object, mapperMock.Object);
//        }

//        [TestMethod]
//        public void TestEffort()
//        {
//            //Arrange
//            var dbContext = new SportscardSystemDbContext(Effort.DbConnectionFactory.CreateTransient());
//            var mapperMock = new Mock<IMapper>();

//            var client = new Client()
//            {
//                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
//                FirstName = "Pesho",
//                LastName = "Peshev"
//            };

//            var company = new Company()
//            {
//                Id = new Guid("aa992eab-b53c-4f7d-a5f3-a204d560eb93"),
//                Name = "Meka M"
//            };

//            var expectedSportscard = new Sportscard()
//            {
//                Client = client,
//                Company = company,
//                IsDeleted = false

//            };

//            dbContext.Sportscards.Add(expectedSportscard);

//            var sportscardService = new SportscardService(dbContext, mapperMock.Object);

//            //Act
//            sportscardService.DeleteSportscard("Pesho", "Peshev", "Meka M");

//            //Assert
//            Assert.AreEqual(expectedSportscard.IsDeleted, true);
//        }
//    }
//}
