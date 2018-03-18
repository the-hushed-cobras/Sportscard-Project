using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Core.Providers.Contracts;

namespace SportscardSystem.ConsoleClient.Core.Providers
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly ICommandParser parser;

        public CommandProcessor(ICommandParser parser)
        {
            Guard.WhenArgument(parser, "Parser");
            this.parser = parser;
        }

        public string ProcessCommand(string commandAsString)
        {
            Guard.WhenArgument(commandAsString, "command").IsNullOrWhiteSpace().Throw();

            var command = parser.ParseCommand(commandAsString);
            var parameters = parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);

            return executionResult;
        }
    }
}
