using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using SportscardSystem.PdfExporter;
using SportscardSystem.PdfExporter.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportscardSystem.ConsoleClient.Commands.ExportPdf
{
    public class ExportSportscardsTableCommand : ICommand
    {
        private readonly IPdfExporter pdfWriter;
        private readonly ISportscardService sportscardService;

        public ExportSportscardsTableCommand(IPdfExporter pdfWriter, ISportscardService sportscardService)
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

            this.pdfWriter.ExportPdfReport(sportscards);

            return $"Successfully created pdf report.";
        }
    }
}
