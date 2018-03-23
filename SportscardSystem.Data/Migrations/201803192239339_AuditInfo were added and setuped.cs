namespace SportscardSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuditInfowereaddedandsetuped : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Visits", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Visits", "Date", c => c.DateTime(nullable: false));
        }
    }
}
