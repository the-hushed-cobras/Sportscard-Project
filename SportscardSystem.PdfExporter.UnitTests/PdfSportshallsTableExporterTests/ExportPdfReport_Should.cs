using iTextSharp.text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.PdfExporter.Utils.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.PdfExporter.UnitTests.PdfSportshallsTableExporterTests
{
    [TestClass]
    public class ExportPdfReport_Should
    {
        [TestMethod]
        public void CallCreateSportshallsTableOnce_WhenInvokedWithValidParameters()
        {
            //Arrange
            var pdfStreamMock = new Mock<IPdfStream>();
            var tableGeneratorMock = new Mock<IPdfSportshallsTableGenerator>();

            var sportshallsTableExporter = new PdfSportshallsTableExporter(pdfStreamMock.Object, tableGeneratorMock.Object);

            var report = new List<ISportshallViewDto>();
            var fileName = "Test.pdf";

            pdfStreamMock
                .SetupGet(x => x.Document)
                .Returns(new Document());

            //Act
            sportshallsTableExporter.ExportPdfReport(report, fileName);

            //Assert
            tableGeneratorMock.Verify(x => x.CreateSportshallsTable(report), Times.Once);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullReportParameter()
        {
            //Arrange
            var pdfStreamMock = new Mock<IPdfStream>();
            var tableGeneratorMock = new Mock<IPdfSportshallsTableGenerator>();

            var sportshallsTableExporter = new PdfSportshallsTableExporter(pdfStreamMock.Object, tableGeneratorMock.Object);

            //var report = new List<ISportshallViewDto>();
            var fileName = "Test.pdf";

            pdfStreamMock
                .SetupGet(x => x.Document)
                .Returns(new Document());

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportshallsTableExporter.ExportPdfReport(null, fileName));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithInvalidNullFileNameParameter()
        {
            //Arrange
            var pdfStreamMock = new Mock<IPdfStream>();
            var tableGeneratorMock = new Mock<IPdfSportshallsTableGenerator>();

            var sportshallsTableExporter = new PdfSportshallsTableExporter(pdfStreamMock.Object, tableGeneratorMock.Object);

            var report = new List<ISportshallViewDto>();
            //var fileName = "Test.pdf";

            pdfStreamMock
                .SetupGet(x => x.Document)
                .Returns(new Document());

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => sportshallsTableExporter.ExportPdfReport(report, null));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidEmptyFileNameParameter()
        {
            ///Arrange
            var pdfStreamMock = new Mock<IPdfStream>();
            var tableGeneratorMock = new Mock<IPdfSportshallsTableGenerator>();

            var sportshallsTableExporter = new PdfSportshallsTableExporter(pdfStreamMock.Object, tableGeneratorMock.Object);

            var report = new List<ISportshallViewDto>();
            //var fileName = "Test.pdf";

            pdfStreamMock
                .SetupGet(x => x.Document)
                .Returns(new Document());

            //Act && Assert
            Assert.ThrowsException<ArgumentException>(() => sportshallsTableExporter.ExportPdfReport(report, string.Empty));
        }
    }
}
