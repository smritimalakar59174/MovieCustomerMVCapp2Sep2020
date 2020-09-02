namespace MovieCustomerWithAuthMVC_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class expmigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "MovieName", c => c.String(nullable: false, maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "MovieName", c => c.String(nullable: false));
        }
    }
}
