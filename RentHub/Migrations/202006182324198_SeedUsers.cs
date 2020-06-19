namespace RentHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [DrivingLicense], [CellPhoneNumber], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'63831139-32f1-417a-8843-c73c28908ac4', N'12345', N'12345', N'guest@vidly.com', 0, N'AI9Lb6Om+S09/3QMEvqa6i+zXozwFJMf+PsTaLeyW61v7/hoCwLG0NyanQnQT7MUEw==', N'9ea86e32-8a9b-48e3-be23-5f7f6bcd8ecb', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [DrivingLicense], [CellPhoneNumber], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'788b6432-5b2f-481a-b565-59e3942a8425', N'12345', N'12345', N'susanbdrjoshi1@gmail.com', 0, N'AEy9ivPJsu47zr493PAHZ2RbSRZBHsi8EqTgtz7PKYCMzWLFoe47Mi/2GD46oUWseQ==', N'88e4be75-89f1-43b5-a261-0d40ba341727', NULL, 0, 0, NULL, 1, 0, N'susanbdrjoshi1@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b59056be-159b-494b-a1df-83aa97baaa51', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'788b6432-5b2f-481a-b565-59e3942a8425', N'b59056be-159b-494b-a1df-83aa97baaa51')


");
        }
        
        public override void Down()
        {
        }
    }
}
