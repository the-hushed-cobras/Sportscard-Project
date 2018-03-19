using SportscardSystem.ConsoleClient.Core.Factories.Contracts;
using SportscardSystem.DTO;
using SportscardSystem.DTO.Contracts;
using System;

namespace SportscardSystem.ConsoleClient.Core.Factories
{
    public class SportscardFactory : ISportscardFactory
    {
        public IClientDto CreateClientDto(string firstName, string lastName, int age, Guid companyId)
        {
            return new ClientDto() { FirstName = firstName, LastName = lastName, CompanyId = companyId };
        }

        public ICompanyDto CreateCompanyDto(string name)
        {
            return new CompanyDto() { Name = name };
        }

        public ISportDto CreateSportDto(string name)
        {
            return new SportDto() { Name = name };
        }

        public ISportscardDto CreateSportscardDto(Guid clientId, Guid companyId)
        {
            return new SportscardDto() { ClientId = clientId, CompanyId = companyId };
        }

        public ISportshallDto CreateSportshallDto(string name)
        {
            return new SportshallDto() { Name = name};
        }

        public IVisitDto CreateVisitDto(Guid clientId, Guid sportshallId, Guid sportId, DateTime date)
        {
            return new VisitDto() { ClientId = clientId, SportshallId = sportshallId, SportId = sportId, CreatedOn = date };
        }
    }
}
