namespace StajProjesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserAd", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserAd", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
