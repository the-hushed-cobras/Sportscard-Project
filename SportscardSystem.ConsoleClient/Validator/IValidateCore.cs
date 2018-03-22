namespace SportscardSystem.ConsoleClient.Validator
{
    public interface IValidateCore
    {
        int IntFromString(string commandParameter, string parameterName);

        void ClientAgeValidation(int? age, string parameterName);
    }
}