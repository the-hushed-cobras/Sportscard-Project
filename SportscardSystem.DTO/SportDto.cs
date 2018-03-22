using SportscardSystem.Architecture.Automapper.Contracts;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.Models;
using System;

namespace SportscardSystem.DTO
{
    public class SportDto : ISportDto, IMapFrom<Sport>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
