using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;

namespace SportscardSystem.ConsoleClient.Commands.Abstract
{
    public abstract class Command
    {
        private readonly ISportscardFactory sportscardFactory;

        public Command(ISportscardFactory sportscardFactory)
        {
            Guard.WhenArgument(sportscardFactory, "Sportscard factory can not be null!").IsNull().Throw();
            this.sportscardFactory = sportscardFactory;
        }

        protected ISportscardFactory SportscardFactory => this.sportscardFactory;
    }
}
