using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.PdfExporter.Contracts;
using SportscardSystem.PdfExporter.Utils.Contracts;
using System;

namespace SportscardSystem.PdfExporter.UnitTests.PdfSportshallsTableExporterTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters()
        {
            //Arrange
            var pdfStreamMock = new Mock<IPdfStream>();
            var tableGeneratorMock = new Mock<IPdfSportshallsTableGenerator>();

            //Act
            var sportshallsTableExporter = new PdfSportshallsTableExporter(pdfStreamMock.Object, tableGeneratorMock.Object);

            //Assert
            Assert.IsNotNull(sportshallsTableExporter);
            Assert.IsInstanceOfType(sportshallsTableExporter, typeof(IPdfSportshallsTableExporter));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullPdfStreamArgument()
        {
            //Arrange
            //var pdfStreamMock = new Mock<IPdfStream>();
            var tableGeneratorMock = new Mock<IPdfSportshallsTableGenerator>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new PdfSportshallsTableExporter(null, tableGeneratorMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullTableGeneratorArgument()
        {
            //Arrange
            var pdfStreamMock = new Mock<IPdfStream>();
            //var tableGeneratorMock = new Mock<IPdfSportshallsTableGenerator>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new PdfSportscardsTableExporter(pdfStreamMock.Object, null));
        }
    }
}
