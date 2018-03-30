using Newtonsoft.Json;
using SportscardSystem.Models;
using System;
using System.Collections.Generic;

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

        [JsonProperty("company")]
        public CompanyJsonDto Company { get; set; }
        
    }
}
