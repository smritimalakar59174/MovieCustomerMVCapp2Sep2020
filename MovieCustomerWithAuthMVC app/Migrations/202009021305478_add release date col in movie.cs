namespace MovieCustomerWithAuthMVC_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addreleasedatecolinmovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
