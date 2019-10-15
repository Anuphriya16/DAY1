namespace MVCexample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionogMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MembershipTypeID", c => c.Int(nullable: true));
            CreateIndex("dbo.Customers", "MembershipTypeID");
            AddForeignKey("dbo.Customers", "MembershipTypeID", "dbo.MembershipTypes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeID", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeID" });
            DropColumn("dbo.Customers", "MembershipTypeID");
        }
    }
}
