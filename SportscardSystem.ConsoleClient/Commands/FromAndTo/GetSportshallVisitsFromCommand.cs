using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportscardSystem.ConsoleClient.Commands.FromAndTo
{
    public class GetSportshallVisitsFromCommand : Command, ICommand
    {
        private readonly ISportshallService sportshallService;

        public GetSportshallVisitsFromCommand(ISportscardFactory sportscardFactory, ISportshallService sportshallService) 
            : base(sportscardFactory)
        {
            Guard.WhenArgument(sportshallService, "Sportshall service can not be null!").IsNull().Throw();
            this.sportshallService = sportshallService;
        }

        public string Execute(IList<string> parameters)
        {
            var sportshallName = parameters[0];
            var fromDate = parameters[1];

            var sportshallVisits = sportshallService.GetSportshallVisitsFrom(sportshallName, fromDate);
            Guard.WhenArgument(sportshallVisits, "Sportshall visits can not be null!").IsNull().Throw();

            if (sportshallVisits.Count() == 0)
            {
                return $"There isn't any visits in {sportshallName} from {fromDate} till today.";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"All visits in {sportshallName} from {fromDate}:");

            var counter = 1;

            foreach (var visit in sportshallVisits)
            {
                sb.Append($"{counter}. Client name: {visit.ClientFirstName} {visit.ClientLastName}; ");
                sb.AppendLine($"Sport name: {visit.SportName}");

                counter++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
