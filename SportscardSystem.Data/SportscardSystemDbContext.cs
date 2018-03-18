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
        public virtual IDbSet<Sportscard> Sportscards { get; set; }

        public virtual IDbSet<Client> Clients { get; set; }

        public virtual IDbSet<Company> Companies { get; set; }

        public virtual IDbSet<Sportshall> Sportshalls { get; set; }

        public virtual IDbSet<Sport> Sports { get; set; }

        public virtual IDbSet<Visit> Visits { get; set; }
    }
}
