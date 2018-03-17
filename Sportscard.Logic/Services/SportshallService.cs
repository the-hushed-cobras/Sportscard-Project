﻿using AutoMapper;
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

            this.dbContext.Sportshalls.Add(sportshallToAdd);
            this.dbContext.SaveChanges();
        }
        //To be implemented
        public void DeleteSportshall(ISportshallDto sportshallDto)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ISportshallDto> GetAllSportshalls()
        {
            var allSportshalls = dbContext.Sportshalls.ProjectTo<ISportshallDto>();
            Guard.WhenArgument(allSportshalls, "AllSportshalls can not be null").IsNull().Throw();

            return allSportshalls;
        }
    }
}
