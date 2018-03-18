using System;

namespace SportscardSystem.DTO.Contracts
{
    public interface ISportshallDto
    {
        /// <summary>
        /// Sporthall's unique ud
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Sporthall's name
        /// </summary>
        string Name { get; set; }
    }
}
