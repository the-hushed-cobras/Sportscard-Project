using SportscardSystem.DTO.Contracts;
using System.Collections.Generic;

namespace SportscardSystem.PdfExporter.Contracts
{
    public interface IPdfExporter
    {
        void ExportPdfReport(IEnumerable<ISportscardViewDto> report);
    }
}
