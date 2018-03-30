using iTextSharp.text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.PdfExporter.Utils.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.PdfExporter.UnitTests.PdfSportscardsTableExporterTests
{
    [TestClass]
    public class ExportPdfReport_Should
    {
        [TestMethod]
        public void CallCreateSportscardsTableOnce_WhenInvokedWithValidParameters()
        {
            //Arrange
            var pdfStreamMock = new Mock<IPdfStream>();
            var tableGeneratorMock = new Mock<IPdfSportscardsTableGenerator>();

            var sportscardsTableExporter = new PdfSportscardsTableExporter(pdfStreamMock.Object, tableGeneratorMock.Object);

            var report = new List<ISportscardViewDto>();
            var fileName = "Test.pdf";

            pdfStreamMock
                .SetupGet(x => x.Document)
                .Returns(new Document());

            //Act
            sportscardsTableExporter.ExportPdfReport(report, fileName);

            //Assert
            tableGeneratorMock.Verify(x => x.CreateSportscardsTable(report), Times.Once);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullReportParameter()
        {
            //Arrange
            var pdfStreamMock = new Mock<IPdfStream>();
            var tableGeneratorMock = new Mock<IPdfSportscardsTableGenerator>();

            var sportscardsTableExporter = new PdfSportscardsTableExporter(pdfStreamMock.Object, tableGeneratorMock.Object);

            //var report = new List<ISportscardViewDto>();
            var fileName = "Test.pdf";

            pdfStreamMock
                .SetupGet(x => x.Document)
                .Returns(new Document());

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportscardsTableExporter.ExportPdfReport(null, fileName));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullFileNameParameter()
        {
            //Arrange
            var pdfStreamMock = new Mock<IPdfStream>();
            var tableGeneratorMock = new Mock<IPdfSportscardsTableGenerator>();

            var sportscardsTableExporter = new PdfSportscardsTableExporter(pdfStreamMock.Object, tableGeneratorMock.Object);

            var report = new List<ISportscardViewDto>();
            //var fileName = "Test.pdf";

            pdfStreamMock
                .SetupGet(x => x.Document)
                .Returns(new Document());

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportscardsTableExporter.ExportPdfReport(report, null));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyFileNameParameter()
        {
            //Arrange
            var pdfStreamMock = new Mock<IPdfStream>();
            var tableGeneratorMock = new Mock<IPdfSportscardsTableGenerator>();

            var sportscardsTableExporter = new PdfSportscardsTableExporter(pdfStreamMock.Object, tableGeneratorMock.Object);

            var report = new List<ISportscardViewDto>();
            //var fileName = "Test.pdf";

            pdfStreamMock
                .SetupGet(x => x.Document)
                .Returns(new Document());

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => sportscardsTableExporter.ExportPdfReport(report, string.Empty));
        }
    }
}
