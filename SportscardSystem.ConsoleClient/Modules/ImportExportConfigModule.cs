using Autofac;
using Autofac.Core;
using SportscardSystem.JsonImporter;
using SportscardSystem.JsonImporter.Utils;
using SportscardSystem.JsonImporter.Utils.Contracts;
using SportscardSystem.PdfExporter;
using SportscardSystem.PdfExporter.Contracts;
using SportscardSystem.PdfExporter.Utils;
using SportscardSystem.PdfExporter.Utils.Contracts;
using System;

namespace SportscardSystem.ConsoleClient.Modules
{
    public class ImportExportConfigModule : Module
    {
        private const string FileDirectory = "./../../../ ";
        private const string FilePath = "./../../../Sportscards.json";

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

            builder
               .RegisterType<StreamReaderWrapper>()
               .WithParameter("filePath", FilePath)
               .Named<IStreamReader>("jsonreader");

            builder
                .RegisterType<JsonDeserializerWrapper>()
                .As<IJsonDeserializer>();


            builder
                .RegisterType<JsonReader>()
                .WithParameter(ResolvedParameter.ForNamed<IStreamReader>("jsonreader")).As<IJsonReader>();

            base.Load(builder);
        }
    }
}
