using Bytes2you.Validation;
using SportscardSystem.ConsoleClient.Commands.Abstract;
using SportscardSystem.ConsoleClient.Commands.Contracts;
using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.ConsoleClient.Commands.Add
{
    public class AddCompanyCommand : Command, ICommand
    {
        private readonly ICompanyService companyService;

        public AddCompanyCommand(ISportscardFactory sportscardFactory, ICompanyService companyService) 
            : base(sportscardFactory)
        {
            Guard.WhenArgument(companyService, "Company service can not be null!").IsNull().Throw();
            this.companyService = companyService;
        }

        public string Execute(IList<string> parameters)
        {
            string name;

            try
            {
                name = parameters[0];
            }
            catch
            {
                throw new ArgumentException("Failed to parse AddCompany command parameters.");
            }

            var company = this.SportscardFactory.CreateCompanyDto(name);
            companyService.AddCompany(company);

            return $"\"{name}\" company was added to database.";
        }
    }
}
