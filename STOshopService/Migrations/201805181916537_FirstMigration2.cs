namespace STOshopService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Serves", "MyPriceAndParts", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Serves", "MyPriceAndParts");
        }
    }
}
