namespace SportscardSystem.ConsoleClient.Core.Providers.Contracts
{
    public interface IWriter
    {
        void Write(string toPrint);

        void WriteLine(string toPrint);
    }
}
