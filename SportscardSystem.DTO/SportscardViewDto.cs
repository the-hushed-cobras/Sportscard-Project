using Bytes2you.Validation;
using SportscardSystem.DTO.Contracts;
using System;

namespace SportscardSystem.DTO
{
    public class SportscardViewDto : ISportscardViewDto
    {
        private readonly string clientName;
        private readonly string companyName;

        public SportscardViewDto(string clientName, string companyName)
        {
            Guard.WhenArgument(clientName, "Client name can not be null!").IsNullOrEmpty().Throw();
            Guard.WhenArgument(companyName, "Company name can not be null!").IsNullOrEmpty().Throw();

            this.clientName = clientName;
            this.companyName = companyName;
        }

        public Guid Id { get; }

        public string ClientName => this.clientName;

        public string CompanyName => this.companyName;
    }
}
