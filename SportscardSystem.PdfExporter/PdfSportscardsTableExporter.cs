using Bytes2you.Validation;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.PdfExporter.Abstracts;
using SportscardSystem.PdfExporter.Contracts;
using SportscardSystem.PdfExporter.Utils.Contracts;
using System.Collections.Generic;

namespace SportscardSystem.PdfExporter
{
    public class PdfSportscardsTableExporter : PdfExporterBase, IPdfExporter
    {
        public PdfSportscardsTableExporter(IPdfStream pdfStream, IPdfSportscardsTableGenerator pdfTableGenerator) 
            : base(pdfStream, pdfTableGenerator)
        {
        }

        public void ExportPdfReport(IEnumerable<ISportscardViewDto> report)
        {
            Guard.WhenArgument(report, "Sportscards report").IsNull().Throw();
            
            this.PdfStream.Document.Open();
            this.PdfStream.Document.Add(this.PdfTableGenerator.CreateSportscardsTable(report));
            this.PdfStream.Document.Close();
        }
    }
}
