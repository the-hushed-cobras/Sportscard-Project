namespace SportscardSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Companynamecanbe30symbolsmaximumnow : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Companies", "Name", c => c.String(nullable: false, maxLength: 30));
            CreateIndex("dbo.Companies", "Name", unique: true);
            CreateIndex("dbo.Sports", "Name", unique: true);
            CreateIndex("dbo.Sportshalls", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Sportshalls", new[] { "Name" });
            DropIndex("dbo.Sports", new[] { "Name" });
            DropIndex("dbo.Companies", new[] { "Name" });
            AlterColumn("dbo.Companies", "Name", c => c.String(nullable: false));
        }
    }
}
