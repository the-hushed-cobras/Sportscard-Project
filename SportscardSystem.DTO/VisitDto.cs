using SportscardSystem.DTO.Contracts;
using System;

namespace SportscardSystem.DTO
{
    public class VisitDto : IVisitDto
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public Guid SportshallId { get; set; }

        public Guid SportId { get; set; }

        public DateTime Date { get; set; }
    }
}
