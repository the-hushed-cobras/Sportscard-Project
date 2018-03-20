using Bytes2you.Validation;
using SportscardSystem.PdfExporter.Utils.Contracts;

namespace SportscardSystem.PdfExporter.Abstracts
{
    public abstract class PdfExporterBase
    {
        private IPdfStream pdfStream;
        private IPdfSportscardsTableGenerator pdfTableGenerator;

        public PdfExporterBase(IPdfStream pdfStream, IPdfSportscardsTableGenerator pdfTableGenerator)
        {
            Guard.WhenArgument(pdfStream, "Pdf stream can not be null!").IsNull().Throw();
            Guard.WhenArgument(pdfTableGenerator, "Pdf stream can not be null!").IsNull().Throw();

            this.pdfStream = pdfStream;
            this.pdfTableGenerator = pdfTableGenerator;
        }

        protected IPdfStream PdfStream => this.pdfStream;

        protected IPdfSportscardsTableGenerator PdfTableGenerator => this.pdfTableGenerator;
    }
}
