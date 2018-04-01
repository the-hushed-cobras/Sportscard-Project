using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.ConsoleClient.Validator;
using SportscardSystem.Logic.Services.Contracts;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.Commands.Delete
{
    public class DeleteClientCommand : Command, ICommand
    {
        private readonly IClientService clientService;
        private readonly IValidateCore coreValidator;

        public DeleteClientCommand(ISportscardFactory sportscardFactory, IClientService clientService, IValidateCore coreValidator)
            : base(sportscardFactory)
        {
            Guard.WhenArgument(clientService, "Client service can not be null!").IsNull().Throw();
            Guard.WhenArgument(coreValidator, "Validator can not be null!").IsNull().Throw();

            this.clientService = clientService;
            this.coreValidator = coreValidator;
        }

        public string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters.Count, "Count of the parameters.").IsLessThan(2).IsGreaterThan(3).Throw();

            string clientFirstName = parameters[0];
            string clientLastName = parameters[1];
            int? clientAge;

            Guard.WhenArgument(clientFirstName, "Client first name").IsNullOrEmpty().Throw();
            Guard.WhenArgument(clientLastName, "Client last name").IsNullOrEmpty().Throw();

            if (parameters.Count == 3)
            {
                clientAge = this.coreValidator.IntFromString(parameters[2], "Client's Age");
                this.coreValidator.ClientAgeValidation(clientAge, "Client's age");
            }
            else
            {
                clientAge = null;
            }

            this.clientService.DeleteClient(clientFirstName, clientLastName, clientAge);

            return $"{clientFirstName} was deleted from database.";
        }
    }
}
