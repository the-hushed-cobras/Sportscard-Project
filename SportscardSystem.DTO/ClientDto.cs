using Newtonsoft.Json;
using SportscardSystem.Architecture.Automapper.Contracts;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.Models;
using System;

namespace SportscardSystem.DTO
{
    public class ClientDto : IClientDto, IMapFrom<Client>
    {
        public Guid Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }

        [JsonProperty("company")]
        public CompanyDto Company { get; set; }

        public Guid CompanyId { get; set; }
        
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }

    }
}
