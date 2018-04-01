using Autofac;
using Autofac.Core;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Commands.ImportJSON;
using SportscardSystem.FileImporters;
using SportscardSystem.FileImporters.Utils;
using SportscardSystem.FileImporters.Utils.Contracts;

namespace SportscardSystem.ConsoleClient.Modules
{
    public class FileImportersConfigModule : Module
    {
        private const string FilePath = "./../../../Sportscards.json";

        protected override void Load(ContainerBuilder builder)
        {

            //Registering FileImporters and Utils
            //builder.RegisterType<StreamReaderWrapper>().As<IStreamReader>().SingleInstance(); // remove single instance?
            //builder.RegisterType<JsonDeserializerWrapper>().As<IJsonDeserializer>().SingleInstance();
            //builder.RegisterType<JsonReader>().As<JsonReader>().SingleInstance();
            /*In LibrarySystem:  this.Bind<JsonReader>().ToSelf().InSingletonScope();
             * Autofac has no direct equivalent, so how should we do it?
               If this fails, try: builder.RegisterType<JsonReader>().AsSelf();
                                   builder.RegisterType<JsonReader>().As<IJsonReader>().SingleInstance();*/

            builder
               .RegisterType<StreamReaderWrapper>()
               .WithParameter("filePath", FilePath)
               .Named<IStreamReader>("jsonreader");

            builder.
                RegisterType<JsonDeserializerWrapper>()
                .As<IJsonDeserializer>();

            builder
                .RegisterType<JsonReader>()
                .WithParameter(ResolvedParameter.ForNamed<IStreamReader>("jsonreader")).As<IJsonReader>();

            
            //Registering file import command
            builder.RegisterType<ImportSportscardsFromFileCommand>().Named<ICommand>("importsportscardsfromfile");
            
            base.Load(builder);
        }
    }
}
