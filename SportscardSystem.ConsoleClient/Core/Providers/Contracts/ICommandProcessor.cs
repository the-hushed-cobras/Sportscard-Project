namespace SportscardSystem.ConsoleClient.Core.Providers.Contracts
{
    public interface ICommandProcessor
    {
        string ProcessCommand(string commandAsString);

        string CommandsHelp();
    }
}
