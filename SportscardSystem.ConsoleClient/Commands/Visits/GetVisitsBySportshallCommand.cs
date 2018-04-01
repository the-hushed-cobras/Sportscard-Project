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
    public class GetVisitsBySportshallCommand : Command, ICommand
    {
        private readonly IVisitService visitService;

        public GetVisitsBySportshallCommand(ISportscardFactory sportscardFactory, IVisitService visitService) : base(sportscardFactory)
        {
            Guard.WhenArgument(visitService, "Visit Service can not be null.").IsNull().Throw();
            this.visitService = visitService;
        }

        public string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters.Count, "Count parameter for visits by sportshall cmd shoul be 1.").IsNotEqual(1).Throw();

            string sportshall = parameters[0];
            Guard.WhenArgument(sportshall, "Sportshall can not be null or empty").IsNullOrEmpty().Throw();

            var visitsBySportshall = this.visitService.GetVisitsBySportshall(sportshall);

            Guard.WhenArgument(visitsBySportshall.Count(), $"Thre are no visits at sportshall {sportshall}").IsLessThan(1).Throw();

            var result = new StringBuilder();
            result.AppendLine($"{sportshall} visits:");
            int counter = 1;

            foreach (var visit in visitsBySportshall)
            {
                result.AppendLine($"{counter}. Visit date: {visit.CreatedOn.ToShortDateString()}");
                result.AppendLine($"Client;s name: {visit.ClientFirstName} {visit.ClientLastName}");
                result.AppendLine($"Sport name: {visit.SportName}");

                counter++;
            }

            return result.ToString().TrimEnd();
        }
    }
}
