namespace SportscardSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuditionInfoTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clients", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Clients", "DeletedOn", c => c.DateTime());
            AddColumn("dbo.Companies", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Companies", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Companies", "DeletedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "DeletedOn");
            DropColumn("dbo.Companies", "IsDeleted");
            DropColumn("dbo.Companies", "CreatedOn");
            DropColumn("dbo.Clients", "DeletedOn");
            DropColumn("dbo.Clients", "IsDeleted");
            DropColumn("dbo.Clients", "CreatedOn");
        }
    }
}
