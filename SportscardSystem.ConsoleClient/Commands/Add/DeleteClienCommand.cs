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
    public class DeleteClientCommand : Command, ICommand
    {
        private readonly ISportService clientService;

        public DeleteClientCommand(ISportscardFactory sportscardFactory, ISportService clientService) : base(sportscardFactory)
        {
            Guard.WhenArgument(clientService, "Sport service can not be null").IsNull().Throw();
            this.clientService = clientService;
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
                throw new ArgumentException("Failed to parse AddSport command parameters.");
            }

            

            return $"\"{name}\" sport was added to database.";

        }
    }
}
