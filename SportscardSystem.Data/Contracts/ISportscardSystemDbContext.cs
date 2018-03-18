using SportscardSystem.Models;
using System.Data.Entity;

namespace SportscardSystem.Data.Contracts
{
    public interface ISportscardSystemDbContext
    {
        /// <summary>
        /// A collection of all Sportscards in the database
        /// </summary>
        IDbSet<Sportscard> Sportscards { get; set; }

        /// <summary>
        /// A collection of all Clients in the database
        /// </summary>
        IDbSet<Client> Clients { get; set; }

        /// <summary>
        /// A collection of all Companies in the database
        /// </summary>
        IDbSet<Company> Companies { get; set; }

        /// <summary>
        /// A collection of all Sportshalls in the database
        /// </summary>
        IDbSet<Sportshall> Sportshalls { get; set; }

        /// <summary>
        /// A collection of all Sports in the database
        /// </summary>
        IDbSet<Sport> Sports { get; set; }

        /// <summary>
        /// A collection of all Visits in the database
        /// </summary>
        IDbSet<Visit> Visits { get; set; }

        /// <summary>
        /// Save the data in our database
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}
