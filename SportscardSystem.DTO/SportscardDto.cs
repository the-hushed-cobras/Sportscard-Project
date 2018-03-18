using SportscardSystem.Architecture.Automapper.Contracts;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.Models;
using System;

namespace SportscardSystem.DTO
{
    public class SportscardDto : ISportscardDto, IMapFrom<Sportscard>
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public Guid CompanyId { get; set; }
    }
}
