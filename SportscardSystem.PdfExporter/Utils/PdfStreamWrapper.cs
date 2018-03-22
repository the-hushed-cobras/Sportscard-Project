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
        private bool isInitialized;

        public void Init(string fileName)
        {
            this.document = new Document(PageSize.A4);
            this.fileStream = new FileStream(this.directory + "\\" + fileName, FileMode.Create, FileAccess.Write);
            this.pdfWriter = PdfWriter.GetInstance(document, fileStream);

            isInitialized = true;
        }

        public PdfStreamWrapper(string directory)
        {
            Guard.WhenArgument(directory, "Directory can not be null").IsNullOrEmpty().Throw();
            this.directory = directory;
        }

        public Document Document => this.document;

        public bool IsInitialized => this.isInitialized;
    }
}
