using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using SportscardSystem.PdfExporter.Contracts;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SportscardSystem.ConsoleClient.Commands.ExportPdf
{
    public class ExportSportscardsTableCommand : ICommand
    {
        private readonly IPdfSportscardsTableExporter pdfWriter;
        private readonly ISportscardService sportscardService;
        private string reportName = "Sportscards Report.pdf";

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

            var counter = 0;

            while (File.Exists(Directory.GetCurrentDirectory() + "/../../../" + reportName))
            {
                counter++;

                reportName = $"Sportscards Report({counter}).pdf";
            }

            this.pdfWriter.ExportPdfReport(sportscards, reportName);

            return $"Successfully created pdf report.";
        }
    }
}
