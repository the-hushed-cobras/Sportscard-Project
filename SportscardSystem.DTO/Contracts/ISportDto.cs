using SportscardSystem.Architecture.Automapper.Contracts;
using SportscardSystem.Models;
using System;

namespace SportscardSystem.DTO.Contracts
{
    public interface ISportDto : IMapFrom<Sport>
    {
        /// <summary>
        /// Sport's unique ud
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Sport's name
        /// </summary>
        string Name { get; set; }
    }
}
