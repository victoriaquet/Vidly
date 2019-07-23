namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class try_2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropPrimaryKey("dbo.MembershipTypes");
            AddColumn("dbo.MembershipTypes", "MembershipTypeId", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.MembershipTypes", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "MembershipTypeId", cascadeDelete: true);
            DropColumn("dbo.MembershipTypes", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "Id", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropPrimaryKey("dbo.MembershipTypes");
            DropColumn("dbo.MembershipTypes", "MembershipTypeId");
            AddPrimaryKey("dbo.MembershipTypes", "Id");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
    }
}
