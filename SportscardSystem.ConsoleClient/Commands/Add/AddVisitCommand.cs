using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.Commands.Add
{
    public class AddVisitCommand : Command, ICommand
    {
        private readonly IVisitService visitService;
        private readonly IClientService clientService;

        public AddVisitCommand(ISportscardFactory sportscardFactory, IVisitService visitService, IClientService clientService) : base(sportscardFactory)
        {
            Guard.WhenArgument(visitService, "Visit service can not be null").IsNull().Throw();
            this.visitService = visitService;
            this.clientService = clientService;
        }

        public string Execute(IList<string> parameters)
        {
            string clientFirstName;
            string clientLastName;
            Guid clientId;
            string companyName;
            Guid companyId;
            string sportshallName;
            Guid sportshallId;
            string sportName;
            Guid sportId;

            try
            {
                clientFirstName = parameters[0];
                clientLastName = parameters[1];
                companyName = parameters[2];
                sportshallName = parameters[3];
                sportName = parameters[4];
            }
            catch
            {
                throw new ArgumentException("Failed to parse AddVisit command parameters.");
            }

            Guard.WhenArgument(companyName, "Company name").IsNullOrEmpty().Throw();
            companyId = this.clientService.GetCompanyGuidByName(companyName);

            Guard.WhenArgument(clientFirstName, "Client's first name").IsNullOrEmpty().Throw();
            Guard.WhenArgument(clientLastName, "Client's last name").IsNullOrEmpty().Throw();
            clientId = this.visitService.GetClientGuidByNamesAndCompanyId(clientFirstName, clientLastName, companyId);

            Guard.WhenArgument(sportshallName, "Sportshall name").IsNullOrEmpty().Throw();
            sportshallId = this.visitService.GetSportshallGuidByName(sportshallName);

            Guard.WhenArgument(sportName, "Sport name").IsNullOrEmpty().Throw();
            sportId = this.visitService.GetSportGuidByName(sportName);

            IVisitDto visit = this.SportscardFactory.CreateVisitDto(clientId, sportshallId, sportId);
            visitService.AddVisit(visit);

            return $"The visit was added to database.";

        }
    }
}
