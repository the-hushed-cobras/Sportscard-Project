using System.Collections.Generic;
using SportscardSystem.DTO.JSON;

namespace SportscardSystem.FileImporters.Utils.Contracts
{
    public interface IJsonDeserializer
    {
        IEnumerable<CompanyJsonDto> Deserialize(string jsonText);
    }
}