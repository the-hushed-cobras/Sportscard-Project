using SportscardSystem.ConsoleClient.Commands.Contracts;

namespace SportscardSystem.ConsoleClient.Core.Factories.Contracts
{
    public interface ICommandFactory
    {
        /// <summary>
        /// Creates ICommand from commandName string
        /// </summary>
        /// <param name="commandName"></param>
        /// <returns></returns>
        ICommand CreateCommand(string commandName);
    }
}
