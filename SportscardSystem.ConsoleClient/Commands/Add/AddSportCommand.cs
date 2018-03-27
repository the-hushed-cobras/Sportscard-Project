using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.Logic.Services.Contracts;

namespace SportscardSystem.ConsoleClient.Commands.Add
{
    public class AddSportCommand : Command, ICommand
    {
        private readonly ISportService sportService;

        public AddSportCommand(ISportscardFactory sportscardFactory, ISportService sportService) : base(sportscardFactory)
        {
            Guard.WhenArgument(sportService, "Sport service can not be null").IsNull().Throw();
            this.sportService = sportService;
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
                throw new ArgumentException("Failed to parse AddSport command parameters.");
            }

            ISportDto sport = this.SportscardFactory.CreateSportDto(name);
            sportService.AddSport(sport);

            return $"\"{name}\" sport was added to database.";

        }
    }
}
