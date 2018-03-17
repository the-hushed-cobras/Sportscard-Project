using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportscardSystem.Models
{
    public class Sportshall
    {
        public Sportshall()
        {
            this.Sports = new HashSet<Sport>();
            this.Visits = new HashSet<Visit>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Invalid company name format!")]
        public string Name { get; set; }

        public virtual ICollection<Sport> Sports { get; set; }

        public virtual ICollection<Visit> Visits { get; set; }
    }
}
