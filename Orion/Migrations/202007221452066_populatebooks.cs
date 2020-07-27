namespace Orion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populatebooks : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Books ( Title, NumberInStock, GenreId, PublishedDate, DateAdded) VALUES ( 'Harry Potter', 2, 1, 01/01/2020, 01/01/2020)");
            Sql("INSERT INTO Books ( Title, NumberInStock, GenreId, PublishedDate, DateAdded) VALUES ( 'It', 2, 2, 01/01/2020, 01/01/2020)");
            Sql("INSERT INTO Books ( Title, NumberInStock, GenreId, PublishedDate, DateAdded) VALUES ( 'Lord of the rings', 2, 1, 01/01/2020, 01/01/2020)");
            Sql("INSERT INTO Books ( Title, NumberInStock, GenreId, PublishedDate, DateAdded) VALUES ( 'Fantastic beats', 2, 1, 01/01/2020, 01/01/2020)");

        }

        public override void Down()
        {
        }
    }
}
