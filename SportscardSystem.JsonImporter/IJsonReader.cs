using SportscardSystem.DTO;
using System.Collections.Generic;

namespace SportscardSystem.JsonImporter
{
    public interface IJsonReader
    {
        IEnumerable<SportscardDto> ImportSportscards();
    }
}
