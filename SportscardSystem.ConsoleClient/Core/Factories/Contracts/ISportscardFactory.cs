using SportscardSystem.DTO.Contracts;
using System;
using SportscardSystem.Models;

namespace SportscardSystem.ConsoleClient.Core.Factories.Contracts
{
    public interface ISportscardFactory
    {
        /// <summary>
        /// Represents a method that implements the <see cref="IClientDto"> interface with properties given as arguments.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        /// <param name="companyId"></param>
        /// <returns>Instance of <see cref="IClientDto"/> interface.</returns>
        IClientDto CreateClientDto(string firstName, string lastName, int? age, Guid CompanyId);

        /// <summary>
        /// Represents a method that implements the <see cref="ICompanyDto"> interface with properties given as arguments.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Instance of <see cref="ICompanyDto"/> interface.</returns>
        ICompanyDto CreateCompanyDto(string name);

        /// <summary>
        /// Represents a method that implements the <see cref="ISportDto"> interface with properties given as arguments.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Instance of <see cref="ISportDto"/> interface.</returns>
        ISportDto CreateSportDto(string name);

        /// <summary>
        /// Represents a method that implements the <see cref="ISportscardDto"> interface with properties given as arguments.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="companyId"></param>
        /// <returns>Instance of <see cref="ISportscardDto"/> interface.</returns>
        ISportscardDto CreateSportscardDto(Guid clientId, Guid companyId);

        /// <summary>
        /// Represents a method that implements the <see cref="ISportshallDto"> interface with properties given as arguments.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Instance of <see cref="ISportshallDto"/> interface.</returns>
        ISportshallDto CreateSportshallDto(string name);

        /// <summary>
        /// Represents a method that implements the <see cref="IVisitDto"> interface with properties given as arguments.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="sportshallId"></param>
        /// <param name="sportId"></param>
        /// <param name="date"></param>
        /// <returns>Instance of <see cref="IVisitDto"/> interface.</returns>
        IVisitDto CreateVisitDto(Guid clientId, Guid sportshallId, Guid sportId, DateTime date);
    }
}
