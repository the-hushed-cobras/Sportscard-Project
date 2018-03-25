using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.Commands.Add
{
    public class AddSportshallCommand : Command, ICommand
    {
        private readonly ISportshallService sportshallService;

        public AddSportshallCommand(ISportscardFactory sportscardFactory, ISportshallService sportshallService)
            : base(sportscardFactory)
        {
            Guard.WhenArgument(sportshallService, "Sportshall service can not be null!").IsNull().Throw();
            this.sportshallService = sportshallService;
        }

        public string Execute(IList<string> parameters)
        {
            string name;

            try
            {
                name = parameters[0];
            }
            catch
            {
                throw new ArgumentException("Failed to parse AddSportshall command parameters.");
            }

            var sportshall = this.SportscardFactory.CreateSportshallDto(name);
            sportshallService.AddSportshall(sportshall);

            return $"{name} sportshall was added to database.";
        }
    }
}
