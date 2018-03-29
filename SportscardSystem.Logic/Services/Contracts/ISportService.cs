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
        void AddSport(ISportDto sportDto);
        void AddSportToSportshall(string sport, string hallName);
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

        /// <summary>
        /// Gets all visits for the given sports from the given date until today
        /// </summary>
        /// <param name="sportName">Sport's name</param>
        /// <param name="fromDate">Date from which we track sport visits</param>
        /// <returns></returns>
        IEnumerable<IVisitViewDto> GetSportVisitsFrom(string sportName, string fromDate);

        IEnumerable<IVisitViewDto> GetSportVisitsFromTo(string sportName, string fromDate, string toDate);
    }
}
