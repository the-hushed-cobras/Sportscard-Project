using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
