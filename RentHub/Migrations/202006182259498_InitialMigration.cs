namespace RentHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "DrivingLicense", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "CellPhoneNumber", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "CellPhoneNumber", c => c.String(maxLength: 255));
            AlterColumn("dbo.AspNetUsers", "DrivingLicense", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
