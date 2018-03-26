using SportscardSystem.Architecture.Automapper.Contracts;
using SportscardSystem.DTO.Contracts;
using SportscardSystem.Models;
using System;

namespace SportscardSystem.DTO
{
    public class VisitViewDto : IVisitViewDto, IMapFrom<Visit>
    {
        public Guid Id { get; set; }

        public string SportshallName { get; set; }

        public string SportName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
