namespace RentHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMiddleAndLastName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Customers", "FirstName");
            DropColumn("dbo.Customers", "MiddleName");
            DropColumn("dbo.Customers", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Customers", "MiddleName", c => c.String(maxLength: 255));
            AddColumn("dbo.Customers", "FirstName", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Customers", "Name");
        }
    }
}
