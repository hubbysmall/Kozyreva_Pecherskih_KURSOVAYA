namespace STOshopService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuyLimited : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Buys", "ExecutorId", "dbo.Executors");
            DropIndex("dbo.Buys", new[] { "ExecutorId" });
            DropColumn("dbo.Buys", "ExecutorId");
            DropColumn("dbo.Buys", "Status");
            DropColumn("dbo.Buys", "DateExecute");
            DropTable("dbo.Executors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Executors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExecutorFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Buys", "DateExecute", c => c.DateTime());
            AddColumn("dbo.Buys", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Buys", "ExecutorId", c => c.Int());
            CreateIndex("dbo.Buys", "ExecutorId");
            AddForeignKey("dbo.Buys", "ExecutorId", "dbo.Executors", "Id");
        }
    }
}
