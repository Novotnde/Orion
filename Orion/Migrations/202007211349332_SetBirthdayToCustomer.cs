namespace Orion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetBirthdayToCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = CAST('1980-01-01' AS DATETIME) WHERE Id = 1");
            Sql("UPDATE Customers SET Birthdate = CAST('1989-01-01' AS DATETIME) WHERE Id = 2");
            Sql("UPDATE Customers SET Birthdate = CAST('1900-01-01' AS DATETIME) WHERE Id = 3");
        }
        
        public override void Down()
        {
        }
    }
}
