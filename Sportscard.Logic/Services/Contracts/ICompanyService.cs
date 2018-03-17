using SportscardSystem.Architecture.Automapper.Contracts;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.Models;
using System.Linq;

namespace SportscardSystem.Logic.Services.Contracts
{
    public interface ICompanyService : IMapFrom<Company>
    {
        /// <summary>
        /// Gets all companies registered in the database
        /// </summary>
        /// <returns></returns>
        IQueryable<ICompanyDto> GetAllCompanies();

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
    }
}
