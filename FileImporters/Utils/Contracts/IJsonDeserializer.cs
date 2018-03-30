using System.Collections.Generic;
using SportscardSystem.DTO.JSON.Contracts;

namespace SportscardSystem.FileImporters.Utils.Contracts
{
    public interface IJsonDeserializer
    {
        IEnumerable<IJsonDto> Deserialize(string jsonText);
    }
}