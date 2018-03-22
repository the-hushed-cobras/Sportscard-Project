using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.ConsoleClient.Validator;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.Logic.Services.Contracts;

namespace SportscardSystem.ConsoleClient.Commands.Delete
{
    public class DeleteClientCommand : Command, ICommand
    {
        private readonly IClientService clientService;
        private readonly IValidateCore coreValidator;

        public DeleteClientCommand(ISportscardFactory sportscardFactory, IClientService clientService, IValidateCore coreValidator) : base(sportscardFactory)
        {
            Guard.WhenArgument(clientService, "Client service can not be null").IsNull().Throw();
            this.clientService = clientService;
            this.coreValidator = coreValidator ?? throw new ArgumentNullException("Validator can't be null.");
        }

        public string Execute(IList<string> parameters)
        {
            string clietnFirstName = parameters[0];
            string clietnLastName = parameters[1];
            int? clientAge;
            if (parameters.Count == 3)
            {
                clientAge = this.coreValidator.IntFromString(parameters[2], "Client's Age");
                this.coreValidator.ClientAgeValidation(clientAge, "Client's age");
            }
            else
            {
                clientAge = null;
            }
            
            this.clientService.DeleteClient(clietnFirstName, clietnLastName, clientAge);



            return $"\"{clietnFirstName}\"  was deleted from database.";

        }
    }
}
