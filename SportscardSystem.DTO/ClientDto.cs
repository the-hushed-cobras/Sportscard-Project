using SportscardSystem.Architecture.Automapper.Contracts;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.Models;
using System;
using SportscardSystem.Models.Contracts;

namespace SportscardSystem.DTO
{
    public class ClientDto :  IClientDto, IMapFrom<Client>
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        public Guid CompanyId { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}
