using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using SportscardSystem.Data.Contracts;
using SportscardSystem.DTO;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.Logic.Services.Contracts;
using SportscardSystem.Models;

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

        public void DeleteVisit(Guid? visitId)
        {
            Guard.WhenArgument(visitId, "Visit id can not be null!").IsNull().Throw();

            var visit = this.dbContext.Visits.FirstOrDefault(v => !v.IsDeleted && v.Id == visitId);
            Guard.WhenArgument(visit, "There is no such visit!").IsNull().Throw();

            visit.IsDeleted = true;
            visit.DeletedOn = DateTime.Now;

            this.dbContext.SaveChanges();   
        }

        public IEnumerable<IVisitDto> GetAllVisits()
        {
            var allVisits = dbContext.Visits.Where(v => !v.IsDeleted);
            Guard.WhenArgument(allVisits, "AllVisits can not be null").IsNull().Throw();

            var allVisitsDto = allVisits.ProjectTo<VisitDto>().ToList();

            return allVisitsDto;
        }

        public IEnumerable<IVisitViewDto> GetVisitsByClient(string firstName, string lastName)
        {
            Guard.WhenArgument(firstName, "First name can not be null!").IsNullOrEmpty().Throw();
            Guard.WhenArgument(lastName, "Last name can not be null!").IsNullOrEmpty().Throw();

            var clientVisits = dbContext.Visits?
                .Where(v => !v.IsDeleted && v.Client.FirstName.ToLower() == firstName.ToLower() && v.Client.LastName.ToLower() == lastName.ToLower());
            Guard.WhenArgument(clientVisits, "Client visits can not be null!").IsNullOrEmpty().Throw();

            var clientVisitsDto = clientVisits.ProjectTo<VisitViewDto>().ToList();

            return clientVisitsDto;
        }

        public IEnumerable<IVisitViewDto> GetVisitsByDate(string date)
        {
            Guard.WhenArgument(date, "Date can not be null!").IsNullOrEmpty().Throw();
            var visitDate = DateTime.Parse(date);

            //var visits = dbContext.Visits.Where(v => !v.IsDeleted && DbFunctions.TruncateTime(v.CreatedOn) == visitDate.Date);
            var visits = dbContext.Visits.Where(v => !v.IsDeleted);
            Guard.WhenArgument(visits, "Visits can not be null!").IsNullOrEmpty().Throw();

            //var visitsDto = visits.ProjectTo<VisitViewDto>(visits).ToList();
            var visitsDto = visits.ProjectTo<VisitViewDto>(visits).ToList().Where(v => v.CreatedOn.Date == visitDate.Date);

            return visitsDto;
        }

        public IEnumerable<IVisitViewDto> GetVisitsBySportshall(string sportshall)
        {
            var sporthall = this.dbContext.Sportshalls.Where(s => !s.IsDeleted && s.Name.ToLower() == sportshall.ToLower()).FirstOrDefault();
            Guard.WhenArgument(sporthall, "There are no sportshall with this name").IsNull().Throw();

            var visits = this.dbContext.Visits?
                .Where(v => !v.IsDeleted && v.Sportshall.Name.ToLower() == sporthall.Name.ToLower());

            var visitsDto = visits.ProjectTo<VisitViewDto>(visits).ToList();

            return visitsDto;
        }
    }
}
