using SportscardSystem.DTO.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using System;
using System.Linq;

namespace SportscardSystem.Logic.Services
{
    public class ClientService : IClientService
    {
        public void AddClient(IClientDto clientDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteClient(IClientDto clientDto)
        {
            throw new NotImplementedException();
        }

        public IQueryable<IClientDto> GetAllClients()
        {
            throw new NotImplementedException();
        }

        public IQueryable<IClientDto> GetMostActiveClient()
        {
            throw new NotImplementedException();
        }
    }
}
