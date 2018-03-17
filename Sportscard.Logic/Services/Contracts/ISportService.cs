using SportscardSystem.Architecture.Automapper.Contracts;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.Models;
using System.Linq;

namespace SportscardSystem.Logic.Services.Contracts
{
    public interface ISportService : IMapFrom<Sport>
    {
        /// <summary>
        /// Gets all sport registered in the database
        /// </summary>
        /// <returns></returns>
        IQueryable<ISportDto> GetAllSports();

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
    }
}
