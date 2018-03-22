using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using SportscardSystem.PdfExporter.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SportscardSystem.ConsoleClient.Commands.ExportPdf
{
    public class ExportSportscardsTableCommand : ICommand
    {
        private readonly IPdfSportscardsTableExporter pdfWriter;
        private readonly ISportscardService sportscardService;
        private const string ReportName = "Sportscards Report.pdf";

        public ExportSportscardsTableCommand(IPdfSportscardsTableExporter pdfWriter, ISportscardService sportscardService)
        {
            this.pdfWriter = pdfWriter;
            this.sportscardService = sportscardService;
        }

        public string Execute(IList<string> parameters)
        {
            var sportscards = this.sportscardService.GetReport();

            if (sportscards.Count() == 0)
            {
                return $"There are no sportscards in the base.";
            }

            this.pdfWriter.ExportPdfReport(sportscards, ReportName);

            return $"Successfully created pdf report.";
        }
    }
}
