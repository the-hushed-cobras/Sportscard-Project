using Bytes2you.Validation;
using SportscardSystem.PdfExporter.Utils.Contracts;

namespace SportscardSystem.PdfExporter.Abstracts
{
    public abstract class PdfTableGeneratorBase
    {
        private IPdfStream pdfStream;

        public PdfTableGeneratorBase(IPdfStream pdfStream)
        {
            Guard.WhenArgument(pdfStream, "Pdf stream can not be null!").IsNull().Throw();
            this.pdfStream = pdfStream;
        }

        protected IPdfStream PdfStream => this.pdfStream;
    }
}
