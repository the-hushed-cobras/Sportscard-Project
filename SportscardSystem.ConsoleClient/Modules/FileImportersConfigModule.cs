using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using SportscardSystem.PdfExporter;
using SportscardSystem.PdfExporter.Contracts;
using SportscardSystem.PdfExporter.Utils;
using SportscardSystem.PdfExporter.Utils.Contracts;
using System;
using SportscardSystem.FileImporters.Utils;
using SportscardSystem.FileImporters.Utils.Contracts;

namespace SportscardSystem.ConsoleClient.Modules
{
    public class FileImportersConfigModule : Module
    {
        private const string FilePath = "./../../../Sportscards.json ";

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<StreamReaderWrapper>()
                .WithParameter("filePath", FilePath)
                .Named<IStreamReader>("jsonreader");
            

            // TO BE FINISHED

            base.Load(builder);
        }
    }
}
