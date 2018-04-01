using SportscardSystem.DTO;
using System.Collections.Generic;

namespace SportscardSystem.FileImporters.Utils.Contracts
{
    public interface IJsonDeserializer
    {
        IEnumerable<SportscardDto> Deserialize(string jsonText);
    }
}