using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.ConsoleClient.Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportscardSystem.ConsoleClient.UnitTests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class ParseParameters_Should
    {
        [TestMethod]
        public void ReturnCollection_WhenInvokedWithValidParameter()
        {
            // Arrange
            var fullCommand = "addcompany progress";
            var expectedResult = new List<string>() { "progress" };

            var commandFactoryMock = new Mock<ICommandFactory>();

            var commandParser = new CommandParser(commandFactoryMock.Object);

            // Act
            var actualResult = commandParser.ParseParameters(fullCommand);

            // Assert
            Assert.IsTrue(expectedResult.SequenceEqual(actualResult));
        }

        [TestMethod]
        public void ReturnEmptyCollection_WhenInvokedWithInvalidParameter()
        {
            // Arrange
            var fullCommand = "addcompany";
            var expectedResult = new List<string>();

            var commandFactoryMock = new Mock<ICommandFactory>();

            var commandParser = new CommandParser(commandFactoryMock.Object);

            // Act
            var actualResult = commandParser.ParseParameters(fullCommand);

            // Assert
            Assert.IsTrue(expectedResult.SequenceEqual(actualResult));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullFullCommandParameter()
        {
            // Arrange
            //var fullCommand = "addcompany";

            var commandFactoryMock = new Mock<ICommandFactory>();

            var commandParser = new CommandParser(commandFactoryMock.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => commandParser.ParseParameters(null));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithEmptyFullCommandParameter()
        {
            // Arrange
            //var fullCommand = "addcompany";

            var commandFactoryMock = new Mock<ICommandFactory>();

            var commandParser = new CommandParser(commandFactoryMock.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => commandParser.ParseParameters(string.Empty));
        }
    }
}
