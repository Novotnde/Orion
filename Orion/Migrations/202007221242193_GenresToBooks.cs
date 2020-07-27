namespace Orion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenresToBooks : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Books", name: "Genre_Id", newName: "Genres_Id");
            RenameIndex(table: "dbo.Books", name: "IX_Genre_Id", newName: "IX_Genres_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Books", name: "IX_Genres_Id", newName: "IX_Genre_Id");
            RenameColumn(table: "dbo.Books", name: "Genres_Id", newName: "Genre_Id");
        }
    }
}
