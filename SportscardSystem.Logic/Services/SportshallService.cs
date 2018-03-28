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

            if (!this.dbContext.Sportshalls.Any(s => s.Name == sportshallDto.Name))
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
        public void DeleteSportshall(ISportshallDto sportshallDto)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerable<ISportshallViewDto> GetReport()
        {
            var allSportshalls = dbContext.Sportshalls?.ProjectTo<SportshallDto>().ToList();
            var sportscardsDecoded = new List<ISportshallViewDto>();

            foreach (var sportshall in allSportshalls)
            {
                var sports = dbContext.Sportshalls?.Where(s => s.Id == sportshall.Id).SelectMany(s => s.Sports);
                var allSports = sports.ProjectTo<SportDto>().ToList();

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
    }
}
