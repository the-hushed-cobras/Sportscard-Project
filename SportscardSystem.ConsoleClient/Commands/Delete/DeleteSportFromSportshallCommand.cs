using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.Commands.Delete
{
    public class DeleteSportFromSportshallCommand : Command, ICommand
    {
        private readonly ISportService sportService;

        public DeleteSportFromSportshallCommand(ISportscardFactory sportscardFactory, ISportService sportService) 
            : base(sportscardFactory)
        {
            Guard.WhenArgument(sportService, "SportService  can not be null.").IsNull().Throw();
            this.sportService = sportService;
        }

        public string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters.Count, "You only need to enter SportName and SportshallName.").IsNotEqual(2).Throw();

            string sport = parameters[0];
            string sportshall = parameters[1];

            Guard.WhenArgument(sport, "Sport can not be null.").IsNullOrEmpty().Throw();
            Guard.WhenArgument(sportshall, "Sportshall can not be null.").IsNullOrEmpty().Throw();

            this.sportService.DeleteSportFromSportshall(sport, sportshall);

            return $"You have successfully removed {sport} from {sportshall}.";
        }
    }
}
