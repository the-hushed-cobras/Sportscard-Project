﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using SportscardSystem.Data;
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
    public class CompanyService : ICompanyService
    {
        private readonly ISportscardSystemDbContext dbContext;
        private readonly IMapper mapper;

        public CompanyService(ISportscardSystemDbContext dbContext, IMapper mapper)
        {
            Guard.WhenArgument(dbContext, "DbContext can not be null").IsNull().Throw();
            Guard.WhenArgument(mapper, "Mapper can not be null").IsNull().Throw();

            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddCompany(ICompanyDto companyDto)
        {
            Guard.WhenArgument(companyDto, "CompanyDto can not be null").IsNull().Throw();

            var companyToAdd = this.mapper.Map<Company>(companyDto);

            if (!this.dbContext.Companies.Any(c => c.Name == companyDto.Name))
            {
                this.dbContext.Companies.Add(companyToAdd);
                this.dbContext.SaveChanges();
            }
            else
            {
                if (this.dbContext.Companies.Any(c => c.Name == companyDto.Name && c.IsDeleted))
                {
                    this.dbContext.Companies.Add(companyToAdd);
                    this.dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("A company with the same name already exists!");
                }
            }
        }

        public void DeleteCompany(string companyName)
        {
            Guard.WhenArgument(companyName, "Company name can not be null!").IsNullOrEmpty().Throw();

            var company = this.dbContext.Companies?.FirstOrDefault(c => !c.IsDeleted && c.Name.ToLower() == companyName.ToLower());
            Guard.WhenArgument(company, "There is no such company!").IsNull().Throw();

            company.IsDeleted = true;
            company.DeletedOn = DateTime.Now;

            foreach (var client in company.Clients)
            {
                client.IsDeleted = true;
                client.DeletedOn = DateTime.Now;
            }

            foreach (var sportscard in company.Sportscards)
            {
                sportscard.IsDeleted = true;
                sportscard.DeletedOn = DateTime.Now;
            }

            this.dbContext.SaveChanges();
        }

        public IEnumerable<ICompanyDto> GetAllCompanies()
        {
            try
            {
                var allCompanies = dbContext.Companies?.Where(c => !c.IsDeleted);
                Guard.WhenArgument(allCompanies, "All Companies can not be null!").IsNull().Throw();

                var allCompaniesDto = allCompanies.ProjectTo<CompanyDto>().ToList();

                return allCompaniesDto;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Companies can not be null");
            }
        }

        public ISportshallDto GetCompanysFavouriteSportshall(string companyName)
        {
            throw new NotImplementedException();
        }

        public ICompanyDto GetMostActiveCompany()
        {
            var mostActiveCompany = dbContext.Companies?.Where(c => !c.IsDeleted)
                .OrderByDescending(c => c.Clients.Where(cl => !cl.IsDeleted).Sum(cl => cl.Visits.Where(v => !v.IsDeleted).Count()))
                .ThenBy(c => c.Name).FirstOrDefault();
            Guard.WhenArgument(mostActiveCompany, "Most active company can not be null!").IsNull().Throw();

            var mostActiveCompanyDto = this.mapper.Map<CompanyDto>(mostActiveCompany);

            return mostActiveCompanyDto;
        }
    }
}
