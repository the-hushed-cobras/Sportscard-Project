using System;
using System.Collections.Generic;

namespace SportscardSystem.DTO.Contracts
{
    public interface ISportshallViewDto
    {
        /// <summary>
        /// Sportshall unique id
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Sportshall name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Sposrthall's collection of sports
        /// </summary>
        IEnumerable<ISportDto> Sports { get; }
    }
}
