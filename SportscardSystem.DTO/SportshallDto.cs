using SportscardSystem.Architecture.Automapper.Contracts;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.Models;
using System;

namespace SportscardSystem.DTO
{
    public class SportshallDto : ISportshallDto, IMapFrom<Sportshall>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
