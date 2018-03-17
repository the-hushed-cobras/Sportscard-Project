using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportscardSystem.Models
{
    public class Sportscard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        /// <summary>
        /// Navigation property - represents related entity
        /// </summary>
        [Required]
        public virtual Client Client { get; set; }

        public Guid CompanyId { get; set; }

        /// <summary>
        /// Navigation property - represents related entity
        /// </summary>
        [Required]
        public virtual Company Company { get; set; }
    }
}
