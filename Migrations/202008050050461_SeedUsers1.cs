namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3633dac4-7e41-4e93-a2aa-280ce0bf3afb', N'admin@vidly.com', 0, N'ABRemkxlJMxZh9SLMNNOLeZjEQ1XsfIB6Ziqgh/5deGcJdgBeg/VV6IOxFvPp3rLeg==', N'0d664786-7d0c-475c-934a-f485783e1795', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'af769c76-d230-4b10-ba69-3cef1233e3e2', N'guest@vidly.com', 0, N'AN7AH6niBEDT8xpPqCTEBvs/5WvrjHGLHsmT3Tgb1UyL0SA4d6ga99l0nTh2yIeVUA==', N'9cb4bb6c-c64c-4db4-8992-22588a0bb752', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'df696c9b-fa26-4f46-b2b1-ad753ea50361', N'CanManageMovies')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3633dac4-7e41-4e93-a2aa-280ce0bf3afb', N'df696c9b-fa26-4f46-b2b1-ad753ea50361')");
        }
        
        public override void Down()
        {
        }
    }
}
