using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportscardSystem.ConsoleClient.Commands.FromAndTo
{
    public class GetSportVisitsFromCommand : Command, ICommand
    {
        private readonly ISportService sportService;

        public GetSportVisitsFromCommand(ISportscardFactory sportscardFactory, ISportService sportService)
            : base(sportscardFactory)
        {
            Guard.WhenArgument(sportService, "Sport service can not be null!").IsNull().Throw();
            this.sportService = sportService;
        }

        public string Execute(IList<string> parameters)
        {
            var sportName = parameters[0];
            var fromDate = parameters[1];

            Guard.WhenArgument(sportName, "Sport name can not be null!").IsNullOrEmpty().Throw();
            Guard.WhenArgument(fromDate, "From date can not be null!").IsNullOrEmpty().Throw();

            var sportVisits = sportService.GetSportVisitsFrom(sportName.ToLower(), fromDate);
            Guard.WhenArgument(sportVisits, "Sport visits can not be null!").IsNull().Throw();

            if (sportVisits.Count() == 0)
            {
                return $"There isn't any visits for {sportName} from {fromDate} till today's date.";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"{sportName} visits from {fromDate}:");

            var counter = 1;

            foreach (var visit in sportVisits)
            {
                sb.Append($"{counter}. Visit date: {visit.CreatedOn.ToShortDateString()}; ");
                sb.AppendLine($"Sportshall name: {visit.SportshallName}; ");

                counter++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
