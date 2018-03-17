using SportscardSystem.Models;
using System.Data.Entity;

namespace SportscardSystem.Data.Contracts
{
    public interface ISportscardSystemDbContext
    {
        DbSet<Sportscard> Sportscards { get; set; }

        DbSet<Client> Clients { get; set; }

        DbSet<Company> Companies { get; set; }

        DbSet<Sportshall> Sportshalls { get; set; }

        DbSet<Sport> Sports { get; set; }

        DbSet<Visit> Visits { get; set; }
    }
}
