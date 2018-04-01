using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.Commands.Add
{
    public class AddSportscardCommand : Command, ICommand
    {
        private readonly ISportscardService sportscardService;
        private readonly IClientService clientService;
        private readonly IVisitService visitService;

        public AddSportscardCommand(ISportscardFactory sportscardFactory, ISportscardService sportscardService, 
                                    IClientService clientService, IVisitService visitService)
            : base(sportscardFactory)
        {
            Guard.WhenArgument(sportscardService, "Company service can not be null!").IsNull().Throw();
            this.sportscardService = sportscardService;
            this.clientService = clientService;
            this.visitService = visitService;
        }

        public string Execute(IList<string> parameters)
        {
            string clientFirstName;
            string clientLastName;
            Guid clientId;
            string companyName;
            Guid companyId;

            try
            {
                clientFirstName = parameters[0];
                clientLastName = parameters[1];
                companyName = parameters[2];
            }
            catch
            {
                throw new ArgumentException("Failed to parse AddSportscard command parameters.");
            }

            Guard.WhenArgument(companyName, "Company name").IsNullOrEmpty().Throw();
            companyId = this.clientService.GetCompanyGuidByName(companyName);

            Guard.WhenArgument(clientFirstName, "Client's first name").IsNullOrEmpty().Throw();
            Guard.WhenArgument(clientLastName, "Client's last name").IsNullOrEmpty().Throw();
            clientId = this.visitService.GetClientGuidByNamesAndCompanyId(clientFirstName, clientLastName, companyId);

            var sportscard = this.SportscardFactory.CreateSportscardDto(clientId, companyId);
            sportscardService.AddSportscard(sportscard);

            return $"The sportscard was added to database.";
        }
    }
}
