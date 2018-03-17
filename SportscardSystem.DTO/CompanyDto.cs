using SportscardSystem.DTO.Contracts;
using System;

namespace SportscardSystem.DTO
{
    public class CompanyDto : ICompanyDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
