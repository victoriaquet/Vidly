namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeddUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9fb529ca-ca85-4fbf-b477-6352fff369dd', N'vicky@mosh.com', 0, N'ALV7Zg8eXH4spea+C6+1IiSL+gyMH6L05mCMP4IY3dxpRVmB6rmw+6ndJ6FgrWAb4w==', N'61e43c40-07e0-46ec-aabd-e129cf862ac0', NULL, 0, 0, NULL, 1, 0, N'vicky@mosh.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bafba3f3-5957-44c8-9cc6-fca143899675', N'invitado@mosh.com', 0, N'AKGOluleK96t0JQ0cMlGIO2qUYwGwp5u4En216xXGf3ith84cKO3g3g7D+nVyaO1wQ==', N'5ca46415-b9aa-4ed1-ab2d-541a2582c683', NULL, 0, 0, NULL, 1, 0, N'invitado@mosh.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c2cd1fb7-2a9a-4e04-804b-ea67feec59cc', N'admin@mosh.com', 0, N'AD1fBIXORDJTI13S8MKF0vCXDzZOdNbrEk7/Jjkg2IKGZtfNh89SZ8hEh9VzHxj5qQ==', N'ba41103c-d09e-4c81-9872-4d7d6ebd6746', NULL, 0, 0, NULL, 1, 0, N'admin@mosh.com')
               
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'571cf839-17c5-467a-9c1d-969cfc99bb77', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c2cd1fb7-2a9a-4e04-804b-ea67feec59cc', N'571cf839-17c5-467a-9c1d-969cfc99bb77')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
