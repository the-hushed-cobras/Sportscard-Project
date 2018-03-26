using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System.Collections.Generic;
using System.Text;

namespace SportscardSystem.ConsoleClient.Commands.Visits
{
    public class GetVisitsByDateCommand : Command, ICommand
    {
        private readonly IVisitService visitService;

        public GetVisitsByDateCommand(ISportscardFactory sportscardFactory, IVisitService visitService)
            : base(sportscardFactory)
        {
            Guard.WhenArgument(visitService, "Visit service can not be null!").IsNull().Throw();
            this.visitService = visitService;
        }

        public string Execute(IList<string> parameters)
        {
            var visitDate = parameters[0];
            Guard.WhenArgument(visitDate, "Visit date can not be null!").IsNullOrEmpty().Throw();

            var allVisits = visitService.GetVisitsByDate(visitDate);

            var sb = new StringBuilder();
            sb.AppendLine($"All visits for {visitDate}:");

            var counter = 1;

            foreach (var visit in allVisits)
            {
                sb.Append($"{counter}. Client name: {visit.ClientFirstName} {visit.ClientLastName}; ");
                sb.Append($"Sportshall name: {visit.SportshallName}; ");
                sb.AppendLine($"Sport name: {visit.SportName}");

                counter++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
