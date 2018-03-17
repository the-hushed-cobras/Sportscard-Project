using SportscardSystem.Models;
using System.Data.Entity;

namespace SportscardSystem.Data.Contracts
{
    public interface ISportscardSystemDbContext
    {
        /// <summary>
        /// A collection of all Sportscards in the database
        /// </summary>
        DbSet<Sportscard> Sportscards { get; set; }

        /// <summary>
        /// A collection of all Clients in the database
        /// </summary>
        DbSet<Client> Clients { get; set; }

        /// <summary>
        /// A collection of all Companies in the database
        /// </summary>
        DbSet<Company> Companies { get; set; }

        /// <summary>
        /// A collection of all Sportshalls in the database
        /// </summary>
        DbSet<Sportshall> Sportshalls { get; set; }

        /// <summary>
        /// A collection of all Sports in the database
        /// </summary>
        DbSet<Sport> Sports { get; set; }

        /// <summary>
        /// A collection of all Visits in the database
        /// </summary>
        DbSet<Visit> Visits { get; set; }
    }
}
