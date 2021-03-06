﻿using Bytes2you.Validation;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.PdfExporter.Abstracts;
using SportscardSystem.PdfExporter.Contracts;
using SportscardSystem.PdfExporter.Utils.Contracts;
using System.Collections.Generic;

namespace SportscardSystem.PdfExporter
{
    public class PdfSportscardsTableExporter : PdfTableGeneratorBase, IPdfSportscardsTableExporter
    {
        private readonly IPdfSportscardsTableGenerator pdfTableGenerator;

        public PdfSportscardsTableExporter(IPdfStream pdfStream, IPdfSportscardsTableGenerator pdfTableGenerator) 
            : base(pdfStream)
        {
            Guard.WhenArgument(pdfTableGenerator, "Table generator can not be null!").IsNull().Throw();
            this.pdfTableGenerator = pdfTableGenerator;
        }

        public void ExportPdfReport(IEnumerable<ISportscardViewDto> report, string fileName)
        {
            Guard.WhenArgument(report, "Sportscards report can not be null!").IsNull().Throw();
            Guard.WhenArgument(fileName, "File name can not be null!").IsNullOrEmpty().Throw();

            this.PdfStream.Init(fileName);

            this.PdfStream.Document.Open();
            this.PdfStream.Document.Add(this.pdfTableGenerator.CreateSportscardsTable(report));
            this.PdfStream.Document.Close();
        }
    }
}
