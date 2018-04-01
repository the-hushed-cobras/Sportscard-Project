using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportscardSystem.JsonImporter.Utils.Contracts;
using Moq;

namespace SportscardSystem.JsonImporter.UnitTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void InstantiateJsonReader_WhenAllArgumentsArePassed()
        {
            // Arrange
            var mockStreamReaderWrapper = new Mock<IStreamReader>();
            var mockJsonDeserializerWrapper = new Mock<IJsonDeserializer>();

            // Act
            var jsonReader = new JsonReader(mockStreamReaderWrapper.Object, mockJsonDeserializerWrapper.Object);

            // Assert
            Assert.IsInstanceOfType(jsonReader, typeof(JsonReader));
        }

        [TestMethod]
        public void ThrowArgumenNullException_WhenStreamReaderArgumentIsNull()
        {
            // Arrange
            var mockJsonDeserializerWrapper = new Mock<IJsonDeserializer>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new JsonReader(null, mockJsonDeserializerWrapper.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenJsonJournalsSerializerArgumentIsNull()
        {
            // Arrange
            var mockStreamReaderWrapper = new Mock<IStreamReader>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new JsonReader(mockStreamReaderWrapper.Object, null));
        }
    }
}
