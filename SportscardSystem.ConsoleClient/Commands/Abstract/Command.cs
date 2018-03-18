using SportscardSystem.ConsoleClient.Commands.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.Commands.Abstract
{
    public abstract class Command : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
