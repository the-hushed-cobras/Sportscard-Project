using SportscardSystem.Architecture.Automapper.Contracts;
using SportscardSystem.Models;
using System;

namespace SportscardSystem.DTO.Contracts
{
    public interface ICompanyDto : IMapFrom<Company>
    {
        /// <summary>
        /// Company's unique ud
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Company's name
        /// </summary>
        string Name { get; set; }
    }
}
