using SportscardSystem.DTO;
using System.Collections.Generic;

namespace SportscardSystem.JsonImporter.Utils.Contracts
{
    public interface IJsonDeserializer
    {
        IEnumerable<SportscardDto> Deserialize(string jsonText);
    }
}