using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using SportscardSystem.Data.Contracts;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using SportscardSystem.Models;
using System;
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

            this.dbContext.Sports.Add(sportToAdd);
            this.dbContext.SaveChanges();
        }

        //To be implemented
        public void DeleteSport(ISportDto sportDto)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ISportDto> GetAllSports()
        {
            var allSports = dbContext.Sports.ProjectTo<ISportDto>();
            Guard.WhenArgument(allSports, "AllSports can not be null").IsNull().Throw();

            return allSports;
        }
    }
}
