using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using SportscardSystem.Data.Contracts;
using SportscardSystem.DTO;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using SportscardSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SportscardSystem.Logic.Services
{
    public class SportscardService : ISportscardService
    {
        private readonly ISportscardSystemDbContext dbContext;
        private readonly IMapper mapper;

        public SportscardService(ISportscardSystemDbContext dbContext, IMapper mapper)
        {
            Guard.WhenArgument(dbContext, "DbContext can not be null").IsNull().Throw();
            Guard.WhenArgument(mapper, "Mapper can not be null").IsNull().Throw();

            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddSportscard(ISportscardDto sportscardDto)
        {
            Guard.WhenArgument(sportscardDto, "SportscardDto can not be null").IsNull().Throw();

            var sportscardToAdd = this.mapper.Map<Sportscard>(sportscardDto);

            if (!this.dbContext.Sportscards.Any(s => s.ClientId == sportscardDto.ClientId && s.CompanyId == sportscardDto.CompanyId))
            {
                this.dbContext.Sportscards.Add(sportscardToAdd);
                this.dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("A Sportscard with the current ClientId and CompanyId already exists!");
            }
        }

        //To be implemented
        public void DeleteSportscard(ISportscardDto sportscardDto)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ISportscardDto> GetAllSportscards()
        {
            var allSportscards = dbContext.Sportscards.ProjectTo<SportscardDto>();
            Guard.WhenArgument(allSportscards, "AllSportscards can not be null").IsNull().Throw();

            return allSportscards;
        }

        public IQueryable<ISportscardViewDto> GetReport()
        {
            var allSportscards = dbContext.Sportscards.ProjectTo<SportscardDto>();
            var sportscardsDecoded = new List<ISportscardViewDto>();

            foreach (var sportscard in allSportscards)
            {
                var clientName = $"{dbContext.Clients.FirstOrDefault(c => c.Id == sportscard.ClientId).FirstName} {dbContext.Clients.FirstOrDefault(c => c.Id == sportscard.ClientId).LastName}";
                var companyName = dbContext.Companies.FirstOrDefault(c => c.Id == sportscard.CompanyId).Name;

                sportscardsDecoded.Add(new SportscardViewDto(clientName, companyName));
            }

            return sportscardsDecoded.AsQueryable();
        }
    }
}
