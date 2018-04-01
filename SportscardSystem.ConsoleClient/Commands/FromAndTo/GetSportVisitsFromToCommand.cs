using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;

namespace SportscardSystem.ConsoleClient.Commands.FromAndTo
{
    public class GetSportVisitsFromToCommand : Command, ICommand
    {
        private readonly ISportService sportService;

        public GetSportVisitsFromToCommand(ISportscardFactory sportscardFactory, ISportService sportService) : base(sportscardFactory)
        {
            Guard.WhenArgument(sportService, "Sport service can not be null.").IsNull().Throw();
            this.sportService = sportService;
        }

        public string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters.Count(), "Parameters for this comman should be 3.").IsNotEqual(3).Throw();

            string sportName = parameters[0];
            string fromDate = parameters[1];
            string toDate = parameters[2];
            Guard.WhenArgument(sportName, "Sport name can not be null.").IsNullOrEmpty().Throw();
            Guard.WhenArgument(fromDate, "From date can not be null.").IsNullOrEmpty().Throw();
            Guard.WhenArgument(toDate, "To date can not be null.").IsNullOrEmpty().Throw();

            var sportVisits = this.sportService.GetSportVisitsFromTo(sportName, fromDate, toDate);
            Guard.WhenArgument(sportVisits.Count(), $"There isn't any visits for {sportName} from {fromDate} till today's date.").IsEqual(0).Throw();

            var sb = new StringBuilder();
            sb.AppendLine($"{sportName} visits from {fromDate} to {toDate}:");

            int counter = 1;

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
