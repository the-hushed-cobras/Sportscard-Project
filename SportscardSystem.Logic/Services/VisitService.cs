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

        public void DeleteVisit(Guid visitId)
        {
            var visit = this.dbContext.Visits.FirstOrDefault(v => !v.IsDeleted && v.Id == visitId);
            Guard.WhenArgument(visit, "There is no such visit!").IsNull().Throw();

            visit.IsDeleted = true;
            visit.DeletedOn = DateTime.Now;

            this.dbContext.SaveChanges();   
        }

        public IEnumerable<IVisitDto> GetAllVisits()
        {
            var allVisits = dbContext.Visits.Where(v => !v.IsDeleted).ProjectTo<VisitDto>().ToList();
            Guard.WhenArgument(allVisits, "AllVisits can not be null").IsNull().Throw();

            return allVisits;
        }

        public IEnumerable<IVisitViewDto> GetVisitsByClient(string firstName, string lastName)
        {
            var clientVisits = dbContext.Visits.Where(v => !v.IsDeleted && v.Client.FirstName.ToLower() == firstName.ToLower() && v.Client.LastName.ToLower() == lastName.ToLower());
            Guard.WhenArgument(clientVisits, "Client visits can not be null!").IsNull().Throw();

            var clientVisitsDto = clientVisits.ProjectTo<VisitViewDto>().ToList();

            return clientVisitsDto;
        }
    }
}
