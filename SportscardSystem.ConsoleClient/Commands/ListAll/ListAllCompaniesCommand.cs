using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportscardSystem.ConsoleClient.Commands.ListAll
{
    public class ListAllCompaniesCommand : ICommand
    {
        private readonly ICompanyService companyService;

        public ListAllCompaniesCommand(ICompanyService companyService) 
        {
            Guard.WhenArgument(companyService, "Company service can not be null!").IsNull().Throw();
            this.companyService = companyService;
        }

        public string Execute(IList<string> parameters)
        {
            var companies = this.companyService.GetAllCompanies();
            Guard.WhenArgument(companies, "Companies can not be null!").IsNull().Throw();

            if (companies.Count() == 0)
            {
                return "There are no registered companies.";
            }

            return string.Join(Environment.NewLine, companies);
        }
    }
}
