using Bytes2you.Validation;
using Newtonsoft.Json;
using SportscardSystem.DTO;
using SportscardSystem.FileImporters.Utils.Contracts;
using System.Collections.Generic;

namespace SportscardSystem.FileImporters.Utils
{
    /// <summary>
    /// Represent a <see cref="JsonJournalsDeserializer"/> class.
    /// </summary>
    public class JsonDeserializerWrapper : IJsonDeserializer
    {
        /// <summary>
        /// Deserializes the JSON to the Journal DTO type - wrapper instance method.
        /// </summary>
        /// <param name="jsonText">The JSON to be deserialized.</param>
        /// <returns>Deserialized collection of Journal DTOs.</returns>
        public IEnumerable<SportscardDto> Deserialize(string jsonText)
        {
            Guard.WhenArgument(jsonText, "Deserialize").IsNullOrEmpty().Throw();

            return JsonConvert.DeserializeObject<IEnumerable<SportscardDto>>(jsonText);
        }
    }
}