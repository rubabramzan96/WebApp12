namespace WebApplication1.Migrations.ApplicationUsersMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoanDateadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DateJoined", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DateJoined");
        }
    }
}
