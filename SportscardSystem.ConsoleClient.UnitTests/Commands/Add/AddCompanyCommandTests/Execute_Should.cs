using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.Add;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.DTO;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.Add.AddCompanyCommand_Should
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CallCompanyAddMethodOnce_WhenInvokedWithValidParameters()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var companyServiceMock = new Mock<ICompanyService>();

            var companyName = "Progress";
            var expectedCompany = new CompanyDto()
            {
                Name = companyName
            };

            sportscardFactoryMock
                .Setup(x => x.CreateCompanyDto(companyName))
                .Returns(expectedCompany);

            var addCompanyCommand = new AddCompanyCommand(sportscardFactoryMock.Object, companyServiceMock.Object);
            var parameters = new List<string>()
            {
                companyName
            };

            //Act
            addCompanyCommand.Execute(parameters);

            //Assert
            companyServiceMock.Verify(x => x.AddCompany(expectedCompany), Times.Once);
        }

        [TestMethod]
        public void ReturnSuccessMessage_WhenInvokedWithValidParameters()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var companyServiceMock = new Mock<ICompanyService>();

            var companyName = "Progress";
            var expectedMessage = $"\"{companyName}\" company was added to database.";
            var expectedCompany = new CompanyDto()
            {
                Name = companyName
            };

            sportscardFactoryMock
                .Setup(x => x.CreateCompanyDto(companyName))
                .Returns(expectedCompany);

            var addCompanyCommand = new AddCompanyCommand(sportscardFactoryMock.Object, companyServiceMock.Object);
            var parameters = new List<string>()
            {
                companyName
            };

            //Act
            var actualMessage = addCompanyCommand.Execute(parameters);

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullCompanyNameParameter()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var companyServiceMock = new Mock<ICompanyService>();

            var companyName = "Progress";
            var expectedMessage = $"\"{companyName}\" company was added to database.";
            var expectedCompany = new CompanyDto()
            {
                Name = companyName
            };

            sportscardFactoryMock
                .Setup(x => x.CreateCompanyDto(companyName))
                .Returns(expectedCompany);

            var addCompanyCommand = new AddCompanyCommand(sportscardFactoryMock.Object, companyServiceMock.Object);
            var parameters = new List<string>()
            {
                null
            };

            //Act && Assert
             Assert.ThrowsException<ArgumentNullException>(() => addCompanyCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyCompanyNameParameter()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var companyServiceMock = new Mock<ICompanyService>();

            var companyName = "Progress";
            var expectedMessage = $"\"{companyName}\" company was added to database.";
            var expectedCompany = new CompanyDto()
            {
                Name = companyName
            };

            sportscardFactoryMock
                .Setup(x => x.CreateCompanyDto(companyName))
                .Returns(expectedCompany);

            var addCompanyCommand = new AddCompanyCommand(sportscardFactoryMock.Object, companyServiceMock.Object);
            var parameters = new List<string>()
            {
                string.Empty
            };

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => addCompanyCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithEmptyParametersCollection()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var companyServiceMock = new Mock<ICompanyService>();

            var companyName = "Progress";
            var expectedMessage = $"\"{companyName}\" company was added to database.";
            var expectedCompany = new CompanyDto()
            {
                Name = companyName
            };

            sportscardFactoryMock
                .Setup(x => x.CreateCompanyDto(companyName))
                .Returns(expectedCompany);

            var addCompanyCommand = new AddCompanyCommand(sportscardFactoryMock.Object, companyServiceMock.Object);
            var parameters = new List<string>();

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => addCompanyCommand.Execute(parameters));
        }
    }
}
