using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using SportscardSystem.PdfExporter.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SportscardSystem.ConsoleClient.Commands.ExportPdf
{
    public class ExportSportshallsTableCommand : ICommand
    {
        private readonly IPdfSportshallsTableExporter pdfWriter;
        private readonly ISportshallService sportshallService;

        public ExportSportshallsTableCommand(IPdfSportshallsTableExporter pdfWriter, ISportshallService sportshallService)
        {
            this.pdfWriter = pdfWriter;
            this.sportshallService = sportshallService;
        }

        public string Execute(IList<string> parameters)
        {
            var sportshalls = this.sportshallService.GetReport();

            if (sportshalls.Count() == 0)
            {
                return $"There are no sportshalls in the base.";
            }

            this.pdfWriter.ExportPdfReport(sportshalls);

            return $"Successfully created pdf report.";
        }
    }
}
