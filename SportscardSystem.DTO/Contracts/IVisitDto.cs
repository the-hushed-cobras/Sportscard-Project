using SportscardSystem.Architecture.Automapper.Contracts;
using SportscardSystem.Models;
using System;

namespace SportscardSystem.DTO.Contracts
{
    public interface IVisitDto : IMapFrom<Visit>
    {
        /// <summary>
        /// Visit's unique id
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Visit's unique client id
        /// </summary>
        Guid ClientId { get; set; }

        /// <summary>
        /// Visit's unique sportshall id
        /// </summary>
        Guid SportshallId { get; set; }

        /// <summary>
        /// Visit's unique sport id
        /// </summary>
        Guid SportId { get; set; }

        /// <summary>
        /// Visit's date
        /// </summary>
        DateTime Date { get; set; }
    }
}
