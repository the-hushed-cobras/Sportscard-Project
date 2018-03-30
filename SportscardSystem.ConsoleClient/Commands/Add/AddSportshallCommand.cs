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
            Guard.WhenArgument(parameters.Count, "Count of the parameters.").IsNotEqual(1).Throw();

            string name;

            try
            {
                name = parameters[0];
            }
            catch
            {
                throw new ArgumentException("Failed to parse AddSportshall command parameters.");
            }

            Guard.WhenArgument(name, "Sportshall name can not be null!").IsNullOrEmpty().Throw();

            var sportshall = this.SportscardFactory.CreateSportshallDto(name);
            sportshallService.AddSportshall(sportshall);

            return $"{name} sportshall was added to database.";
        }
    }
}
