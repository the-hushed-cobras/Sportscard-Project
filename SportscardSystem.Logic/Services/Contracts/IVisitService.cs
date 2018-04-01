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
        void DeleteVisit(Guid? visitId);

        /// <summary>
        /// Gets client's visits by his name
        /// </summary>
        /// <param name="firstName">Client's first name</param>
        /// <param name="lastName">Client's last name</param>
        /// <returns></returns>
        IEnumerable<IVisitViewDto> GetVisitsByClient(string firstName, string lastName);

        /// <summary>
        /// Gets all visits for the following date
        /// </summary>
        /// <param name="date">Visit's date</param>
        /// <returns></returns>
        IEnumerable<IVisitViewDto> GetVisitsByDate(string date);

        IEnumerable<IVisitViewDto> GetVisitsBySportshall(string sportshall);

        Guid GetClientGuidByNamesAndCompanyId(string clientFirstName, string clientLastName, Guid companyId);

        Guid GetSportshallGuidByName(string sportshallName);

        Guid GetSportGuidByName(string sportName);

        IEnumerable<IVisitViewDto> GetVisitsBySport(string sportName);
    }
}
