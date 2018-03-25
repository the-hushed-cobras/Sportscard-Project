using System;
using System.ComponentModel.DataAnnotations;

namespace SportscardSystem.Models.Contracts
{
    public abstract class AuditInfo : IAuditInfo
    {
        [Editable(false)]
        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        [Editable(false)]
        public DateTime? DeletedOn { get; set; }
    }
}
