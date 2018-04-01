using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.Commands.Delete
{
    public  class DeleteCompanyCommand : Command, ICommand
    {
        private readonly ICompanyService companyService;

        public DeleteCompanyCommand(ISportscardFactory sportscardFactory, ICompanyService companyService)
            : base(sportscardFactory)
        {
            Guard.WhenArgument(companyService, "Company service can not be null!").IsNull().Throw();
            this.companyService = companyService;
        }

        public string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters.Count, "Count of the parameters.").IsNotEqual(1).Throw();

            string companyName = parameters[0];
            Guard.WhenArgument(companyName, "Company name can not be null!").IsNullOrEmpty().Throw();

            this.companyService.DeleteCompany(companyName);

            return $"Company \"{companyName}\" was deleted from database.";
        }
    }
}
