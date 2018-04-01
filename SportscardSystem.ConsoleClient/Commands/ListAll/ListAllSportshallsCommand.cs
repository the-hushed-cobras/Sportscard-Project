using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportscardSystem.ConsoleClient.Commands.ListAll
{
    public class ListAllSportshallsCommand : ICommand
    {
        private readonly ISportshallService sportshallService;

        public ListAllSportshallsCommand(ISportshallService sportshallService)
        {
            Guard.WhenArgument(sportshallService, "Sportshall service can not be null!").IsNull().Throw();
            this.sportshallService = sportshallService;
        }

        public string Execute(IList<string> parameters)
        {
            var sportshalls = this.sportshallService.GetAllSportshalls();
            Guard.WhenArgument(sportshalls, "Sportshalls can not be null!").IsNull().Throw();

            if (sportshalls.Count() == 0)
            {
                return "There are no registered sportshalls.";
            }

            return string.Join(Environment.NewLine, sportshalls);
        }
    }
}
