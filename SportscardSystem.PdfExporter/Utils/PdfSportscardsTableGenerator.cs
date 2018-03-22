using Bytes2you.Validation;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.PdfExporter.Utils.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.PdfExporter.Utils
{
    public class PdfSportscardsTableGenerator : IPdfSportscardsTableGenerator
    {
        private const string ReportTitle = "SPORTSCARDS REPORT - generated on: ";
        private const string SportscardNumber = "#";
        private const string ClientName = "Client Name";
        private const string CompanyName = "Company Name";
        private const int PdfTableSize = 3;

        public PdfPTable CreateSportscardsTable(IEnumerable<ISportscardViewDto> report)
        {
            Guard.WhenArgument(report, "Sportscards report can not be null!").IsNull().Throw();

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

            table.AddCell(SetColorToCell(SportscardNumber));
            table.AddCell(SetColorToCell(ClientName));
            table.AddCell(SetColorToCell(CompanyName));

            var sportscardsCounter = 1;

            foreach (var sportscard in report)
            {
                table.AddCell($"{sportscardsCounter}.");
                table.AddCell(sportscard.ClientName);
                table.AddCell(sportscard.CompanyName);

                sportscardsCounter++;
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
