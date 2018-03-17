using SportscardSystem.DTO.Contracts;
using System;

namespace SportscardSystem.DTO
{
    public class ClientDto : IClientDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        public Guid CompanyId { get; set; }
    }
}
