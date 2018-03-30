using Newtonsoft.Json;
using SportscardSystem.Models;
using System.Collections.Generic;

namespace SportscardSystem.DTO.JSON
{
    public class CompanyJsonDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("clients")]
        public ICollection<Client> Clients { get; set; }

    }
}
