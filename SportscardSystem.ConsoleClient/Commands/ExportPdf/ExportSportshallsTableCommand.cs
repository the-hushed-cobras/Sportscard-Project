using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using SportscardSystem.PdfExporter.Contracts;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SportscardSystem.ConsoleClient.Commands.ExportPdf
{
    public class ExportSportshallsTableCommand : ICommand
    {
        private readonly IPdfSportshallsTableExporter pdfWriter;
        private readonly ISportshallService sportshallService;
        private  string reportName = "Sportshalls Report.pdf";

        public ExportSportshallsTableCommand(IPdfSportshallsTableExporter pdfWriter, ISportshallService sportshallService)
        {
            Guard.WhenArgument(pdfWriter, "Pdf writer can not be null!").IsNull().Throw();
            Guard.WhenArgument(sportshallService, "Sportscard service can not be null!").IsNull().Throw();

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

            var counter = 0;

            while (File.Exists(Directory.GetCurrentDirectory() + "/../../../" + reportName))
            {
                counter++;

                reportName = $"Sportshalls Report({counter}).pdf";
            }

            this.pdfWriter.ExportPdfReport(sportshalls, reportName);

            return $"Successfully created pdf report.";
        }
    }
}
