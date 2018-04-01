using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.Commands.Add
{
    public class AddSportToSportshallCommand : Command, ICommand
    {
        private readonly ISportService sportService;

        public AddSportToSportshallCommand(ISportscardFactory sportscardFactory, ISportService sportService) 
            : base(sportscardFactory)
        {
            Guard.WhenArgument(sportService, "SportService  can not be null.").IsNull().Throw();

            this.sportService = sportService;
        }

        public string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters.Count, "There are no this count of params for this cmd.").IsNotEqual(2).Throw();

            string sport = parameters[0];
            string sportsHall = parameters[1];

            Guard.WhenArgument(sport, "Sport can not be null.").IsNullOrEmpty().Throw();
            Guard.WhenArgument(sportsHall, "Sportshall can not be null.").IsNullOrEmpty().Throw();

            this.sportService.AddSportToSportshall(sport, sportsHall);

            return $"{sport} were added to {sportsHall} and added to database.";
        }
    }
}
