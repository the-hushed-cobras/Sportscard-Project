using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportscardSystem.Models
{
    public class Sport
    {
        public Sport()
        {
            this.SportsHalls = new HashSet<Sportshall>();
            this.Visits = new HashSet<Visit>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Invalid sport name format!")]
        public string Name { get; set; }

        public virtual ICollection<Sportshall> SportsHalls { get; set; }

        public virtual ICollection<Visit> Visits { get; set; }
    }
}