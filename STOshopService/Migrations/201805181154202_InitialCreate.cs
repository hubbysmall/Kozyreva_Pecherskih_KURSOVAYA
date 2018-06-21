namespace STOshopService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        ExecutorId = c.Int(),
                        TotalCount = c.Int(nullable: false),
                        TotalSum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        DateExecute = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Executors", t => t.ExecutorId)
                .Index(t => t.ClientId)
                .Index(t => t.ExecutorId);
            
            CreateTable(
                "dbo.Buy_Serve",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServeId = c.Int(nullable: false),
                        BuyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buys", t => t.BuyId, cascadeDelete: true)
                .ForeignKey("dbo.Serves", t => t.ServeId, cascadeDelete: true)
                .Index(t => t.ServeId)
                .Index(t => t.BuyId);
            
            CreateTable(
                "dbo.Serves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServeName = c.String(nullable: false),
                        ServePrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Serve_Part",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServeId = c.Int(nullable: false),
                        PartId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parts", t => t.PartId, cascadeDelete: true)
                .ForeignKey("dbo.Serves", t => t.ServeId, cascadeDelete: true)
                .Index(t => t.ServeId)
                .Index(t => t.PartId);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartName = c.String(nullable: false),
                        PartPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Hall_Part",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HallId = c.Int(nullable: false),
                        PartId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Halls", t => t.HallId, cascadeDelete: true)
                .ForeignKey("dbo.Parts", t => t.PartId, cascadeDelete: true)
                .Index(t => t.HallId)
                .Index(t => t.PartId);
            
            CreateTable(
                "dbo.Halls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HallName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Order_Part",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        PartId = c.Int(nullable: false),
                        HallId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Parts", t => t.PartId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.PartId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdminId = c.Int(nullable: false),
                        AdminName = c.String(),
                        TotalCount = c.Int(nullable: false),
                        TotalSum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateCreate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientFIO = c.String(nullable: false),
                        ClientMail = c.String(nullable: false),
                        ClientPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Executors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExecutorFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Buys", "ExecutorId", "dbo.Executors");
            DropForeignKey("dbo.Buys", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Buy_Serve", "ServeId", "dbo.Serves");
            DropForeignKey("dbo.Serve_Part", "ServeId", "dbo.Serves");
            DropForeignKey("dbo.Serve_Part", "PartId", "dbo.Parts");
            DropForeignKey("dbo.Order_Part", "PartId", "dbo.Parts");
            DropForeignKey("dbo.Order_Part", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Hall_Part", "PartId", "dbo.Parts");
            DropForeignKey("dbo.Hall_Part", "HallId", "dbo.Halls");
            DropForeignKey("dbo.Buy_Serve", "BuyId", "dbo.Buys");
            DropIndex("dbo.Order_Part", new[] { "PartId" });
            DropIndex("dbo.Order_Part", new[] { "OrderId" });
            DropIndex("dbo.Hall_Part", new[] { "PartId" });
            DropIndex("dbo.Hall_Part", new[] { "HallId" });
            DropIndex("dbo.Serve_Part", new[] { "PartId" });
            DropIndex("dbo.Serve_Part", new[] { "ServeId" });
            DropIndex("dbo.Buy_Serve", new[] { "BuyId" });
            DropIndex("dbo.Buy_Serve", new[] { "ServeId" });
            DropIndex("dbo.Buys", new[] { "ExecutorId" });
            DropIndex("dbo.Buys", new[] { "ClientId" });
            DropTable("dbo.Executors");
            DropTable("dbo.Clients");
            DropTable("dbo.Orders");
            DropTable("dbo.Order_Part");
            DropTable("dbo.Halls");
            DropTable("dbo.Hall_Part");
            DropTable("dbo.Parts");
            DropTable("dbo.Serve_Part");
            DropTable("dbo.Serves");
            DropTable("dbo.Buy_Serve");
            DropTable("dbo.Buys");
        }
    }
}
