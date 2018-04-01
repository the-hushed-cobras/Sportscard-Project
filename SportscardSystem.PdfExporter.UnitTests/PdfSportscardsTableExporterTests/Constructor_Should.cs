using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.PdfExporter.Contracts;
using SportscardSystem.PdfExporter.Utils.Contracts;
using System;

namespace SportscardSystem.PdfExporter.UnitTests.PdfSportscardsTableExporterTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters()
        {
            //Arrange
            var pdfStreamMock = new Mock<IPdfStream>();
            var tableGeneratorMock = new Mock<IPdfSportscardsTableGenerator>();

            //Act
            var sportscardsTableExporter = new PdfSportscardsTableExporter(pdfStreamMock.Object, tableGeneratorMock.Object);

            //Assert
            Assert.IsNotNull(sportscardsTableExporter);
            Assert.IsInstanceOfType(sportscardsTableExporter, typeof(IPdfSportscardsTableExporter));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullPdfStreamArgument()
        {
            //Arrange
            //var pdfStreamMock = new Mock<IPdfStream>();
            var tableGeneratorMock = new Mock<IPdfSportscardsTableGenerator>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new PdfSportscardsTableExporter(null, tableGeneratorMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullTableGeneratorArgument()
        {
            //Arrange
            var pdfStreamMock = new Mock<IPdfStream>();
            //var tableGeneratorMock = new Mock<IPdfSportscardsTableGenerator>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new PdfSportscardsTableExporter(pdfStreamMock.Object, null));
        }
    }
}
