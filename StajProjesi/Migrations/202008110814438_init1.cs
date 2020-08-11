namespace StajProjesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        Taskid = c.Int(nullable: false, identity: true),
                        TaskBaslik = c.String(),
                        TaskAciklama = c.String(),
                        TaskTeslimTarihi = c.DateTime(nullable: false),
                        users_Userid = c.Int(),
                    })
                .PrimaryKey(t => t.Taskid)
                .ForeignKey("dbo.Users", t => t.users_Userid)
                .Index(t => t.users_Userid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "users_Userid", "dbo.Users");
            DropIndex("dbo.Task", new[] { "users_Userid" });
            DropTable("dbo.Task");
        }
    }
}
