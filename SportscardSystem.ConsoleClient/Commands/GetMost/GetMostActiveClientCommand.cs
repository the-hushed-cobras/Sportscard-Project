using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.Commands.GetMost
{
    public class GetMostActiveClientCommand : Command, ICommand
    {
        private readonly IClientService clientService;

        public GetMostActiveClientCommand(ISportscardFactory sportscardFactory, IClientService clientService)
            : base(sportscardFactory)
        {
            Guard.WhenArgument(clientService, "Client service can not be null!").IsNull().Throw();
            this.clientService = clientService;
        }

        public string Execute(IList<string> parameters)
        {
            var mostActiveClient = clientService.GetMostActiveClient();
            Guard.WhenArgument(mostActiveClient, "Most active client can not be null!").IsNull().Throw();

            return $"Most active client: {mostActiveClient.FirstName} {mostActiveClient.LastName}";
        }
    }
}
