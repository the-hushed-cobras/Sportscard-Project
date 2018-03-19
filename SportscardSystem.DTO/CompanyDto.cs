using SportscardSystem.Architecture.Automapper.Contracts;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.Models;
using System;

namespace SportscardSystem.DTO
{
    public class CompanyDto : ICompanyDto, IMapFrom<Company>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        //public DateTime CreatedOn { get; set; }

    }
}
