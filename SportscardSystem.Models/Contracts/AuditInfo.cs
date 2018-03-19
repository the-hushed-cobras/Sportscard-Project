using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
