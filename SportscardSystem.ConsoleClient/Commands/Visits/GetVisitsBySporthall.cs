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

namespace SportscardSystem.ConsoleClient.Commands.Visits
{
    public class GetVisitsBySporthallCommand : Command, ICommand
    {
        private readonly IVisitService visitService;

        public GetVisitsBySporthall(ISportscardFactory sportscardFactory, IVisitService visitService) : base(sportscardFactory)
        {
            Guard.WhenArgument(visitService, "Visit Service can not be null.").IsNull().Throw();
            this.visitService = visitService;
        }

        public string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters.Count, "Count parameter for visits by sportshall cmd shoul be 1.").IsNotEqual(1).Throw();

            string sportshall = parameters[0];
            Guard.WhenArgument(sportshall, "Sportshall can not be null or empty").IsNotNullOrEmpty().Throw();

            throw new NotImplementedException();
        }
    }
}
