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

        public void AddSportToSportshall(string sport, string hallName)
        {
            Sportshall sportshall = this.dbContext.Sportshalls.FirstOrDefault(s => s.Name == hallName && s.IsDeleted != true);
            Guard.WhenArgument(sportshall, "No such sportshall.").IsNull().Throw();
            Sport sportAtDb = this.dbContext.Sports.FirstOrDefault(s => s.Name == sport && !s.IsDeleted);
            Guard.WhenArgument(sportAtDb, "No such sport at database, please add it :-)").IsNull().Throw();
            if (!(sportshall.Sports.Any(s => s.Name.ToLower() == sportAtDb.Name.ToLower() && !s.IsDeleted)))
            {
                //sportshall.Sports.Add(new Sport() { Id = sportAtDb.Id, Name = sportAtDb.Name });
                sportshall.Sports.Add(sportAtDb);
                this.dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"There is already {sport} available at {hallName}");
            }

        }

        public void DeleteSportFromSportshall(string sport, string hallName)
        {
            Sportshall sportshall = this.dbContext.Sportshalls.FirstOrDefault(s => s.Name == hallName && s.IsDeleted != true);
            Guard.WhenArgument(sportshall, "No such sportshall.").IsNull().Throw();
            Sport sportAtDb = this.dbContext.Sports.FirstOrDefault(s => s.Name == sport && !s.IsDeleted);
            Guard.WhenArgument(sportAtDb, "No such sport at database, please add it :-)").IsNull().Throw();
            if (sportshall.Sports.Any(s => s.Name == sportAtDb.Name && s.IsDeleted == true))
            {
                throw new ArgumentException($"We have already removed {sport} from {hallName}");
            }
            else
            {
                sportshall.Sports.Remove(sportAtDb);
                this.dbContext.SaveChanges();
            }

        }

        public void AddSport(ISportDto sportDto)
        {
            Guard.WhenArgument(sportDto, "SportDto can not be null").IsNull().Throw();

            var sportToAdd = this.mapper.Map<Sport>(sportDto);

            if (!this.dbContext.Sports.Any(s => s.Name == sportDto.Name && !s.IsDeleted))
            {
                this.dbContext.Sports.Add(sportToAdd);
                this.dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("A sport with the same name already exists!");
            }
        }
        
        public void DeleteSport (Guid? sportId)
        {
            Guard.WhenArgument(sportId, "Visit id can not be null!").IsNull().Throw();

            var sport = this.dbContext.Sports.FirstOrDefault(s => !s.IsDeleted && s.Id == sportId);
            Guard.WhenArgument(sport, "There is no such visit!").IsNull().Throw();

            sport.IsDeleted = true;
            sport.DeletedOn = DateTime.Now;

            this.dbContext.SaveChanges();
        }

        public IEnumerable<ISportDto> GetAllSports()
        {
            var allSports = dbContext.Sports?.Where(s => !s.IsDeleted);
            Guard.WhenArgument(allSports, "AllSports can not be null").IsNull().Throw();

            var allSportsDto = allSports.ProjectTo<SportDto>().ToList();

            return allSportsDto;
        }

        public ISportDto GetMostPlayedSport()
        {
            var mostPlayedSport = dbContext.Sports?.Where(s => !s.IsDeleted)
                .OrderByDescending(s => s.Visits.Where(v => !v.IsDeleted).Count()).ThenBy(s => s.Name).FirstOrDefault();
            Guard.WhenArgument(mostPlayedSport, "Most played sport can not be null!").IsNull().Throw();

            var mostPlayedSportDto = this.mapper.Map<SportDto>(mostPlayedSport);
            Guard.WhenArgument(mostPlayedSportDto, "Most played sport can not be null!").IsNull().Throw();

            return mostPlayedSportDto;
        }

        public IEnumerable<IVisitViewDto> GetSportVisitsFrom(string sportName, string date)
        {
            Guard.WhenArgument(sportName, "Sport name can not be null!").IsNullOrEmpty().Throw();
            Guard.WhenArgument(date, "Date can not be null!").IsNullOrEmpty().Throw();

            var fromDate = DateTime.Parse(date);

            // var sportVisits = this.dbContext.Visits?
            //    .Where(v => !v.IsDeleted && v.Sport.Name.ToLower() == sportName.ToLower() && DbFunctions.TruncateTime(v.CreatedOn) >= fromDate.Date);
            var sportVisits = this.dbContext.Visits?
                .Where(v => !v.IsDeleted && v.Sport.Name.ToLower() == sportName.ToLower());
            Guard.WhenArgument(sportVisits, "Sport visits can not be null!").IsNullOrEmpty().Throw();

            //var sportVisitsDto = sportVisits.ProjectTo<VisitViewDto>().ToList();
            var sportVisitsDto = sportVisits.ProjectTo<VisitViewDto>().ToList().Where(v => v.CreatedOn.Date >= fromDate.Date);

            return sportVisitsDto;
        }

        public IEnumerable<IVisitViewDto> GetSportVisitsFromTo(string sportName, string fromDate, string toDate)
        {
            DateTime fromDateArg;
            DateTime toDateArg;
            try
            {
                fromDateArg = DateTime.Parse(fromDate);
                toDateArg = DateTime.Parse(toDate);
            }
            catch
            {
                throw new ArgumentException("Cant parse date from string");
            }
            Sport sport = this.dbContext.Sports.Where(s => !s.IsDeleted).FirstOrDefault(s => s.Name.ToLower() == sportName.ToLower());
            Guard.WhenArgument(sport, "There are no this sport at Db.").IsNull().Throw();
            var sportVisits = this.dbContext.Visits?
                .Where(v => !v.IsDeleted && v.Sport.Name.ToLower() == sportName.ToLower());
            Guard.WhenArgument(sportVisits, "Sport visits can not be null.").IsNullOrEmpty().Throw();
            var sportVisitsDto = sportVisits.ProjectTo<VisitViewDto>().ToList()
                .Where(v => v.CreatedOn.Date >= fromDateArg.Date && v.CreatedOn.Date <= toDateArg.Date);

            return sportVisitsDto;
        }

        public IEnumerable<IVisitViewDto> GetSportVisitsTo(string sportName, string date)
        {
            Guard.WhenArgument(sportName, "Sport name can not be null!").IsNullOrEmpty().Throw();
            Guard.WhenArgument(date, "Date can not be null!").IsNullOrEmpty().Throw();

            var toDate = DateTime.Parse(date);

            var sportVisits = this.dbContext.Visits?
                .Where(v => !v.IsDeleted && v.Sport.Name.ToLower() == sportName && DbFunctions.TruncateTime(v.CreatedOn) <= toDate.Date);
            Guard.WhenArgument(sportVisits, "Sport visits can not be null!").IsNull().Throw();

            var sportVisitsDto = sportVisits.ProjectTo<VisitViewDto>().ToList();

            return sportVisitsDto;
        }
    }
}
