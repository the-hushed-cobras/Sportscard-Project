using Autofac;
using SportscardSystem.ConsoleClient.Commands.Add;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Commands.Delete;
using SportscardSystem.ConsoleClient.Commands.ExportPdf;
using SportscardSystem.ConsoleClient.Commands.FromAndTo;
using SportscardSystem.ConsoleClient.Commands.GetMost;
using SportscardSystem.ConsoleClient.Commands.ImportJSON;
using SportscardSystem.ConsoleClient.Commands.ListAll;
using SportscardSystem.ConsoleClient.Commands.Visits;
using SportscardSystem.ConsoleClient.Core;
using SportscardSystem.ConsoleClient.Core.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.ConsoleClient.Core.Providers;
using SportscardSystem.ConsoleClient.Core.Providers.Contracts;
using SportscardSystem.ConsoleClient.Validator;
using SportscardSystem.FileImporters.Utils;
using SportscardSystem.FileImporters.Utils.Contracts;

namespace SportscardSystem.ConsoleClient.Modules
{
    public class EngineConfigModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Registering engine components
            builder.RegisterType<ConsoleReader>().As<IReader>().SingleInstance();
            builder.RegisterType<ConsoleWriter>().As<IWriter>().SingleInstance();
            builder.RegisterType<CommandProcessor>().As<ICommandProcessor>().SingleInstance();
            builder.RegisterType<CommandParser>().As<ICommandParser>().SingleInstance();
            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();
            builder.RegisterType<ValidateCore>().As<IValidateCore>().SingleInstance();

            //Registering factories
            builder.RegisterType<SportscardFactory>().As<ISportscardFactory>().SingleInstance();
            builder.RegisterType<CommandFactory>().As<ICommandFactory>().SingleInstance();

            //Registering FileImporters
            builder.RegisterType<StreamReaderWrapper>().As<IStreamReader>().SingleInstance();
            builder.RegisterType<JsonDeserializerWrapper>().As<IJsonDeserializer>().SingleInstance();
            
            //Registering add commands
            builder.RegisterType<AddCompanyCommand>().Named<ICommand>("addcompany");
            builder.RegisterType<AddClientCommand>().Named<ICommand>("addclient");
            builder.RegisterType<AddSportshallCommand>().Named<ICommand>("addsportshall");
            builder.RegisterType<AddSportCommand>().Named<ICommand>("addsport");
            builder.RegisterType<AddSportToSportshallCommand>().Named<ICommand>("addsporttosportshall");
            builder.RegisterType<AddVisitCommand>().Named<ICommand>("addvisit");
            builder.RegisterType<AddSportscardCommand>().Named<ICommand>("addsportscard");

            //Registering file import commands   ---------TRYOUTS
            //builder.RegisterType<AddSportscardCommand>().As<ICommand>();
            //builder.RegisterType<ImportSportscardsFromFileCommand>().Named<ICommand>("importsportscardsfromfile");
            //builder.RegisterType<ImportSportscardsFromFileCommand>().WithParameter(R);    // well fuck, old synthaxs
            builder.RegisterType<ImportSportscardsFromFileCommand>().As<ICommand>().Keyed<ICommand>("importsportscardsfromfile");


            //Registering list commands
            builder.RegisterType<ListAllCompaniesCommand>().Named<ICommand>("listallcompanies");

            //Registering get most commands
            builder.RegisterType<GetMostActiveClientCommand>().Named<ICommand>("getmostactiveclient");
            builder.RegisterType<GetMostActiveCompanyCommand>().Named<ICommand>("getmostactivecompany");
            builder.RegisterType<GetMostPlayedSportCommand>().Named<ICommand>("getmostplayedsport");
            builder.RegisterType<GetMostVisitedSportshallCommand>().Named<ICommand>("getmostvisitedsportshall");

            //Registering export commands
            builder.RegisterType<ExportSportscardsTableCommand>().Named<ICommand>("exportsportscardstable");
            builder.RegisterType<ExportSportshallsTableCommand>().Named<ICommand>("exportsportshallstable");

            //Registering delete commands
            builder.RegisterType<DeleteClientCommand>().Named<ICommand>("deleteclient");
            builder.RegisterType<DeleteCompanyCommand>().Named<ICommand>("deletecompany");
            builder.RegisterType<DeleteVisitCommand>().Named<ICommand>("deletevisit");
            builder.RegisterType<DeleteSportCommand>().Named<ICommand>("deletesport");
            builder.RegisterType<DeleteSportscardCommand>().Named<ICommand>("deletesportscard");
            builder.RegisterType<DeleteSportshallCommand>().Named<ICommand>("deletesportshall");
            builder.RegisterType<DeleteSportFromSportshallCommand>().Named<ICommand>("deletesportfromsportshall");

            //Registering visits commands
            builder.RegisterType<GetVisitsByClientCommand>().Named<ICommand>("getvisitsbyclient");
            builder.RegisterType<GetVisitsByDateCommand>().Named<ICommand>("getvisitsbydate");
            builder.RegisterType<GetVisitsBySportCommand>().Named<ICommand>("getvisitsbysport");

            //Registering from and to commands
            builder.RegisterType<GetSportshallVisitsFromCommand>().Named<ICommand>("getsportshallvisitsfrom");
            builder.RegisterType<GetSportshallVisitsToCommand>().Named<ICommand>("getsportshallvisitsto");
            builder.RegisterType<GetSportVisitsFromCommand>().Named<ICommand>("getsportvisitsfrom");
            builder.RegisterType<GetSportVisitsToCommand>().Named<ICommand>("getsportvisitsto");

            base.Load(builder);
        }
    }
}
