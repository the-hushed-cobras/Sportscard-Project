using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SportscardSystem.Models.Contracts;

namespace SportscardSystem.Models
{
    public class Company : AuditInfo
    {

        public Company() 
        {
            this.Sportscards = new HashSet<Sportscard>();
            this.Clients = new HashSet<Client>();
            this.CreatedOn = DateTime.Now;
            this.IsDeleted = false;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Invalid company name format!")]
        public string Name { get; set; }

        /// <summary>
        /// Navigation property - represents related entity
        /// </summary>
        public virtual ICollection<Sportscard> Sportscards { get; set; }

        /// <summary>
        /// Navigation property - represents related entity
        /// </summary>
        public virtual ICollection<Client> Clients { get; set; }
    }
}