using SportscardSystem.ConsoleClient.Core.Providers.Contracts;
using System;

namespace SportscardSystem.ConsoleClient.Core.Providers
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string toPrint)
        {
            Console.Write(toPrint);
        }

        public void WriteLine(string toPrint)
        {
            Console.WriteLine(toPrint);
        }
    }
}
