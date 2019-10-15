namespace MVCexample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteGenrefromTableName : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String());
        }
    }
}
