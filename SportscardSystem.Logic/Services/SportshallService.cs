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
    public class SportshallService : ISportshallService
    {
        private readonly ISportscardSystemDbContext dbContext;
        private readonly IMapper mapper;

        public SportshallService(ISportscardSystemDbContext dbContext, IMapper mapper)
        {
            Guard.WhenArgument(dbContext, "DbContext can not be null").IsNull().Throw();
            Guard.WhenArgument(mapper, "Mapper can not be null").IsNull().Throw();

            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddSportshall(ISportshallDto sportshallDto)
        {
            Guard.WhenArgument(sportshallDto, "SportshallDto can not be null").IsNull().Throw();

            var sportshallToAdd = this.mapper.Map<Sportshall>(sportshallDto);

            if (!this.dbContext.Sportshalls.Any(s => s.Name == sportshallDto.Name && !s.IsDeleted))
            {
                this.dbContext.Sportshalls.Add(sportshallToAdd);
                this.dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("A sporthall with the same name already exists!");
            }
        }

        //To be implemented
        public void DeleteSportshall(string sportshallName)
        {
            Guard.WhenArgument(sportshallName, "Sportshall's name cannot be null or empty.").IsNullOrEmpty().Throw();
            var sportshall = this.dbContext.Sportshalls.Where(s => !s.IsDeleted)
                .FirstOrDefault(v => v.Name.ToLower() == sportshallName.ToLower());

            Guard.WhenArgument(sportshall, "The are no sportshall with this name.").IsNull().Throw();

            sportshall.IsDeleted = true;
            sportshall.DeletedOn = DateTime.Now;

            //foreach (var sport in sportshall.Sports)
            //{
            //    //sportshall.Sports.Remove(sport);
            //    sport.IsDeleted = true;
            //    sport.DeletedOn = DateTime.Now;
            //}
            //foreach (var visit in sportshall.Visits)
            //{
            //    //sportshall.Visits.Remove(visit);
            //    visit.IsDeleted = true;
            //    visit.DeletedOn = DateTime.Now;
            //}

            this.dbContext.SaveChanges();
        }

        public IEnumerable<ISportshallDto> GetAllSportshalls()
        {
            var allSportshalls = dbContext.Sportshalls?.Where(s => !s.IsDeleted);
            Guard.WhenArgument(allSportshalls, "AllSportshalls can not be null").IsNull().Throw();

            var allSportshallsDto = allSportshalls.ProjectTo<SportshallDto>();

            return allSportshallsDto;
        }

        public ISportshallDto GetMostVisitedSportshall()
        {
            Sportshall sportshall = this.dbContext.Sportshalls?.Where(s => !s.IsDeleted)
                .OrderByDescending(c => c.Visits.Where(v => !v.IsDeleted).Count())
                .FirstOrDefault();
            Guard.WhenArgument(sportshall, "Most visited sportshall can not be null.").IsNull().Throw();
            Guard.WhenArgument(sportshall.Visits.Where(v => !v.IsDeleted).Count(), "There no sportshall with visits.").IsLessThan(1).Throw();
            ISportshallDto sportshallDto = this.mapper.Map<SportshallDto>(sportshall);
            Guard.WhenArgument(sportshallDto, "SportshallDto can not be null.").IsNull().Throw();
            return sportshallDto;
        }

        public IEnumerable<ISportshallViewDto> GetReport()
        {
            var allSportshalls = dbContext.Sportshalls?.Where(s => !s.IsDeleted);
            Guard.WhenArgument(allSportshalls, "All sportshalls can not be null!").IsNullOrEmpty().Throw();

            var allSportshallsDto = allSportshalls.ProjectTo<SportshallDto>().ToList();
            Guard.WhenArgument(allSportshallsDto, "All sportshallsDto can not be null!").IsNullOrEmpty().Throw();

            var sportscardsDecoded = new List<ISportshallViewDto>();

            foreach (var sportshall in allSportshallsDto)
            {
                var sports = dbContext.Sportshalls?.Where(c => !c.IsDeleted).Where(s => s.Id == sportshall.Id).SelectMany(s => s.Sports);
                Guard.WhenArgument(sports, "Sports can not be null!").IsNullOrEmpty().Throw();

                var allSports = sports.ProjectTo<SportDto>().ToList();
                Guard.WhenArgument(allSports, "All sports can not be null!").IsNullOrEmpty().Throw();

                sportscardsDecoded.Add(new SportshallViewDto(sportshall.Name, allSports));
            }

            return sportscardsDecoded;
        }

        public IEnumerable<IVisitViewDto> GetSportshallVisitsFrom(string sportshallName, string date)
        {
            Guard.WhenArgument(sportshallName, "Sportshall name can not be null!").IsNullOrEmpty().Throw();
            Guard.WhenArgument(date, "Date can not be null!").IsNullOrEmpty().Throw();

            var fromDate = DateTime.Parse(date);

            //var sportshallVisits = this.dbContext.Visits?
            //    .Where(v => !v.IsDeleted && v.Sportshall.Name.ToLower() == sportshallName.ToLower() && DbFunctions.TruncateTime(v.CreatedOn) >= fromDate.Date);
            var sportshallVisits = this.dbContext.Visits?
                .Where(v => !v.IsDeleted && v.Sportshall.Name.ToLower() == sportshallName.ToLower());
            Guard.WhenArgument(sportshallVisits, "Sportshall visits can not be null!").IsNullOrEmpty().Throw();

            //var sportshallVisitsDto = sportshallVisits?.ProjectTo<VisitViewDto>().ToList();
            var sportshallVisitsDto = sportshallVisits?.ProjectTo<VisitViewDto>().ToList().Where(v => v.CreatedOn.Date >= fromDate.Date);

            return sportshallVisitsDto;
        }

        public IEnumerable<IVisitViewDto> GetSportshallVisitFromTo (string sportshallName, string fromDate, string toDate)
        {
            Guard.WhenArgument(sportshallName, "Sportshall name can not be null!").IsNullOrEmpty().Throw();
            Guard.WhenArgument(fromDate, "Date from can not be null!").IsNullOrEmpty().Throw();
            Guard.WhenArgument(toDate, "Date to from can not be null!").IsNullOrEmpty().Throw();

            //var sportshall = this.dbContext.Sportshalls.Where(s => !s.IsDeleted && s.Name.ToLower() == sportshallName.ToLower()).FirstOrDefault();
            //Guard.WhenArgument(sportshall, "There are no sportshall with this name.").IsNull().Throw();

            var fromDateParse = DateTime.Parse(fromDate);
            var toDateParse = DateTime.Parse(toDate);

            var sportshallVisits = this.dbContext.Visits?
                .Where(v => !v.IsDeleted && v.Sportshall.Name.ToLower() == sportshallName.ToLower());
            Guard.WhenArgument(sportshallVisits, "Sportshall visits can not be null!").IsNullOrEmpty().Throw();

            var sportshallVisitsDto = sportshallVisits?.ProjectTo<VisitViewDto>().ToList()
                .Where(v => v.CreatedOn.Date >= fromDateParse.Date && v.CreatedOn.Date <= toDateParse.Date); 
                

            return sportshallVisitsDto;
        }

        public IEnumerable<IVisitViewDto> GetSportshallVisitsTo(string sportshallName, string date)
        {
            Guard.WhenArgument(sportshallName, "Sportshall name can not be null!").IsNullOrEmpty().Throw();
            Guard.WhenArgument(date, "Date can not be null!").IsNullOrEmpty().Throw();

            var toDate = DateTime.Parse(date);
            
            var sportshallVisits = this.dbContext.Visits?
                .Where(v => !v.IsDeleted && v.Sportshall.Name.ToLower() == sportshallName.ToLower());
            Guard.WhenArgument(sportshallVisits, "Sportshall visits can not be null!").IsNullOrEmpty().Throw();
            
            var sportshallVisitsDto = sportshallVisits?.ProjectTo<VisitViewDto>().ToList().Where(v => v.CreatedOn.Date <= toDate.Date);

            return sportshallVisitsDto;
        }
    }
}
