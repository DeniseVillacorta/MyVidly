namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditMembershipName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MembershipType", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipType", "Name", c => c.String());
        }
    }
}
