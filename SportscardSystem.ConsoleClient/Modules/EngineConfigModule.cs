using Autofac;
using SportscardSystem.ConsoleClient.Commands.Add;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Commands.Delete;
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
            builder.RegisterType<AddSportCommand>().Named<ICommand>("addsport");
            builder.RegisterType<AddClientCommand>().Named<ICommand>("addclient");
            builder.RegisterType<DeleteClientCommand>().Named<ICommand>("deleteclient");




            base.Load(builder);
        }
    }
}
