namespace StajProjesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Task", "users_Userid", "dbo.Users");
            DropIndex("dbo.Task", new[] { "users_Userid" });
            DropColumn("dbo.Task", "users_Userid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Task", "users_Userid", c => c.Int());
            CreateIndex("dbo.Task", "users_Userid");
            AddForeignKey("dbo.Task", "users_Userid", "dbo.Users", "Userid");
        }
    }
}
