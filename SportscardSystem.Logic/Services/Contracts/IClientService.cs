using SportscardSystem.DTO.Contracts;
using System.Collections.Generic;
using System.Linq;

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
        void DeleteClient(IClientDto clientDto);

        /// <summary>
        /// Gets the client/s with the most visits
        /// </summary>
        /// <returns></returns>
        IClientDto GetMostActiveClient();
    }
}
