namespace SportscardDbCodeFirst.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Age = c.Int(),
                        CompanyId = c.Int(nullable: false),
                        Company_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sportscards",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        Client_Id = c.Guid(),
                        Company_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        SportshallId = c.Int(nullable: false),
                        SportId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Client_Id = c.Guid(),
                        Sportshall_Id = c.Guid(),
                        Sport_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Sportshalls", t => t.Sportshall_Id)
                .ForeignKey("dbo.Sports", t => t.Sport_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.Sportshall_Id)
                .Index(t => t.Sport_Id);
            
            CreateTable(
                "dbo.Sports",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        SporthallId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sportshalls",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        SportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SportshallSports",
                c => new
                    {
                        Sportshall_Id = c.Guid(nullable: false),
                        Sport_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sportshall_Id, t.Sport_Id })
                .ForeignKey("dbo.Sportshalls", t => t.Sportshall_Id, cascadeDelete: true)
                .ForeignKey("dbo.Sports", t => t.Sport_Id, cascadeDelete: true)
                .Index(t => t.Sportshall_Id)
                .Index(t => t.Sport_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visits", "Sport_Id", "dbo.Sports");
            DropForeignKey("dbo.Visits", "Sportshall_Id", "dbo.Sportshalls");
            DropForeignKey("dbo.SportshallSports", "Sport_Id", "dbo.Sports");
            DropForeignKey("dbo.SportshallSports", "Sportshall_Id", "dbo.Sportshalls");
            DropForeignKey("dbo.Visits", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Sportscards", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Sportscards", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Clients", "Company_Id", "dbo.Companies");
            DropIndex("dbo.SportshallSports", new[] { "Sport_Id" });
            DropIndex("dbo.SportshallSports", new[] { "Sportshall_Id" });
            DropIndex("dbo.Visits", new[] { "Sport_Id" });
            DropIndex("dbo.Visits", new[] { "Sportshall_Id" });
            DropIndex("dbo.Visits", new[] { "Client_Id" });
            DropIndex("dbo.Sportscards", new[] { "Company_Id" });
            DropIndex("dbo.Sportscards", new[] { "Client_Id" });
            DropIndex("dbo.Clients", new[] { "Company_Id" });
            DropTable("dbo.SportshallSports");
            DropTable("dbo.Sportshalls");
            DropTable("dbo.Sports");
            DropTable("dbo.Visits");
            DropTable("dbo.Sportscards");
            DropTable("dbo.Companies");
            DropTable("dbo.Clients");
        }
    }
}
