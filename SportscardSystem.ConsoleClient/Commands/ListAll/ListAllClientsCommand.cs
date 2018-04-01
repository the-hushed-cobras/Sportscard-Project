using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportscardSystem.ConsoleClient.Commands.ListAll
{
    public class ListAllClientsCommand : ICommand
    {
        private readonly IClientService clientsService;

        public ListAllClientsCommand(IClientService clientService)
        {
            Guard.WhenArgument(clientService, "Client service can not be null!").IsNull().Throw();
            this.clientsService = clientService;
        }

        public string Execute(IList<string> parameters)
        {
            var clients = this.clientsService.GetAllClients();
            Guard.WhenArgument(clients, "Clients can not be null!").IsNull().Throw();

            if (clients.Count() == 0)
            {
                return "There are no registered clients.";
            }

            return string.Join(Environment.NewLine, clients);
        }
    }
}
