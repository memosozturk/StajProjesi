namespace StajProjesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Task", "proje_Projeid", "dbo.Proje");
            DropIndex("dbo.Task", new[] { "proje_Projeid" });
            RenameColumn(table: "dbo.Task", name: "proje_Projeid", newName: "Projeid");
            AlterColumn("dbo.Task", "Projeid", c => c.Int(nullable: false));
            CreateIndex("dbo.Task", "Projeid");
            AddForeignKey("dbo.Task", "Projeid", "dbo.Proje", "Projeid", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "Projeid", "dbo.Proje");
            DropIndex("dbo.Task", new[] { "Projeid" });
            AlterColumn("dbo.Task", "Projeid", c => c.Int());
            RenameColumn(table: "dbo.Task", name: "Projeid", newName: "proje_Projeid");
            CreateIndex("dbo.Task", "proje_Projeid");
            AddForeignKey("dbo.Task", "proje_Projeid", "dbo.Proje", "Projeid");
        }
    }
}
