using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.Commands.GetMost
{
    public class GetMostPlayedSportCommand : Command, ICommand
    {
        private readonly ISportService sportService;

        public GetMostPlayedSportCommand(ISportscardFactory sportscardFactory, ISportService sportService)
            : base(sportscardFactory)
        {
            Guard.WhenArgument(sportService, "Sport service can not be null!").IsNull().Throw();
            this.sportService = sportService;
        }

        public string Execute(IList<string> parameters)
        {
            var mostPlayedSport = this.sportService.GetMostPlayedSport();
            Guard.WhenArgument(mostPlayedSport, "Most played sport can not be null!").IsNull().Throw();

            return $"Most played sport: {mostPlayedSport.Name}";
        }
    }
}
