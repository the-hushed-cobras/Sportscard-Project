using SportscardSystem.Data.Contracts;
using SportscardSystem.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SportscardSystem.Data
{
    public class SportscardSystemDbContext : DbContext, ISportscardSystemDbContext
    {
        public SportscardSystemDbContext()
            : base("name=SportscardSystem")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder
                .Conventions
                .Remove<OneToManyCascadeDeleteConvention>();

            //modelBuilder.Entity<Sportshall>()
            //.HasMany<Sport>(s => s.Sports)
            //.WithMany(c => c.SportsHalls)
            //.Map(cs =>
            //{
            //    cs.MapLeftKey("SportshallId");
            //    cs.MapRightKey("SportId");
            //    cs.ToTable("SportshallSport");
            //});

            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Sportscard> Sportscards { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Company> Companies { get; set; }

        public virtual DbSet<Sportshall> Sportshalls { get; set; }

        public virtual DbSet<Sport> Sports { get; set; }

        public virtual DbSet<Visit> Visits { get; set; }
    }
}
