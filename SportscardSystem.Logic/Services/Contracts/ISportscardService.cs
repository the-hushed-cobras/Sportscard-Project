using SportscardSystem.DTO.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SportscardSystem.Logic.Services.Contracts
{
    public interface ISportscardService
    {
        /// <summar>
        /// Gets all sportscards registered in the database
        /// </summary>
        /// <returns></returns>
        IEnumerable<ISportscardDto> GetAllSportscards();

        /// <summary>
        /// Adds a new sportscard to the database
        /// </summary>
        /// <param name="sportscard"></param>
        void AddSportscard(ISportscardDto sportscard);

        /// <summary>
        /// Deletes a specified sportscard from the database 
        /// </summary>
        /// <param name="sportscard"></param>
        void DeleteSportscard(string firstName, string lastName, string companyName);

        /// <summary>
        /// Gets all sportscards with their client and company names
        /// </summary>
        /// <returns></returns>
        IEnumerable<ISportscardViewDto> GetReport();
    }
}
