using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.Delete;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.Delete.DeleteCompanyCommand_Should
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CallCompanyDeleteMethodOnce_WhenInvokedWithValidParameters()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var companyServiceMock = new Mock<ICompanyService>();

            var companyName = "Progress";

            var deleteCompanyCommand = new DeleteCompanyCommand(sportscardFactoryMock.Object, companyServiceMock.Object);
            var parameters = new List<string>()
            {
                companyName
            };

            //Act
            deleteCompanyCommand.Execute(parameters);

            //Assert
            companyServiceMock.Verify(x => x.DeleteCompany(companyName), Times.Once);
        }

        [TestMethod]
        public void ReturnSuccessMessage_WhenInvokedWithValidParameters()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var companyServiceMock = new Mock<ICompanyService>();

            var companyName = "Progress";
            var expectedMessage = $"Company \"{companyName}\" was deleted from database.";

            var deleteCompanyCommand = new DeleteCompanyCommand(sportscardFactoryMock.Object, companyServiceMock.Object);
            var parameters = new List<string>()
            {
                companyName
            };

            //Act
            var actualMessage = deleteCompanyCommand.Execute(parameters);

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
            var expectedMessage = $"Company \"{companyName}\" was deleted from database.";

            var deleteCompanyCommand = new DeleteCompanyCommand(sportscardFactoryMock.Object, companyServiceMock.Object);

            var parameters = new List<string>()
            {
                null
            };

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => deleteCompanyCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyCompanyNameParameter()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var companyServiceMock = new Mock<ICompanyService>();

            var companyName = "Progress";
            var expectedMessage = $"Company \"{companyName}\" was deleted from database.";

            var deleteCompanyCommand = new DeleteCompanyCommand(sportscardFactoryMock.Object, companyServiceMock.Object);

            var parameters = new List<string>()
            {
                string.Empty
            };

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => deleteCompanyCommand.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithEmptyParametersCollection()
        {
            // Arrange
            var sportscardFactoryMock = new Mock<ISportscardFactory>();
            var companyServiceMock = new Mock<ICompanyService>();

            var companyName = "Progress";
            var expectedMessage = $"Company \"{companyName}\" was deleted from database.";

            var deleteCompanyCommand = new DeleteCompanyCommand(sportscardFactoryMock.Object, companyServiceMock.Object);

            var parameters = new List<string>();

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => deleteCompanyCommand.Execute(parameters));
        }
    }
}
