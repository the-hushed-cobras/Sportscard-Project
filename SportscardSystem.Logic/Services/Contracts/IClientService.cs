using SportscardSystem.DTO.Contracts;
using System.Linq;
using SportscardSystem.Data.Contracts;
using System;

namespace SportscardSystem.Logic.Services.Contracts
{
    public interface IClientService
    {
        /// <summary>
        /// Gets all clients registered in the database
        /// </summary>
        /// <returns></returns>
        IQueryable<IClientDto> GetAllClients();

        /// <summary>
        /// Adds a new client to the database
        /// </summary>
        /// <param name="client"></param>
        void AddClient(IClientDto clientDto);

        /// <summary>
        /// Deletes a specified client from the database 
        /// </summary>
        /// <param name="client"></param>
        void DeleteClient(IClientDto clientDto);

        /// <summary>
        /// Gets the client/s with the most visits
        /// </summary>
        /// <returns></returns>
        IQueryable<IClientDto> GetMostActiveClient();

        Guid GetCompanyGuidByName(string companyName);
    }
}
