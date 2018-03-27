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

namespace SportscardSystem.ConsoleClient.Commands.GetMost
{
    public class GetMostVisitedSportshallCommand : Command, ICommand
    {
        private readonly ISportshallService sportshallService;

        public GetMostVisitedSportshallCommand(ISportscardFactory sportscardFactory, ISportshallService sportshallService) : base(sportscardFactory)
        {
            Guard.WhenArgument(sportshallService, "Sportshall service can not ne null.").IsNull().Throw();
            this.sportshallService = sportshallService;
        }

        public string Execute(IList<string> parameters)
        {
            var mostVisitedSportshall = this.sportshallService.GetMostVisitedSportshall();

            return $"Most visited sportshall: {mostVisitedSportshall.Name}";

        }
    }
}
