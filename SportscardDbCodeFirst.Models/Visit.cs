using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportscardDbCodeFirst.Models
{
    public class Visit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        [Required]
        public virtual Client Client { get; set; }

        public Guid SportshallId { get; set; }

        [Required]
        public virtual Sportshall Sportshall { get; set; }

        public Guid SportId { get; set; }

        [Required]
        public virtual Sport Sport { get; set; }

        public DateTime Date { get; set; }
    }
}
