using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportscardDbCodeFirst.Models
{
    public class Sportscard
    {
        public Sportscard()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        [Required]
        public virtual Client Client { get; set; }

        public Guid CompanyId { get; set; }

        [Required]
        public virtual Company Company { get; set; }
    }
}
