using Autofac;
using SportscardSystem.FileImporters;
using SportscardSystem.FileImporters.Utils;
using SportscardSystem.FileImporters.Utils.Contracts;

namespace SportscardSystem.ConsoleClient.Modules
{
    public class FileImportersConfigModule : Module
    {
        private const string FilePath = "./../../../Sportscards.json ";

        protected override void Load(ContainerBuilder builder)
        {

            //Registering FileImporters
            builder.RegisterType<StreamReaderWrapper>().As<IStreamReader>().SingleInstance();
            builder.RegisterType<JsonDeserializerWrapper>().As<IJsonDeserializer>().SingleInstance();
            builder.RegisterType<JsonReader>().As<IJsonReader>().SingleInstance();

            builder
                .RegisterType<JsonReader>()
                .WithParameter("filePath", FilePath)
                .Named<IStreamReader>("jsonreader");
            

            // TO BE FINISHED

            base.Load(builder);
        }
    }
}
