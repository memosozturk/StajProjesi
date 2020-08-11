namespace StajProjesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Task", "proje_Projeid", c => c.Int());
            CreateIndex("dbo.Task", "proje_Projeid");
            AddForeignKey("dbo.Task", "proje_Projeid", "dbo.Proje", "Projeid");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "proje_Projeid", "dbo.Proje");
            DropIndex("dbo.Task", new[] { "proje_Projeid" });
            DropColumn("dbo.Task", "proje_Projeid");
        }
    }
}
