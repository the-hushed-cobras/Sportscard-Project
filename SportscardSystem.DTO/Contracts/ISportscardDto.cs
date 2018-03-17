using System;

namespace SportscardSystem.DTO.Contracts
{
    public interface ISportscardDto
    {
        /// <summary>
        /// Sportscard's unique id
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Sportscard's unique client id
        /// </summary>
        Guid ClientId { get; set; }

        /// <summary>
        /// Sportscard's unique company id
        /// </summary>
        Guid CompanyId { get; set; }
    }
}
