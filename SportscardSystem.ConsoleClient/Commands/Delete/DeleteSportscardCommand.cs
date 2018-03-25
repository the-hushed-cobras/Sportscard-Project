using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.Commands.Delete
{
    public class DeleteSportscardCommand : Command, ICommand
    {
        private readonly ISportscardService sportscardService;

        public DeleteSportscardCommand(ISportscardFactory sportscardFactory, ISportscardService sportscardService) 
            : base(sportscardFactory)
        {
            Guard.WhenArgument(sportscardService, "Sportscard service can not be null!").IsNull().Throw();
            this.sportscardService = sportscardService;
        }

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var companyName = parameters[2];

            Guard.WhenArgument(firstName, "First name can not be null!").IsNullOrEmpty().Throw();
            Guard.WhenArgument(lastName, "Last name can not be null!").IsNullOrEmpty().Throw();
            Guard.WhenArgument(companyName, "Company name can not be null!").IsNullOrEmpty().Throw();

            this.sportscardService.DeleteSportscard(firstName, lastName, companyName);

            return $"The following sportscard was deleted from database.";
        }
    }
}
