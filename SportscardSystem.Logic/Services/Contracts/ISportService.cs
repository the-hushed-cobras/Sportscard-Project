using SportscardSystem.DTO.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SportscardSystem.Logic.Services.Contracts
{
    public interface ISportService
    {
        /// <summary>
        /// Gets all sport registered in the database
        /// </summary>
        /// <returns></returns>
        IEnumerable<ISportDto> GetAllSports();

        /// <summary>
        /// Adds a new sport to the database
        /// </summary>
        /// <param name="sport"></param>
        void AddSport(ISportDto sport);

        /// <summary>
        /// Deletes a specified sport from the database 
        /// </summary>
        /// <param name="sport"></param>
        void DeleteSport(ISportDto sport);

        /// <summary>
        /// Gets the most played sport
        /// </summary>
        /// <returns></returns>
        ISportDto GetMostPlayedSport();
    }
}
