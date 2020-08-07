namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberAvailableinMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movie", "NumberAvailable", c => c.Byte(nullable: false));
            Sql("UPDATE Movies SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movie", "NumberAvailable");
        }
    }
}
