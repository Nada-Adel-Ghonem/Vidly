namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'79366def-71d3-4a9e-9edb-135a616c56a8', N'nadaadel24657@gmail.com', 0, N'AMLOO5p+i6BwmWwc8aVLnaF7abY8V/QHxPGY2JHKgwIqVZsDSphW+hGaQetaHzzTIA==', N'73b43427-a788-4a51-839e-796035a9630e', NULL, 0, 0, NULL, 1, 0, N'nadaadel24657@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b9b922b2-50d4-46fa-b94c-7e163f981c33', N'admin@vidly.com', 0, N'AOsv5KlAbxq4dwK48/Sl6FzyRDsklUjAFqkS3p/Mj0/Nr5qwW2pIBhboR6qTlDF2jQ==', N'9c8b433e-308b-4fc9-89c5-5d48ed9b55fc', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
              
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'65125295-7e6d-4e08-baa4-030a15719e52', N'canManageMovies')
                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b9b922b2-50d4-46fa-b94c-7e163f981c33', N'65125295-7e6d-4e08-baa4-030a15719e52')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
