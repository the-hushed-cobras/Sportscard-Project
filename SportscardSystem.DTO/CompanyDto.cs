using Newtonsoft.Json;
using SportscardSystem.Architecture.Automapper.Contracts;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.Models;
using System;

namespace SportscardSystem.DTO
{
    public class CompanyDto : ICompanyDto, IMapFrom<Company>
    {
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
