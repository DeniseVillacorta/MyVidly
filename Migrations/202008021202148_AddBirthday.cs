namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthday : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "CustomerBday", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "CustomerBday");
        }
    }
}
