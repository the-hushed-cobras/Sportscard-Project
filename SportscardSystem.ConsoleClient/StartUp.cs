using Autofac;
using SportscardSystem.Architecture.Automapper;
using SportscardSystem.ConsoleClient.Modules;
using SportscardSystem.Data;
using SportscardSystem.Data.Migrations;
using SportscardSystem.Logic.Services.Contracts;
using System.Data.Entity;

namespace SportscardSystem.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            Init();

            var builder = new ContainerBuilder();
            builder.RegisterModule<AutofacConfigModule>();

            var container = builder.Build();
            var clientService = container.Resolve<IClientService>();

            clientService.GetAllClients();

        }

        private static void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SportscardSystemDbContext, Configuration>());

            AutomapperConfiguration.Initialize();
        }

    }
}
