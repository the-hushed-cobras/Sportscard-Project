using System;
using System.Collections.Generic;
using System.Data.Entity;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.Data.Contracts;
using SportscardSystem.DTO;
using SportscardSystem.Logic.Services;
using SportscardSystem.Models;

namespace SportscardSystem.Logic.UnitTests.Services.CompanyServiceTests
{
    [TestClass]
    public class GetMostActiveCompany_Should
    {
        [TestMethod]
        public void ReturnCompanyDto_WhenThereAreAnyCompanies()
        {
            //Arrange
            var dbContextMock = new Mock<ISportscardSystemDbContext>();
            var mapperMock = new Mock<IMapper>();
            
            var client = new Client
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271323"),
                FirstName = "Gosho",
                LastName = "Goshev",
                Age = 26,
                IsDeleted = false,
                Visits = new List<Visit>()
            };

            var visit = new Visit()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271325"),
                Client = client,
                IsDeleted = false,
                Sport = new Sport() { Name = "Gym" },
                Sportshall = new Sportshall() { Name = "Topfit" },
                CreatedOn = DateTime.Parse("2018-03-31")
            };

            var visits = new List<Visit>();
            visits.Add(visit);
            client.Visits = visits;

            var company = new Company()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                Name = "Geek&Sundry",
                Clients = new List<Client>() { client },
                IsDeleted = false
            };

            var data = new List<Company>
            {
                new Company
                {
                    Id = new Guid("2178140d-5795-4fde-9728-4ef1af43e5ba"),
                    Name = "Naxex",
                    IsDeleted = false
                }
            };
            data.Add(company);

            var mockSet = new Mock<DbSet<Company>>();

            mockSet.SetupData(data);

            dbContextMock
                .Setup(x => x.Companies)
                .Returns(mockSet.Object);

            var expectedCompanyDto = new CompanyDto()
            {
                Id = new Guid("db97a0eb-9411-4f1d-9ead-3997e6271324"),
                Name = "Geek&Sundry"
            };

            mapperMock
                .Setup(x => x.Map<CompanyDto>(company))
                .Returns(expectedCompanyDto);

            var companyService = new CompanyService(dbContextMock.Object, mapperMock.Object);

            //Act
            var mostActiveCompany = companyService.GetMostActiveCompany();

            //Assert
            Assert.AreEqual(expectedCompanyDto.Id, mostActiveCompany.Id);
        }
    }
}
