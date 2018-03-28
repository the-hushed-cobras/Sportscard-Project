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

        public void DeleteSportscard(string firstName, string lastName, string companyName)
        {
            Guard.WhenArgument(firstName, "First name can not be null!").IsNullOrEmpty().Throw();
            Guard.WhenArgument(lastName, "Last name can not be null!").IsNullOrEmpty().Throw();
            Guard.WhenArgument(companyName, "Company name can not be null!").IsNullOrEmpty().Throw();

            var sportscard = this.dbContext.Sportscards?.Where(s => !s.IsDeleted)
                .FirstOrDefault(v =>
                v.Client.FirstName.ToLower() + v.Client.LastName.ToLower() == firstName.ToLower() + lastName.ToLower() &&
                v.Company.Name.ToLower() == companyName.ToLower());
            Guard.WhenArgument(sportscard, "Sportscard can not be null!").IsNull().Throw();

            sportscard.IsDeleted = true;
            sportscard.DeletedOn = DateTime.Now;

            this.dbContext.SaveChanges();
        }

        public IEnumerable<ISportscardDto> GetAllSportscards()
        {
            var allSportscards = dbContext.Sportscards?.Where(s => !s.IsDeleted);
            Guard.WhenArgument(allSportscards, "AllSportscards can not be null").IsNull().Throw();

            var allsportscardsDto = allSportscards.ProjectTo<SportscardDto>().ToList();

            return allsportscardsDto;
        }

        public IEnumerable<ISportscardViewDto> GetReport()
        {
            var allSportscards = dbContext.Sportscards?.Where(s => !s.IsDeleted);
            Guard.WhenArgument(allSportscards, "All sportscards can not be null!").IsNullOrEmpty().Throw();

            var allSportscardsDto = allSportscards.ProjectTo<SportscardDto>().ToList();
            Guard.WhenArgument(allSportscardsDto, "All sportscardsdto can not be null!").IsNullOrEmpty().Throw();

            var sportscardsDecoded = new List<ISportscardViewDto>();

            foreach (var sportscard in allSportscardsDto)
            {
                var clientName = 
                    $"{dbContext.Clients?.Where(c => !c.IsDeleted).FirstOrDefault(c => c.Id == sportscard.ClientId).FirstName} " +
                    $"{dbContext.Clients?.Where(c => !c.IsDeleted).FirstOrDefault(c => c.Id == sportscard.ClientId).LastName}";

                var companyName = dbContext.Companies?.Where(c => !c.IsDeleted).FirstOrDefault(c => c.Id == sportscard.CompanyId).Name;

                sportscardsDecoded.Add(new SportscardViewDto(clientName, companyName));
            }

            return sportscardsDecoded;
        }
    }
}
