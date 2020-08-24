namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNumberAvailable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movie", "NumberAvailable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movie", "NumberAvailable", c => c.Byte(nullable: false));
        }
    }
}
