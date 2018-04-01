using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.Commands.Delete
{
    public class DeleteSportshallCommand : Command, ICommand
    {
        private readonly ISportshallService sportshallService;

        public DeleteSportshallCommand(ISportscardFactory sportscardFactory, ISportshallService sportshallService) 
            : base(sportscardFactory)
        {
            Guard.WhenArgument(sportshallService, "SportshallService  can not be null.").IsNull().Throw();
            this.sportshallService = sportshallService;
        }

        public string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters.Count, "parameters").IsNotEqual(1).Throw();

            var sportshallName = parameters[0];
            Guard.WhenArgument(sportshallName, "Name of the current sporthall").IsNullOrEmpty().Throw();

            this.sportshallService.DeleteSportshall(sportshallName);

            return $"Sportshall \"{sportshallName}\" was deleted from database.";
        }
    }
}
