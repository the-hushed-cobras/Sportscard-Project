namespace SportscardSystem.Data.Migrations
{
    using Newtonsoft.Json;
    using SportscardSystem.Models;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Text;

    public sealed class Configuration : DbMigrationsConfiguration<SportscardSystem.Data.SportscardSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SportscardSystem.Data.SportscardSystemDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            
            using (StreamReader reader = new StreamReader(@"D:\Desktop\TELERIK\ALPHA\Module-3\Sportscard-project\Clients.json"))
            {
                var content = reader.ReadToEnd();
                List<Client> clients = JsonConvert.DeserializeObject<List<Client>>(content);
                context.Clients.AddOrUpdate(clients.ToArray());
            }

            context.SaveChanges();
        }
    }
}
