using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Commands.ListAll;
using SportscardSystem.Logic.Services.Contracts;
using System;

namespace SportscardSystem.ConsoleClient.UnitTests.Commands.ListAll.ListAllSportscardsTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameter()
        {
            //Arrange
            var sportscardServiceMock = new Mock<ISportscardService>();

            //Act
            var listAllSportscardsCommand = new ListAllSportscardsCommand(sportscardServiceMock.Object);

            //Assert
            Assert.IsNotNull(listAllSportscardsCommand);
            Assert.IsInstanceOfType(listAllSportscardsCommand, typeof(ICommand));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullClientSeriveParameter()
        {
            //Arrange
            //var sportscardServiceMock = new Mock<IClientService>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ListAllSportscardsCommand(null));
        }
    }
}
