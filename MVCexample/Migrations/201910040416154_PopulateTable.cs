namespace MVCexample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Genres(Name)values('Action')");
            Sql("Insert Genres(Name)values('Comedy')");
            Sql("Insert Genres(Name)values('Triller')");

        }
        
        public override void Down()
        {
        }
    }
}
