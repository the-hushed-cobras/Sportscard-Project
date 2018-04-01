using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.ConsoleClient.Core;
using SportscardSystem.ConsoleClient.Core.Contracts;
using SportscardSystem.ConsoleClient.Core.Providers.Contracts;
using System;

namespace SportscardSystem.ConsoleClient.UnitTests.Core.EngineTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var processorMock = new Mock<ICommandProcessor>();

            // Act
            var engine = new Engine(readerMock.Object, writerMock.Object, processorMock.Object);

            // Assert
            Assert.IsNotNull(engine);
            Assert.IsInstanceOfType(engine, typeof(IEngine));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullReaderParameter()
        {
            // Arrange
            //var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var processorMock = new Mock<ICommandProcessor>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Engine(null, writerMock.Object, processorMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullWriterParameter()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            //var writerMock = new Mock<IWriter>();
            var processorMock = new Mock<ICommandProcessor>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Engine(readerMock.Object, null, processorMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullProcessorParameter()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            //var processorMock = new Mock<ICommandProcessor>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Engine(readerMock.Object, writerMock.Object, null));
        }
    }
}
