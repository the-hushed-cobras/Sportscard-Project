using Autofac;
using SportscardSystem.ConsoleClient.Modules;
using SportscardSystem.Data;
using SportscardSystem.Logic.Services.Contracts;

namespace SportscardSystem.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AutofacConfigModule>();

            var container = builder.Build();
            var clientService = container.Resolve<IClientService>();

            clientService.GetAllClients();
        }
    }
}
