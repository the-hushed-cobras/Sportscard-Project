using System;

namespace SportscardSystem.DTO.Contracts
{
    public interface ISportscardViewDto
    {
        /// <summary>
        /// Sportscard's unique id
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Sportscard's client name
        /// </summary>
        string ClientName { get; }

        /// <summary>
        /// Sportscard's company name
        /// </summary>
        string CompanyName { get; }
    }
}
