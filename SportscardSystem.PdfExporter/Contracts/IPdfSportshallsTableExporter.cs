using SportscardSystem.DTO.Contracts;
using System.Collections.Generic;

namespace SportscardSystem.PdfExporter.Contracts
{
    public interface IPdfSportshallsTableExporter
    {
        void ExportPdfReport(IEnumerable<ISportshallViewDto> report);
    }
}
