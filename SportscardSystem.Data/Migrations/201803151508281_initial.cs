namespace SportscardSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
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
                        CompanyId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
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
                        ClientId = c.Guid(nullable: false),
                        CompanyId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.ClientId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ClientId = c.Guid(nullable: false),
                        SportshallId = c.Guid(nullable: false),
                        SportId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .ForeignKey("dbo.Sports", t => t.SportId)
                .ForeignKey("dbo.Sportshalls", t => t.SportshallId)
                .Index(t => t.ClientId)
                .Index(t => t.SportshallId)
                .Index(t => t.SportId);
            
            CreateTable(
                "dbo.Sports",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sportshalls",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
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
                .ForeignKey("dbo.Sportshalls", t => t.Sportshall_Id)
                .ForeignKey("dbo.Sports", t => t.Sport_Id)
                .Index(t => t.Sportshall_Id)
                .Index(t => t.Sport_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visits", "SportshallId", "dbo.Sportshalls");
            DropForeignKey("dbo.Visits", "SportId", "dbo.Sports");
            DropForeignKey("dbo.SportshallSports", "Sport_Id", "dbo.Sports");
            DropForeignKey("dbo.SportshallSports", "Sportshall_Id", "dbo.Sportshalls");
            DropForeignKey("dbo.Visits", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Clients", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Sportscards", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Sportscards", "ClientId", "dbo.Clients");
            DropIndex("dbo.SportshallSports", new[] { "Sport_Id" });
            DropIndex("dbo.SportshallSports", new[] { "Sportshall_Id" });
            DropIndex("dbo.Visits", new[] { "SportId" });
            DropIndex("dbo.Visits", new[] { "SportshallId" });
            DropIndex("dbo.Visits", new[] { "ClientId" });
            DropIndex("dbo.Sportscards", new[] { "CompanyId" });
            DropIndex("dbo.Sportscards", new[] { "ClientId" });
            DropIndex("dbo.Clients", new[] { "CompanyId" });
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
