using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportscardSystem.ConsoleClient.Commands.ListAll
{
    public class ListAllVisitsCommand : ICommand
    {
        private readonly IVisitService visitService;

        public ListAllVisitsCommand(IVisitService visitService)
        {
            Guard.WhenArgument(visitService, "Visit service can not be null!").IsNull().Throw();
            this.visitService = visitService;
        }

        public string Execute(IList<string> parameters)
        {
            var visits = this.visitService.GetAllVisits();
            Guard.WhenArgument(visits, "Visits can not be null!").IsNull().Throw();

            if (visits.Count() == 0)
            {
                return "There are no visits.";
            }

            return string.Join(Environment.NewLine, visits);
        }
    }
}
