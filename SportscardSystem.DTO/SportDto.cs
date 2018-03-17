using SportscardSystem.DTO.Contracts;
using System;

namespace SportscardSystem.DTO
{
    public class SportDto : ISportDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
