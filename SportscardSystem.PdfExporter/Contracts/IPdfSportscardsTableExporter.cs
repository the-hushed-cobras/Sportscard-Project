using SportscardSystem.DTO.Contracts;
using System.Collections.Generic;

namespace SportscardSystem.PdfExporter.Contracts
{
    public interface IPdfSportscardsTableExporter
    {
        void ExportPdfReport(IEnumerable<ISportscardViewDto> report, string fileName);
    }
}
