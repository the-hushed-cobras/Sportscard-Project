using Autofac;
using AutoMapper;
using SportscardSystem.Architecture.Automapper;
using SportscardSystem.ConsoleClient.Core.Contracts;
using SportscardSystem.ConsoleClient.Modules;
using SportscardSystem.Data;
using SportscardSystem.Data.Contracts;
using SportscardSystem.Data.Migrations;
using SportscardSystem.Logic.Services;
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
            builder.RegisterModule<ImportExportConfigModule>();

            var container = builder.Build();

            //var clientService = new ClientService(container.Resolve<ISportscardSystemDbContext>(), container.Resolve<IMapper>());
            //var companyService = new CompanyService(container.Resolve<ISportscardSystemDbContext>(), container.Resolve<IMapper>());
            //var sportService = new SportService(container.Resolve<ISportscardSystemDbContext>(), container.Resolve<IMapper>());
            //var visitService = new VisitService(container.Resolve<ISportscardSystemDbContext>(), container.Resolve<IMapper>());
            var sportshallService = new SportshallService(container.Resolve<ISportscardSystemDbContext>(), container.Resolve<IMapper>());

            sportshallService.GetSportshallVisitsFrom("Topfit", "1900-01-01");
            //visitService.GetVisitsByDate("1900-01-01");
            //visitService.GetVisitsByClient("alek", "hristov");
            //sportService.GetMostPlayedSport();

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
