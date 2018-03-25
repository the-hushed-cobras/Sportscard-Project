using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Core.Providers.Contracts;
using System;

namespace SportscardSystem.ConsoleClient.Validator
{
    public class ValidateCore : IValidateCore
    {
        private readonly IWriter writer;

        public ValidateCore(IWriter writer)
        {
            Guard.WhenArgument(writer, "Writer can not be null!").IsNull().Throw();
            this.writer = writer;
        }

        //Validations
        public int IntFromString(string commandParameter, string parameterName)
        {
            int parsedValue = int.TryParse(commandParameter, out parsedValue)
                ? parsedValue
                : throw new ArgumentException($"Please provide a valid integer value for {parameterName}!");

            return parsedValue;
        }

        public void ClientAgeValidation(int? age, string parameterName)
        {
            if (age < 18 || age > 100)
            {
                throw new ArgumentException("Client age should be between 18 and 100 years.");
            }
        }
    }
}
