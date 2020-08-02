namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genre (GenreId, GenreName) VALUES (1, 'Fantasy')");
            Sql("INSERT INTO Genre (GenreId, GenreName) VALUES (2, 'Comedy')");
            Sql("INSERT INTO Genre (GenreId, GenreName) VALUES (3, 'Horror/Thriller')");
            Sql("INSERT INTO Genre (GenreId, GenreName) VALUES (4, 'Romance')");
            Sql("INSERT INTO Genre (GenreId, GenreName) VALUES (5, 'Action')");
        }
        
        public override void Down()
        {
        }
    }
}
