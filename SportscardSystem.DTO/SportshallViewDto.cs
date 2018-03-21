using Bytes2you.Validation;
using SportscardSystem.DTO.Contracts;
using System;
using System.Collections.Generic;

namespace SportscardSystem.DTO
{
    public class SportshallViewDto : ISportshallViewDto
    {
        private readonly string name;
        private readonly IEnumerable<ISportDto> sports;

        public SportshallViewDto(string name, IEnumerable<ISportDto> sports)
        {
            Guard.WhenArgument(name, "Sposrthall name can not be null!").IsNullOrEmpty().Throw();
            Guard.WhenArgument(sports, "Sports can not be null!").IsNull().Throw();

            this.name = name;
            this.sports = sports;
        }

        public Guid Id { get; }

        public string Name => this.name;

        public IEnumerable<ISportDto> Sports => this.sports;
    }
}
