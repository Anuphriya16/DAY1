namespace MVCexample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PpulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Insert MembershipTypes(Type,Duration,SignupFee,Discount)values('yearly',12,1200,20)");
            Sql("Insert MembershipTypes(Type,Duration,SignupFee,Discount)values('Helf-yearly',5,500,10)");
            Sql("Insert MembershipTypes(Type,Duration,SignupFee,Discount)values('Quarterly',2,200,15)");
        }
        
        public override void Down()
        {
        }
    }
}
