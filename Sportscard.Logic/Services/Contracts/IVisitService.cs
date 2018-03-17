using SportscardSystem.DTO.Contracts;
using System.Linq;

namespace SportscardSystem.Logic.Services.Contracts
{
    public interface IVisitService
    {
        /// <summary>
        /// Gets all visit registered in the database
        /// </summary>
        /// <returns></returns>
        IQueryable<IVisitDto> GetAllVisits();

        /// <summary>
        /// Adds a new visit to the database
        /// </summary>
        /// <param name="visit"></param>
        void AddVisit(IVisitDto visit);

        /// <summary>
        /// Deletes a specified visit from the database 
        /// </summary>
        /// <param name="visit"></param>
        void DeleteVisit(IVisitDto visit);
    }
}
