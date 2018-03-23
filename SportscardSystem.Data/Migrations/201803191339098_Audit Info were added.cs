namespace SportscardSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuditInfowereadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sportscards", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sportscards", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Sportscards", "DeletedOn", c => c.DateTime());
            AddColumn("dbo.Visits", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Visits", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Visits", "DeletedOn", c => c.DateTime());
            AddColumn("dbo.Sports", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sports", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Sports", "DeletedOn", c => c.DateTime());
            AddColumn("dbo.Sportshalls", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sportshalls", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Sportshalls", "DeletedOn", c => c.DateTime());
            DropColumn("dbo.Visits", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Visits", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Sportshalls", "DeletedOn");
            DropColumn("dbo.Sportshalls", "IsDeleted");
            DropColumn("dbo.Sportshalls", "CreatedOn");
            DropColumn("dbo.Sports", "DeletedOn");
            DropColumn("dbo.Sports", "IsDeleted");
            DropColumn("dbo.Sports", "CreatedOn");
            DropColumn("dbo.Visits", "DeletedOn");
            DropColumn("dbo.Visits", "IsDeleted");
            DropColumn("dbo.Visits", "CreatedOn");
            DropColumn("dbo.Sportscards", "DeletedOn");
            DropColumn("dbo.Sportscards", "IsDeleted");
            DropColumn("dbo.Sportscards", "CreatedOn");
        }
    }
}
