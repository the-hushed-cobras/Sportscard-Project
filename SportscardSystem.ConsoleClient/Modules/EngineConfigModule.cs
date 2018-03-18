using Autofac;
using SportscardSystem.ConsoleClient.Commands.Add;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core;
using SportscardSystem.ConsoleClient.Core.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.ConsoleClient.Core.Providers;
using SportscardSystem.ConsoleClient.Core.Providers.Contracts;

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

            //Registering factories
            builder.RegisterType<SportscardFactory>().As<ISportscardFactory>().SingleInstance();
            builder.RegisterType<CommandFactory>().As<ICommandFactory>().SingleInstance();


            //Registering add commands
            builder.RegisterType<AddCompanyCommand>().Named<ICommand>("addcompany");

            base.Load(builder);
        }
    }
}
