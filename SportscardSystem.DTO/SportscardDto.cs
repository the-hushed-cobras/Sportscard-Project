using SportscardSystem.DTO.Contracts;
using System;

namespace SportscardSystem.DTO
{
    public class SportscardDto : ISportscardDto
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public Guid CompanyId { get; set; }
    }
}
