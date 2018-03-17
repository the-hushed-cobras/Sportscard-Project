using SportscardSystem.ConsoleClient.Core.Providers.Contracts;
using System;

namespace SportscardSystem.ConsoleClient.Core.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
