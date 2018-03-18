using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.ConsoleClient.Core.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportscardSystem.ConsoleClient.Core.Providers
{
    public class CommandParser : ICommandParser
    {
        private readonly ICommandFactory commandFactory;

        public CommandParser(ICommandFactory commandFactory)
        {
            Guard.WhenArgument(commandFactory, "Command factory").IsNull().Throw();
            this.commandFactory = commandFactory;
        }

        public ICommand ParseCommand(string fullCommand)
        {
            Guard.WhenArgument(fullCommand, "Full command").IsNullOrWhiteSpace().Throw();

            var commandTokens = fullCommand.Split();
            var commandName = commandTokens[0].ToLower();

            var command = commandFactory.CreateCommand(commandName);

            return command;
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            Guard.WhenArgument(fullCommand, "Full command").IsNullOrWhiteSpace().Throw();

            var commandTokens = fullCommand.Split();
            var commandParts = commandTokens.Skip(1).ToList();

            if (commandParts.Count == 0)
            {
                return new List<string>();
            }

            return commandParts;
        }
    }
}
