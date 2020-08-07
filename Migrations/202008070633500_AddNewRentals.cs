namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewRentals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewRentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Customer_Id = c.Int(nullable: false),
                        Movie_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.Movie_ID, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Movie_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewRentals", "Movie_ID", "dbo.Movie");
            DropForeignKey("dbo.NewRentals", "Customer_Id", "dbo.Customer");
            DropIndex("dbo.NewRentals", new[] { "Movie_ID" });
            DropIndex("dbo.NewRentals", new[] { "Customer_Id" });
            DropTable("dbo.NewRentals");
        }
    }
}
