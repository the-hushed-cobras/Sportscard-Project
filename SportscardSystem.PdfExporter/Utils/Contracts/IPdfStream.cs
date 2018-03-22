using iTextSharp.text;

namespace SportscardSystem.PdfExporter.Utils.Contracts
{
    public interface IPdfStream
    {
        Document Document { get; }
    }
}
