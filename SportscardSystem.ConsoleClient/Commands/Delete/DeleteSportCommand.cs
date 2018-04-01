using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.Commands.Delete
{
    public class DeleteSportCommand : Command, ICommand
    {
        private readonly ISportService sportService;
        private readonly ISportscardFactory sportscardFactory;

        public DeleteSportCommand(ISportscardFactory sportscardFactory, ISportService sportService) : base(sportscardFactory)
        {
            Guard.WhenArgument(sportscardFactory, "Sportscard Factory can not be null.").IsNull().Throw();
            Guard.WhenArgument(sportService, "SportshallService  can not be null.").IsNull().Throw();
            this.sportService = sportService;
            this.sportscardFactory = sportscardFactory;
        }

        public string Execute(IList<string> parameters)
        {
            var sportName = parameters[0];
            Guard.WhenArgument(sportName, "Sport name can not be null!").IsNullOrEmpty().Throw();

            this.sportService.DeleteSport(sportName);

            return $"The following sport was deleted from database.";
        }
    }
}
