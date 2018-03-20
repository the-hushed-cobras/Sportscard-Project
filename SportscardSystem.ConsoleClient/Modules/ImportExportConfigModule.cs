using Autofac;
using Autofac.Core;
using SportscardSystem.PdfExporter;
using SportscardSystem.PdfExporter.Contracts;
using SportscardSystem.PdfExporter.Utils;
using SportscardSystem.PdfExporter.Utils.Contracts;

namespace SportscardSystem.ConsoleClient.Modules
{
    public class ImportExportConfigModule : Module
    {
        private const string FileDirectory = "./../../../ ";
        private const string PdfSportscardsTableName = "SportscardsTable.pdf";

        protected override void Load(ContainerBuilder builder)
        {
            //Registering PdfExporter
            builder.RegisterType<PdfStreamWrapper>().WithParameter("directory", FileDirectory).WithParameter("fileName", PdfSportscardsTableName).Named<IPdfStream>("pdfstream");
            builder.RegisterType<PdfSportscardsTableGenerator>().As<IPdfSportscardsTableGenerator>();
            builder.RegisterType<PdfSportscardsTableExporter>().WithParameter(ResolvedParameter.ForNamed<IPdfStream>("pdfstream")).As<IPdfExporter>();

            base.Load(builder);
        }
    }
}
