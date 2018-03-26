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
using System.Linq;

namespace SportscardSystem.Logic.Services
{
    public class SportService : ISportService
    {
        private readonly ISportscardSystemDbContext dbContext;
        private readonly IMapper mapper;

        public SportService(ISportscardSystemDbContext dbContext, IMapper mapper)
        {
            Guard.WhenArgument(dbContext, "DbContext can not be null").IsNull().Throw();
            Guard.WhenArgument(mapper, "Mapper can not be null").IsNull().Throw();

            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddSport(ISportDto sportDto)
        {
            Guard.WhenArgument(sportDto, "SportDto can not be null").IsNull().Throw();

            var sportToAdd = this.mapper.Map<Sport>(sportDto);

            if (!this.dbContext.Sports.Any(s => s.Name == sportDto.Name))
            {
                this.dbContext.Sports.Add(sportToAdd);
                this.dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("A sport with the same name already exists!");
            }
        }

        //To be implemented
        public void DeleteSport(ISportDto sportDto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ISportDto> GetAllSports()
        {
            var allSports = dbContext.Sports.Where(s => !s.IsDeleted).ProjectTo<SportDto>().ToList();
            Guard.WhenArgument(allSports, "AllSports can not be null").IsNull().Throw();

            return allSports;
        }

        public ISportDto GetMostPlayedSport()
        {
            var mostPlayedSport = dbContext.Sports.Where(s => !s.IsDeleted).OrderByDescending(s => s.Visits.Count()).ThenBy(s => s.Name).FirstOrDefault();
            Guard.WhenArgument(mostPlayedSport, "Most played sport can not be null!").IsNull().Throw();

            var mostPlayedSportDto = this.mapper.Map<SportDto>(mostPlayedSport);

            return mostPlayedSportDto;
        }
    }
}
