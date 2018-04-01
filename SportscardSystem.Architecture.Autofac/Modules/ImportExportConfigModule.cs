using Autofac;
using Autofac.Core;
using SportscardSystem.PdfExporter;
using SportscardSystem.PdfExporter.Contracts;
using SportscardSystem.PdfExporter.Utils;
using SportscardSystem.PdfExporter.Utils.Contracts;

namespace SportscardSystem.Architecture.Autofac.Modules
{
    public class ImportExportConfigModule : Module
    {
        private const string FileDirectory = "./../../../ ";

        protected override void Load(ContainerBuilder builder)
        {
            //Registering PdfExporter
            builder
                .RegisterType<PdfStreamWrapper>()
                .WithParameter("directory", FileDirectory)
                .Named<IPdfStream>("pdfstream");

            builder.RegisterType<PdfSportscardsTableGenerator>().As<IPdfSportscardsTableGenerator>();

            builder
                .RegisterType<PdfSportscardsTableExporter>()
                .WithParameter(ResolvedParameter.ForNamed<IPdfStream>("pdfstream"))
                .As<IPdfSportscardsTableExporter>();

            builder.RegisterType<PdfSportshallsTableGenerator>().As<IPdfSportshallsTableGenerator>();

            builder
                .RegisterType<PdfSportshallsTableExporter>()
                .WithParameter(ResolvedParameter.ForNamed<IPdfStream>("pdfstream"))
                .As<IPdfSportshallsTableExporter>();

            base.Load(builder);
        }
    }
}
