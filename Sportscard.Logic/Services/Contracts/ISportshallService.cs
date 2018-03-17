using SportscardSystem.Architecture.Automapper.Contracts;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.Models;
using System.Linq;

namespace SportscardSystem.Logic.Services.Contracts
{
    public interface ISportshallService : IMapFrom<Sportshall>
    {
        /// <summary>
        /// Gets all sportshall registered in the database
        /// </summary>
        /// <returns></returns>
        IQueryable<ISportshallDto> GetAllSportshalls();

        /// <summary>
        /// Adds a new sportshall to the database
        /// </summary>
        /// <param name="sportshall"></param>
        void AddSportshall(ISportshallDto sportshall);

        /// <summary>
        /// Deletes a specified sportshall from the database 
        /// </summary>
        /// <param name="sportshall"></param>
        void DeleteSportshall(ISportshallDto sportshall);
    }
}
