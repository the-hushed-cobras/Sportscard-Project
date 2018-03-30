using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportscardSystem.ConsoleClient.Commands.ListAll
{
    public class ListAllSportscardsCommand : ICommand
    {
        private readonly ISportscardService sportscardService;

        public ListAllSportscardsCommand(ISportscardService sportscardService)
        {
            Guard.WhenArgument(sportscardService, "Sportcard service can not be null!").IsNull().Throw();
            this.sportscardService = sportscardService;
        }

        public string Execute(IList<string> parameters)
        {
            var sportscards = this.sportscardService.GetAllSportscards();
            Guard.WhenArgument(sportscards, "Sportscards can not be null!").IsNull().Throw();

            if (sportscards.Count() == 0)
            {
                return "There are no registered sportscards.";
            }

            return string.Join(Environment.NewLine, sportscards);
        }
    }
}
