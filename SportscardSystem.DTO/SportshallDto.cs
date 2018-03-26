using SportscardSystem.Architecture.Automapper.Contracts;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.Models;
using System;
using SportscardSystem.Models.Contracts;

namespace SportscardSystem.DTO
{
    public class SportshallDto :  ISportshallDto, IMapFrom<Sportshall>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
