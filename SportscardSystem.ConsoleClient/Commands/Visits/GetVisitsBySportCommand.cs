using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportscardSystem.ConsoleClient.Commands.Visits
{
    public class GetVisitsBySportCommand : Command, ICommand
    {
        private readonly IVisitService visitService;

        public GetVisitsBySportCommand(ISportscardFactory sportscardFactory, IVisitService visitService)
            : base(sportscardFactory)
        {
            Guard.WhenArgument(visitService, "Visit service can not be null!").IsNull().Throw();
            this.visitService = visitService;
        }

        public string Execute(IList<string> parameters)
        {
            var sportName = parameters[0];
            Guard.WhenArgument(sportName, "Sport can not be null!").IsNullOrEmpty().Throw();

            var allVisits = visitService.GetVisitsBySport(sportName);
            Guard.WhenArgument(allVisits, "All visits can not be null!").IsNull().Throw();

            if (allVisits.Count() == 0)
            {
                return $"Nobody has played {sportName} yet.";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"All times {sportName} has been played:");

            var counter = 1;

            foreach (var visit in allVisits)
            {
                sb.Append($"{counter}. Client name: {visit.ClientFirstName} {visit.ClientLastName}; ");
                sb.Append($"Sportshall name: {visit.SportshallName}; ");
                sb.Append($"Date : {visit.CreatedOn.ToShortDateString()}");
                sb.AppendLine();

                counter++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
