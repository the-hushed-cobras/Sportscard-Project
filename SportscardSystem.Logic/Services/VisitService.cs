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
using System.Data.Entity;
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
            var clientVisits = dbContext.Visits
                .Where(v => !v.IsDeleted && v.Client.FirstName.ToLower() == firstName && v.Client.LastName.ToLower() == lastName);
            Guard.WhenArgument(clientVisits, "Client visits can not be null!").IsNull().Throw();

            var clientVisitsDto = clientVisits.ProjectTo<VisitViewDto>().ToList();

            return clientVisitsDto;
        }

        public IEnumerable<IVisitViewDto> GetVisitsByDate(string date)
        {
            Guard.WhenArgument(date, "Date can not be null!").IsNullOrEmpty().Throw();
            var visitDate = DateTime.Parse(date);

            var visits = dbContext.Visits.Where(v => !v.IsDeleted && DbFunctions.TruncateTime(v.CreatedOn) == visitDate.Date);
            Guard.WhenArgument(visits, "Visits can not be null!").IsNull().Throw();

            var visitsDto = visits.ProjectTo<VisitViewDto>(visits).ToList();

            return visitsDto;
        }

        public Guid GetClientGuidByNamesAndCompanyId(string clientFirstName, string clientLastName, Guid companyId)
        {
            Guid result;

            try
            {
                result = this.dbContext.Clients.FirstOrDefault(x => x.FirstName == clientFirstName && x.LastName == clientLastName
                                                                 && x.CompanyId == companyId).Id;
            }
            catch (Exception)
            {

                throw new ArgumentException("No such client exists!");
            }

            return result;
        }

        public Guid GetSportshallGuidByName(string sportshallName)
        {
            Guid result;

            try
            {
                result = this.dbContext.Sportshalls.FirstOrDefault(x => x.Name == sportshallName).Id;
            }
            catch (Exception)
            {

                throw new ArgumentException("No such sportshall exists!");
            }

            return result;
        }

        public Guid GetSportGuidByName(string sportName)
        {
            Guid result;

            try
            {
                result = this.dbContext.Sports.FirstOrDefault(x => x.Name == sportName).Id;
            }
            catch (Exception)
            {

                throw new ArgumentException("No such sport exists!");
            }

            return result;
        }

        public IEnumerable<IVisitViewDto> GetVisitsBySport(string sportName)
        {
            var sportVisits = dbContext.Visits
                .Where(v => !v.IsDeleted && v.Sport.Name == sportName);
            Guard.WhenArgument(sportVisits, "Sport visits can not be null!").IsNull().Throw();

            var sportVisitsDto = sportVisits.ProjectTo<VisitViewDto>().ToList();

            return sportVisitsDto;
        }
    }
}
