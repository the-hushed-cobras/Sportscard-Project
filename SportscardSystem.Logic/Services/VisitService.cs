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
    public class VisitService : IVisitService
    {
        private readonly ISportscardSystemDbContext dbContext;
        private readonly IMapper mapper;

        public VisitService(ISportscardSystemDbContext dbContext, IMapper mapper)
        {
            Guard.WhenArgument(dbContext, "DbContext can not be null").IsNull().Throw();
            Guard.WhenArgument(mapper, "Mapper can not be null").IsNull().Throw();

            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddVisit(IVisitDto visitDto)
        {
            Guard.WhenArgument(visitDto, "VisitDto can not be null").IsNull().Throw();

            var visitToAdd = this.mapper.Map<Visit>(visitDto);

            if (!this.dbContext.Visits.Any(v => v.ClientId == visitDto.ClientId && v.CreatedOn.Day == visitDto.CreatedOn.Day))
            {
                this.dbContext.Visits.Add(visitToAdd);
                this.dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("A client with this ClientId has already used his daily visit!");
            }
        }

        //To be implemented
        public void DeleteVisit(IVisitDto visitDto)
        {
            throw new NotImplementedException();
        }

        public IQueryable<IVisitDto> GetAllVisits()
        {
            var allVisits = dbContext.Visits.ProjectTo<VisitDto>();
            Guard.WhenArgument(allVisits, "AllVisits can not be null").IsNull().Throw();

            return allVisits;
        }
    }
}
