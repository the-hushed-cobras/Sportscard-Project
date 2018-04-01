using SportscardSystem.DTO;
using System.Collections.Generic;

namespace SportscardSystem.FileImporters
{
    public interface IJsonReader
    {
        IEnumerable<SportscardDto> ImportSportscards();
    }
}
