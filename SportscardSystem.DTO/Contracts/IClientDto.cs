using System;

namespace SportscardSystem.DTO.Contracts
{
    public interface IClientDto
    {
        /// <summary>
        /// Client's unique id
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Client's first name
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Client's last name
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// Client;s age 
        /// </summary>
        int? Age { get; set; }

        /// <summary>
        /// Client's company unique id
        /// </summary>
        Guid CompanyId { get; set; }
    }
}
