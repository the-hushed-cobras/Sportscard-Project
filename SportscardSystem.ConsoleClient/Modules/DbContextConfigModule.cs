using Autofac;
using AutoMapper;
using SportscardSystem.Data;
using SportscardSystem.Data.Contracts;
using SportscardSystem.Logic.Services;
using SportscardSystem.Logic.Services.Contracts;

namespace SportscardSystem.ConsoleClient.Modules
{
    public class DbContextConfigModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Registering dbContext
            builder.RegisterType<SportscardSystemDbContext>().As<ISportscardSystemDbContext>().InstancePerDependency();

            //Registering services
            builder.RegisterType<ClientService>().As<IClientService>().InstancePerDependency();
            builder.RegisterType<CompanyService>().As<ICompanyService>().InstancePerDependency();
            builder.RegisterType<SportscardService>().As<ISportscardService>().InstancePerDependency();
            builder.RegisterType<SportService>().As<ISportService>().InstancePerDependency();
            builder.RegisterType<SportshallService>().As<ISportshallService>().InstancePerDependency();
            builder.RegisterType<VisitService>().As<IVisitService>().InstancePerDependency();

            //Registering automapper
            builder.Register(x => Mapper.Instance);
            base.Load(builder);
        }
    }
}
