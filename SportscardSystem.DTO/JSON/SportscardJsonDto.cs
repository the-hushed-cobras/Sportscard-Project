using Newtonsoft.Json;

namespace SportscardSystem.DTO.JSON
{
    public class SportscardJsonDto
    {
        [JsonProperty("client")]
        public ClientJsonDto Client { get; set; }

    }
}
