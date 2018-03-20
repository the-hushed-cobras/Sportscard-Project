using Bytes2you.Validation;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SportscardSystem.PdfExporter.Utils.Contracts;
using System.IO;

namespace SportscardSystem.PdfExporter.Utils
{
    public class PdfStreamWrapper : IPdfStream
    {
        private Document document;
        private FileStream fileStream;
        private PdfWriter pdfWriter;
        private string directory;
        private string fileName;

        public PdfStreamWrapper(string directory, string fileName)
        {
            Guard.WhenArgument(directory, "Directory can not be null").IsNullOrEmpty().Throw();
            Guard.WhenArgument(fileName, "File name can not be null").IsNullOrEmpty().Throw();

            this.directory = directory;
            this.fileName = fileName;
            this.document = new Document(PageSize.A4);
            this.fileStream = new FileStream(this.directory + "\\" + this.fileName, FileMode.Create, FileAccess.Write);
            this.pdfWriter = PdfWriter.GetInstance(document, fileStream);
        }

        public Document Document => this.document;
    }
}
