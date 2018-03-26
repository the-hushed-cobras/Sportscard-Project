using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.Commands.GetMost
{
    public class GetMostActiveCompanyCommand : Command, ICommand
    {
        private readonly ICompanyService companyService;

        public GetMostActiveCompanyCommand(ISportscardFactory sportscardFactory, ICompanyService companyService) 
            : base(sportscardFactory)
        {
            Guard.WhenArgument(companyService, "Company service can not be null!").IsNull().Throw();
            this.companyService = companyService;
        }

        public string Execute(IList<string> parameters)
        {
            var mostActiveCompany = companyService.GetMostActiveCompany();
            Guard.WhenArgument(mostActiveCompany, "Most active company can not be null!").IsNull().Throw();

            return $"Most active company: {mostActiveCompany.Name}";
        }
    }
}
