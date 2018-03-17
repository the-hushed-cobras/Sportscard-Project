using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using SportscardSystem.Data.Contracts;
using SportscardSystem.DTO;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using SportscardSystem.Models;
using System;
using System.Linq;

namespace SportscardSystem.Logic.Services
{
    public class ClientService : IClientService
    {
        private readonly ISportscardSystemDbContext dbContext;
        private readonly IMapper mapper;

        public ClientService(ISportscardSystemDbContext dbContext, IMapper mapper)
        {
            Guard.WhenArgument(dbContext, "DbContext can not be null").IsNull().Throw();
            Guard.WhenArgument(mapper, "Mapper can not be null").IsNull().Throw();

            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddClient(IClientDto clientDto)
        {
            Guard.WhenArgument(clientDto, "ClientDto can not be null").IsNull().Throw();

            var clientToAdd = this.mapper.Map<Client>(clientDto);

            this.dbContext.Clients.Add(clientToAdd);
            this.dbContext.SaveChanges();
        }

        //To be implemented
        public void DeleteClient(IClientDto clientDto)
        {
            Guard.WhenArgument(clientDto, "ClientDto can not be null").IsNull().Throw();
        }

        public IQueryable<ClientDto> GetAllClients()
        {
            var allClients = this.dbContext.Clients.ProjectTo<ClientDto>();
            Guard.WhenArgument(allClients, "AllClients can not be null").IsNull().Throw();

            Console.WriteLine("test");
            return allClients;
        }

        public IQueryable<IClientDto> GetMostActiveClient()
        {
            throw new NotImplementedException();
        }
    }
}
