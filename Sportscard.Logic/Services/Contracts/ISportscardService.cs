using SportscardSystem.Architecture.Automapper.Contracts;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.Models;
using System.Linq;

namespace SportscardSystem.Logic.Services.Contracts
{
    public interface ISportscardService : IMapFrom<Sportscard>
    {
        /// <summar>
        /// Gets all sportscards registered in the database
        /// </summary>
        /// <returns></returns>
        IQueryable<ISportscardDto> GetAllSportscards();

        /// <summary>
        /// Adds a new sportscard to the database
        /// </summary>
        /// <param name="sportscard"></param>
        void AddSportscard(ISportscardDto sportscard);

        /// <summary>
        /// Deletes a specified sportscard from the database 
        /// </summary>
        /// <param name="sportscard"></param>
        void DeleteSportscard(ISportscardDto sportscard);
    }
}
