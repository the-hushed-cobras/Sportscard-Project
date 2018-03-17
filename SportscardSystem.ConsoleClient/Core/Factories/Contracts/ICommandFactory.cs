using SportscardSystem.ConsoleClient.Commands.Contracts;

namespace SportscardSystem.ConsoleClient.Core.Factories.Contracts
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName);
    }
}
