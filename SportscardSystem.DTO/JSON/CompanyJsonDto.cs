using Newtonsoft.Json;
using SportscardSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportscardSystem.DTO.JSON
{
    public class CompanyJsonDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("sportscards")]
        public ICollection<Sportscard> Sportscards { get; set; }

        [JsonProperty("clients")]
        public ICollection<Client> Clients { get; set; }

    }
}
