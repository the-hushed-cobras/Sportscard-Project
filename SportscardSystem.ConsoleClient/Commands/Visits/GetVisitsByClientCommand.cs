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

namespace SportscardSystem.ConsoleClient.Commands.Visits
{
    public class GetVisitsByClientCommand : Command, ICommand
    {
        private readonly IVisitService visitService;

        public GetVisitsByClientCommand(ISportscardFactory sportscardFactory, IVisitService visitService) 
            : base(sportscardFactory)
        {
            Guard.WhenArgument(visitService, "Visit service can not be null!").IsNull().Throw();
            this.visitService = visitService;
        }

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];

            Guard.WhenArgument(firstName, "First name can not be null!").IsNullOrEmpty().Throw();
            Guard.WhenArgument(lastName, "Last name can not be null!").IsNullOrEmpty().Throw();

            var clientVisits = visitService.GetVisitsByClient(firstName.ToLower(), lastName.ToLower());

            var sb = new StringBuilder();
            sb.AppendLine($"{firstName} {lastName}'s visits:");

            var counter = 1;

            foreach (var visit in clientVisits)
            {
                sb.Append($"{counter}. Visit date: {visit.CreatedOn.ToShortDateString()}; ");
                sb.Append($"Sportshall name: {visit.SportshallName}; ");
                sb.AppendLine($"Sport name: {visit.SportName}");

                counter++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
