namespace StajProjesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Proje", "Projeid", "dbo.Users");
            DropIndex("dbo.Proje", new[] { "Projeid" });
            AddColumn("dbo.Proje", "Users_Userid", c => c.Int());
            CreateIndex("dbo.Proje", "Users_Userid");
            AddForeignKey("dbo.Proje", "Users_Userid", "dbo.Users", "Userid");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proje", "Users_Userid", "dbo.Users");
            DropIndex("dbo.Proje", new[] { "Users_Userid" });
            DropColumn("dbo.Proje", "Users_Userid");
            CreateIndex("dbo.Proje", "Projeid");
            AddForeignKey("dbo.Proje", "Projeid", "dbo.Users", "Userid");
        }
    }
}
