using SportscardSystem.DTO.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.Logic.Services.Contracts
{
    public interface IVisitService
    {
        /// <summary>
        /// Gets all visit registered in the database
        /// </summary>
        /// <returns></returns>
        IEnumerable<IVisitDto> GetAllVisits();

        /// <summary>
        /// Adds a new visit to the database
        /// </summary>
        /// <param name="visit"></param>
        void AddVisit(IVisitDto visit);

        /// <summary>
        /// Deletes a specified visit from the database by its id
        /// </summary>
        /// <param name="visit"></param>
        void DeleteVisit(Guid visitId);
    }
}
