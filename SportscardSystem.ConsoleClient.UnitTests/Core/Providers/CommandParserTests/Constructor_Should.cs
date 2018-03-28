using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.ConsoleClient.Core.Providers;
using SportscardSystem.ConsoleClient.Core.Providers.Contracts;
using System;

namespace SportscardSystem.ConsoleClient.UnitTests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameter()
        {
            // Arrange
            var commandFactoryMock = new Mock<ICommandFactory>();

            // Act
            var commandParser = new CommandParser(commandFactoryMock.Object);

            // Assert
            Assert.IsNotNull(commandParser);
            Assert.IsInstanceOfType(commandParser, typeof(ICommandParser));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullCommandFactoryParameter()
        {
            // Arrange
            //var commandFactoryMock = new Mock<ICommandFactory>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CommandParser(null));
        }
    }
}
