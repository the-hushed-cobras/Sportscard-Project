using SportscardSystem.DTO.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SportscardSystem.Logic.Services.Contracts
{
    public interface ICompanyService
    {
        /// <summary>
        /// Gets all companies registered in the database
        /// </summary>
        /// <returns></returns>
        IEnumerable<ICompanyDto> GetAllCompanies();

        /// <summary>
        /// Adds a new company to the database
        /// </summary>
        /// <param name="company"></param>
        void AddCompany(ICompanyDto companyDto);

        /// <summary>
        /// Deletes a specified company from the database 
        /// </summary>
        /// <param name="company"></param>
        void DeleteCompany(ICompanyDto companyDto);

        /// <summary>
        /// Gets the company with the most visits
        /// </summary>
        /// <returns></returns>
        ICompanyDto GetMostActiveCompany();
    }
}
