using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SportscardSystem.Models.Contracts;

namespace SportscardSystem.Models
{
    public class Sport : AuditInfo
    {
        public Sport()
        {
            this.SportsHalls = new HashSet<Sportshall>();
            this.Visits = new HashSet<Visit>();
            this.CreatedOn = DateTime.Now;
            this.IsDeleted = false;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Index(IsUnique = true)]
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Invalid sport name format!")]
        public string Name { get; set; }

        /// <summary>
        /// Navigation property - represents related entity
        /// </summary>
        public virtual ICollection<Sportshall> SportsHalls { get; set; }

        /// <summary>
        /// Navigation property - represents related entity
        /// </summary>
        public virtual ICollection<Visit> Visits { get; set; }
    }
}