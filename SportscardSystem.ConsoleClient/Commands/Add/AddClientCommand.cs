using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Data.Contracts;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using SportscardSystem.Models;

namespace SportscardSystem.ConsoleClient.Commands.Add
{
    public class AddClientCommand : Command, ICommand
    {
        private IClientService clientService;
        private ISportscardSystemDbContext dbContext;

        public AddClientCommand(ISportscardFactory sportscardFactory, IClientService clientService, ISportscardSystemDbContext dbContext) : base(sportscardFactory)
        {
            Guard.WhenArgument(clientService, "Client service can not be null!").IsNull().Throw();
            Guard.WhenArgument(sportscardFactory, "SportCardFactory can not be null!").IsNull().Throw();

            this.clientService = clientService;
            this.dbContext = dbContext;
        }

        public string Execute(IList<string> parameters)
        {
            string clientFirstName = parameters[0];
            string clientLastName = parameters[1];
            int? clientAge;
            string companyName;
            Guid companyId;

            Guard.WhenArgument(parameters.Count, "Parameters count.").IsGreaterThan(4).Throw();
            Guard.WhenArgument(clientFirstName, "Client first name.").IsNullOrEmpty().Throw();
            Guard.WhenArgument(clientLastName, "Client last name.").IsNullOrEmpty().Throw();
            //1 Validation command lenght 
            if (parameters.Count == 3)
            {
                companyName = parameters[2];
                clientAge = null;
            }
            else
            {
                clientAge = IntFromString(parameters[2], "Client's age.");
                Guard.WhenArgument(clientAge, "Clients Age.").IsNull().Throw();
                if (clientAge < 18 || clientAge > 100)
                {
                    throw new ArgumentException("Client age should be from 18 to 100 years old.");
                }
                companyName = parameters[3];
                
            }
            Guard.WhenArgument(companyName, "Company Name").IsNullOrEmpty().Throw();
            try
            {
                companyId = dbContext.Companies.FirstOrDefault(x => x.Name == companyName).Id;
            }
            catch (Exception)
            {
                throw new ArgumentException("No such company exists!");
            }
            

            IClientDto client = this.SportscardFactory.CreateClientDto(clientFirstName, clientLastName, clientAge, companyId);
            Guard.WhenArgument(client, "Client DTO").IsNull().Throw();
            this.clientService.AddClient(client);

            return $"\"{clientFirstName} {clientLastName}\" client was added to database.";


        }
        //TODO: To be extracted into a separate class.
        public int IntFromString(string commandParameter, string parameterName)
        {
            int parsedValue = int.TryParse(commandParameter, out parsedValue)
                ? parsedValue
                : throw new ArgumentException($"Please provide a valid integer value for {parameterName}!");

            return parsedValue;
        }
    }
}
