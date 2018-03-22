using SportscardSystem.DTO.Contracts;
using System.Collections.Generic;
using System.Linq;
using SportscardSystem.Data.Contracts;
using System;
using SportscardSystem.DTO;
using SportscardSystem.Models;

namespace SportscardSystem.Logic.Services.Contracts
{
    public interface IClientService
    {
        /// <summary>
        /// Gets all clients registered in the database
        /// </summary>
        /// <returns></returns>
        IEnumerable<IClientDto> GetAllClients();

        /// <summary>
        /// Adds a new client to the database
        /// </summary>
        /// <param name="client"></param>
        void AddClient(IClientDto clientDto);

        /// <summary>
        /// Deletes a specified client from the database 
        /// </summary>
        /// <param name="client"></param>
        void DeleteClient(string firstName, string lastName, int? age);

        /// <summary>
        /// Gets the client/s with the most visits
        /// </summary>
        /// <returns></returns>
        IClientDto GetMostActiveClient();
        //IQueryable<IClientDto> GetMostActiveClient();

        Guid GetCompanyGuidByName(string companyName);

       
    }
}
