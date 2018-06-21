namespace STOshopService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class admin1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdminMail = c.String(nullable: false),
                        AdminName = c.String(nullable: false),
                        AdminPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admins");
        }
    }
}
