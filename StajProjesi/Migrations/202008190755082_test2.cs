namespace StajProjesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Users", name: "userproje_Projeid", newName: "Projeid");
            RenameIndex(table: "dbo.Users", name: "IX_userproje_Projeid", newName: "IX_Projeid");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Users", name: "IX_Projeid", newName: "IX_userproje_Projeid");
            RenameColumn(table: "dbo.Users", name: "Projeid", newName: "userproje_Projeid");
        }
    }
}
