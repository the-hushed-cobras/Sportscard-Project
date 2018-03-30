using Newtonsoft.Json;
using SportscardSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportscardSystem.DTO.JSON
{
    public class ClientJsonDto
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }

        [JsonProperty("companyId")]
        public Guid CompanyId { get; set; }

        [JsonProperty("sportscards")]
        public ICollection<Sportscard> Sportscards { get; set; }
        
        [JsonProperty("visits")]
        public ICollection<Visit> Visits { get; set; }


        [JsonProperty("company")]
        public CompanyJsonDto Company { get; set; }
        
    }
}
