namespace RentHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNamesToTheCustomerTable : DbMigration
    {
        public override void Up()
        {
            Sql("Update Customers Set Name='Susan Joshi' Where Id = 1");
            Sql("Update Customers Set Name='Ron White' Where Id = 2");
            Sql("Update Customers Set Name='Harry Style' Where Id = 3");
            Sql("Update Customers Set Name='Sumo Rai' Where Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
