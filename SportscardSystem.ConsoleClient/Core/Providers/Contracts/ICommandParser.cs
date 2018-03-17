using SportscardSystem.ConsoleClient.Commands.Contracts;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.Core.Providers.Contracts
{
    public interface ICommandParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}
