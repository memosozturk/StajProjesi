namespace StajProjesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adminekleme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        Adminid = c.Int(nullable: false, identity: true),
                        Eposta = c.String(nullable: false),
                        Sifre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Adminid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admin");
        }
    }
}
