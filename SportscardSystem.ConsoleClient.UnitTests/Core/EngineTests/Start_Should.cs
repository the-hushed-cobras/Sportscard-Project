using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Core;
using SportscardSystem.ConsoleClient.Core.Providers.Contracts;

namespace SportscardSystem.ConsoleClient.UnitTests.Core.EngineTests
{
    [TestClass]
    public class Start_Should
    {
        [TestMethod]
        public void InvokeProcessorProcessCommandMethodOnce_WhenValidCommandIsEntered()
        {
            // Arrange
            var commandAsString = "createcompany progress";
            var exitCommandMessage = "Exit";

            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var processorMock = new Mock<ICommandProcessor>();

            readerMock
                .SetupSequence(m => m.ReadLine())
                .Returns(commandAsString)
                .Returns(exitCommandMessage);

            var engine = new Engine(readerMock.Object, writerMock.Object, processorMock.Object);

            // Act
            engine.Start();

            // Assert
            processorMock.Verify(m => m.ProcessCommand(commandAsString), Times.Once);
        }

        [TestMethod]
        public void InvokeWriterWriteLineMethodOnceWithValidResult_WhenValidCommandIsEntered()
        {
            // Arrange
            var commandAsString = "createcompany progress";
            var exitCommandMessage = "Exit";
            var executionResultMessage = "Execution result";

            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var processorMock = new Mock<ICommandProcessor>();

            readerMock
                .SetupSequence(m => m.ReadLine())
                .Returns(commandAsString)
                .Returns(exitCommandMessage);

            processorMock
                .Setup(m => m.ProcessCommand(commandAsString))
                .Returns(executionResultMessage);

            var engine = new Engine(readerMock.Object, writerMock.Object, processorMock.Object);

            // Act
            engine.Start();

            // Assert
            writerMock.Verify(m => m.WriteLine(executionResultMessage), Times.Once);
        }

        [TestMethod]
        public void InvokeWriterWriteLineMethodOnceWithExceptionMessage_WhenInvokedWithInvalidParameters()
        {
            // Arrange
            var commandAsString = "createcompany progress";
            var exitCommandMessage = "Exit";
            var exceptionMessage = "Invalid command!";
            var exception = new Exception(exceptionMessage);

            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var processorMock = new Mock<ICommandProcessor>();

            readerMock
                .SetupSequence(m => m.ReadLine())
                .Returns(commandAsString)
                .Returns(exitCommandMessage);

            processorMock
                .Setup(m => m.ProcessCommand(commandAsString))
                .Throws(exception);

            var engine = new Engine(readerMock.Object, writerMock.Object, processorMock.Object);

            // Act
            engine.Start();

            // Assert
            writerMock.Verify(m => m.WriteLine(exceptionMessage), Times.Once);
        }
    }
}
