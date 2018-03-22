using Bytes2you.Validation;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.PdfExporter.Utils.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportscardSystem.PdfExporter.Utils
{
    public class PdfSportshallsTableGenerator : IPdfSportshallsTableGenerator
    {
        private const string ReportTitle = "Sportshalls REPORT - generated on: ";
        private const string SportshallName = "Sportshall Name";
        private const string Sports = "List of Sports";
        private const int PdfTableSize = 2;

        public PdfPTable CreateSportshallsTable(IEnumerable<ISportshallViewDto> report)
        {
            Guard.WhenArgument(report, "Sportshallss report can not be null!").IsNull().Throw();

            PdfPTable table = new PdfPTable(PdfTableSize);
            table.WidthPercentage = 100;
            table.LockedWidth = false;
            table.HorizontalAlignment = Element.ALIGN_CENTER;

            var fullTitle = new Phrase(ReportTitle + DateTime.Now.ToString());
            var titleCell = new PdfPCell(fullTitle);
            titleCell.Colspan = PdfTableSize;
            titleCell.HorizontalAlignment = Element.ALIGN_CENTER;
            titleCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(titleCell);

            table.AddCell(SetColorToCell(SportshallName));
            table.AddCell(SetColorToCell(Sports));

            foreach (var sportshall in report)
            {
                table.AddCell(sportshall.Name);
                table.AddCell("- " + string.Join(Environment.NewLine + "- ", sportshall.Sports));
            }

            return table;
        }

        private PdfPCell SetColorToCell(string cellTitle)
        {
            var phrase = new Phrase(cellTitle);
            var cell = new PdfPCell(phrase);
            cell.BackgroundColor = BaseColor.ORANGE;

            return cell;
        }
    }
}
