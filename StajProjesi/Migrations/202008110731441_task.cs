namespace StajProjesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class task : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserAd", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserAd");
        }
    }
}
