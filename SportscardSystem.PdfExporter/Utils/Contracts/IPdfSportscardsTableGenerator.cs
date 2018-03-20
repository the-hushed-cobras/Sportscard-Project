using iTextSharp.text.pdf;
using SportscardSystem.DTO.Contracts;
using System.Collections.Generic;

namespace SportscardSystem.PdfExporter.Utils.Contracts
{
    public interface IPdfSportscardsTableGenerator
    {
        PdfPTable CreateSportscardsTable(IEnumerable<ISportscardViewDto> report);
    }
}
