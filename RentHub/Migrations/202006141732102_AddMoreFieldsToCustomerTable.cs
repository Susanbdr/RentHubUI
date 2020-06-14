namespace RentHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreFieldsToCustomerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MiddleName", c => c.String(maxLength: 255));
            AddColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Customers", "IsSubscribedToNewsLetter", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "DateOfBirth", c => c.DateTime());
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
            DropColumn("dbo.Customers", "DateOfBirth");
            DropColumn("dbo.Customers", "IsSubscribedToNewsLetter");
            DropColumn("dbo.Customers", "LastName");
            DropColumn("dbo.Customers", "MiddleName");
        }
    }
}
