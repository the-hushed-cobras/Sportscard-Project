using Autofac;
using SportscardSystem.Architecture.Automapper;
using SportscardSystem.ConsoleClient.Core.Contracts;
using SportscardSystem.ConsoleClient.Modules;
using SportscardSystem.Data;
using SportscardSystem.Data.Migrations;
using System.Data.Entity;

namespace SportscardSystem.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            Init();

            var builder = new ContainerBuilder();
            builder.RegisterModule<DbContextConfigModule>();
            builder.RegisterModule<EngineConfigModule>();

            var container = builder.Build();

            var engine = container.Resolve<IEngine>();

            engine.Start();
        }

        private static void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SportscardSystemDbContext, Configuration>());

            AutomapperConfiguration.Initialize();
        }

    }
}
