namespace MVCexample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertDetailsStocks : DbMigration
    {
        public override void Up()
        {
            Sql("Update Movies set AvailableStock=10 where ID=2");
            Sql("Update Movies set AvailableStock=15 where ID=5");
        }
        
        public override void Down()
        {
        }
    }
}
