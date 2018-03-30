using System.Collections.Generic;
using SportscardSystem.DTO.JSON;

namespace SportscardSystem.FileImporters.Utils.Contracts
{
    public interface IJsonDeserializer
    {
        IEnumerable<SportscardJsonDto> Deserialize(string jsonText);
    }
}