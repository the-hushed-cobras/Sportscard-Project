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
    public class GetSportVisitsToCommand : Command, ICommand
    {
        private readonly ISportService sportService;

        public GetSportVisitsToCommand(ISportscardFactory sportscardFactory, ISportService sportService)
            : base(sportscardFactory)
        {
            Guard.WhenArgument(sportService, "Sport service can not be null!").IsNull().Throw();
            this.sportService = sportService;
        }

        public string Execute(IList<string> parameters)
        {
            var sportName = parameters[0];
            var toDate = parameters[1];

            Guard.WhenArgument(sportName, "Sport name can not be null!").IsNullOrEmpty().Throw();
            Guard.WhenArgument(toDate, "To-date can not be null!").IsNullOrEmpty().Throw();

            var sportVisits = sportService.GetSportVisitsTo(sportName.ToLower(), toDate);
            Guard.WhenArgument(sportVisits, "Sport visits can not be null!").IsNull().Throw();

            if (sportVisits.Count() == 0)
            {
                return $"There aren't any visits for {sportName} up to {toDate}.";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"All times {sportName} has been played up to {toDate}:");

            var counter = 1;

            foreach (var visit in sportVisits)
            {
                sb.Append($"{counter}. Client name: {visit.ClientFirstName} {visit.ClientLastName}; ");
                sb.Append($"Sportshall name: {visit.SportshallName}");
                sb.Append($"Date : {visit.CreatedOn.ToShortDateString()}");
                sb.AppendLine();

                counter++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
