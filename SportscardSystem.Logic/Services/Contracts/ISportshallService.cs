using SportscardSystem.DTO.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SportscardSystem.Logic.Services.Contracts
{
    public interface ISportshallService
    {
        /// <summary>
        /// Gets all sportshall registered in the database
        /// </summary>
        /// <returns></returns>
        IEnumerable<ISportshallDto> GetAllSportshalls();

        /// <summary>
        /// Adds a new sportshall to the database
        /// </summary>
        /// <param name="sportshall"></param>
        void AddSportshall(ISportshallDto sportshall);

        /// <summary>
        /// Deletes a specified sportshall from the database 
        /// </summary>
        /// <param name="sportshall"></param>
        void DeleteSportshall(string sportshallName);

        /// <summary>
        /// Gets all sportscards with their client and company names
        /// </summary>
        /// <returns></returns>
        IEnumerable<ISportshallViewDto> GetReport();

        /// <summary>
        /// Gets the most visited sportshall
        /// </summary>
        /// <returns></returns>
        ISportshallDto GetMostVisitedSportshall();

        /// <summary>
        /// Gets all sportshall visits from the given date
        /// </summary>
        /// <param name="sportshallName">Sportshall's name</param>
        /// <param name="date">Date from which we track visits</param>
        /// <returns></returns>
        IEnumerable<IVisitViewDto> GetSportshallVisitsFrom(string sportshallName, string date);

        IEnumerable<IVisitViewDto> GetSportshallVisitFromTo(string sportshallName, string fromDate, string toDate);


    }
}
