using Bytes2you.Validation;
using iTextSharp.text.pdf;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.PdfExporter.Abstracts;
using SportscardSystem.PdfExporter.Contracts;
using SportscardSystem.PdfExporter.Utils.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.PdfExporter
{
    public class PdfSportshallsTableExporter : PdfTableGeneratorBase, IPdfSportshallsTableExporter
    {
        private readonly IPdfSportshallsTableGenerator pdfTableGenerator;

        public PdfSportshallsTableExporter(IPdfStream pdfStream, IPdfSportshallsTableGenerator pdfTableGenerator) 
            : base(pdfStream)
        {
            Guard.WhenArgument(pdfTableGenerator, "Table generator can not be null!").IsNull().Throw();
            this.pdfTableGenerator = pdfTableGenerator;
        }

        public void ExportPdfReport(IEnumerable<ISportshallViewDto> report, string fileName)
        {
            Guard.WhenArgument(report, "Sportshalls report").IsNull().Throw();

            this.PdfStream.Init(fileName);

            this.PdfStream.Document.Open();
            this.PdfStream.Document.Add(this.pdfTableGenerator.CreateSportshallsTable(report));
            this.PdfStream.Document.Close();
        }
    }
}
