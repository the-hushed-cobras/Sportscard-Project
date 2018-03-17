using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportscardSystem.Models
{
    public class Visit
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

        public Guid SportshallId { get; set; }

        /// <summary>
        /// Navigation property - represents related entity
        /// </summary>
        [Required]
        public virtual Sportshall Sportshall { get; set; }

        public Guid SportId { get; set; }

        /// <summary>
        /// Navigation property - represents related entity
        /// </summary>
        [Required]
        public virtual Sport Sport { get; set; }

        public DateTime Date { get; set; }
    }
}
