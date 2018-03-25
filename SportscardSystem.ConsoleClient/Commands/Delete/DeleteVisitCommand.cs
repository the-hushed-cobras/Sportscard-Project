using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.Commands.Delete
{
    public class DeleteVisitCommand : Command, ICommand
    {
        private readonly IVisitService visitService;

        public DeleteVisitCommand(ISportscardFactory sportscardFactory, IVisitService visitService) 
            : base(sportscardFactory)
        {
            Guard.WhenArgument(visitService, "Visit service can not be null!").IsNull().Throw();
            this.visitService = visitService;
        }

        public string Execute(IList<string> parameters)
        {
            var visitId = parameters[0];
            Guard.WhenArgument(visitId, "Visit id can not be null!").IsNullOrEmpty().Throw();

            this.visitService.DeleteVisit(new Guid(visitId));

            return $"The following visit was deleted from database.";
        }
    }
}
