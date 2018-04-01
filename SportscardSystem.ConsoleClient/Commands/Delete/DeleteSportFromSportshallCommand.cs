using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;

namespace SportscardSystem.ConsoleClient.Commands.Delete
{
    public class DeleteSportFromSportshallCommand : Command, ICommand
    {
        private readonly ISportscardFactory sportscardFactory;
        private readonly ISportService sportService;

        public DeleteSportFromSportshallCommand(ISportscardFactory sportscardFactory, ISportService sportService) : base(sportscardFactory)
        {
            Guard.WhenArgument(sportscardFactory, "Sportscard Factory can not be null.").IsNull().Throw();
            Guard.WhenArgument(sportService, "SportService  can not be null.").IsNull().Throw();

            this.sportscardFactory = sportscardFactory;
            this.sportService = sportService;

        }

        public string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters.Count, "You only need to enter SportName and SportshallName.").IsNotEqual(2).Throw();
            string sport = parameters[0];
            string sportsHall = parameters[1];
            Guard.WhenArgument(sport, "Sport can not be null.").IsNullOrEmpty().Throw();
            Guard.WhenArgument(sportsHall, "Sportshall can not be null.").IsNullOrEmpty().Throw();

            this.sportService.DeleteSportFromSportshall(sport, sportsHall);

            return $"You have successfully removed {sport} from {sportsHall}.";
        }
    }
}
