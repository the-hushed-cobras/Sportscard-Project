using System;

namespace SportscardSystem.Models.Contracts
{
    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }

        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
