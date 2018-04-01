using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportscardSystem.ConsoleClient.Commands.ListAll
{
    public class ListAllSportsCommand : ICommand
    {
        private readonly ISportService sportService;

        public ListAllSportsCommand(ISportService sportService)
        {
            Guard.WhenArgument(sportService, "Sport service can not be null!").IsNull().Throw();
            this.sportService = sportService;
        }

        public string Execute(IList<string> parameters)
        {
            var sports = this.sportService.GetAllSports();
            Guard.WhenArgument(sports, "Sports can not be null!").IsNull().Throw();

            if (sports.Count() == 0)
            {
                return "There are no registered sports.";
            }

            return string.Join(Environment.NewLine, sports);
        }
    }
}
