using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.ConsoleClient.Core.Providers;
using System;

namespace SportscardSystem.ConsoleClient.UnitTests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class ParseCommand_Should
    {
        [TestMethod]
        public void CallsCreateCommandOnce_WhenInvokedWithValidParameter()
        {
            // Arrange
            var fullCommand = "addcompany progress";
            var commandName = "addcompany";

            var commandFactoryMock = new Mock<ICommandFactory>();

            var commandParser = new CommandParser(commandFactoryMock.Object);

            // Act
            commandParser.ParseCommand(fullCommand);

            // Assert
            commandFactoryMock.Verify(m => m.CreateCommand(commandName), Times.Once);
        }

        [TestMethod]
        public void CreateICommand_WhenInvokedWithValidParameter()
        {
            // Arrange
            var fullCommand = "addcompany progress";
            var commandName = "addcompany";

            var commandFactoryMock = new Mock<ICommandFactory>();
            var commandMock = new Mock<ICommand>();

            commandFactoryMock
                .Setup(m => m.CreateCommand(commandName))
                .Returns(commandMock.Object);

            var commandParser = new CommandParser(commandFactoryMock.Object);

            // Act
            var command = commandParser.ParseCommand(fullCommand);

            // Assert
            Assert.IsNotNull(command);
            Assert.IsInstanceOfType(command, typeof(ICommand));
        }

        [TestMethod]
        public void ReturnICommand_WhenInvokedWithValidParameter()
        {
            // Arrange
            var fullCommand = "addcompany progress";
            var commandName = "addcompany";

            var commandFactoryMock = new Mock<ICommandFactory>();
            var commandMock = new Mock<ICommand>();

            commandFactoryMock
                .Setup(m => m.CreateCommand(commandName))
                .Returns(commandMock.Object);

            var commandParser = new CommandParser(commandFactoryMock.Object);

            // Act
            var command = commandParser.ParseCommand(fullCommand);

            // Assert
            Assert.AreSame(commandMock.Object, command);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullFullCommandParameter()
        {
            // Arrange
            //var fullCommand = "AddCompany Progress";
            //var commandName = "AddCompany";

            var commandFactoryMock = new Mock<ICommandFactory>();

            var commandParser = new CommandParser(commandFactoryMock.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => commandParser.ParseCommand(null));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithEmptyFullCommandParameter()
        {
            // Arrange
            //var fullCommand = "AddCompany Progress";
            //var commandName = "AddCOmpany";

            var commandFactoryMock = new Mock<ICommandFactory>();

            var commandParser = new CommandParser(commandFactoryMock.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => commandParser.ParseCommand(string.Empty));
        }
    }
}
