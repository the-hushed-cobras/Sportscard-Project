using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SportscardSystem.Models.Contracts;

namespace SportscardSystem.Models
{
    public class Sportshall : AuditInfo
    {
        public Sportshall()
        {
            this.Sports = new HashSet<Sport>();
            this.Visits = new HashSet<Visit>();
            this.CreatedOn = DateTime.Now;
            this.IsDeleted = false;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Index(IsUnique = true)]
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Invalid company name format!")]
        public string Name { get; set; }

        /// <summary>
        /// Navigation property - represents related entity
        /// </summary>
        public virtual ICollection<Sport> Sports { get; set; }

        /// <summary>
        /// Navigation property - represents related entity
        /// </summary>
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
