using Autofac;
using SportscardSystem.ConsoleClient.Commands.Add;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Commands.Delete;
using SportscardSystem.ConsoleClient.Commands.ExportPdf;
using SportscardSystem.ConsoleClient.Commands.ListAll;
using SportscardSystem.ConsoleClient.Core;
using SportscardSystem.ConsoleClient.Core.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.ConsoleClient.Core.Providers;
using SportscardSystem.ConsoleClient.Core.Providers.Contracts;
using SportscardSystem.ConsoleClient.Validator;

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

            //Registering add commands
            builder.RegisterType<AddCompanyCommand>().Named<ICommand>("addcompany");
            builder.RegisterType<AddClientCommand>().Named<ICommand>("addclient");
            builder.RegisterType<AddSportshallCommand>().Named<ICommand>("addsportshall");
            
            //Registering list commands
            builder.RegisterType<ListAllCompaniesCommand>().Named<ICommand>("listallcompanies");

            //Registering export commands
            builder.RegisterType<ExportSportscardsTableCommand>().Named<ICommand>("exportsportscardstable");
            builder.RegisterType<ExportSportshallsTableCommand>().Named<ICommand>("exportsportshallstable");

            //Registering delete commands
            builder.RegisterType<DeleteClientCommand>().Named<ICommand>("deleteclient");
            builder.RegisterType<DeleteCompanyCommand>().Named<ICommand>("deletecompany");
            builder.RegisterType<DeleteVisitCommand>().Named<ICommand>("deletevisit");




            base.Load(builder);
        }
    }
}
