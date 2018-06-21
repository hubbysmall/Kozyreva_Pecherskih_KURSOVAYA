namespace STOshopService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class REport_step2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "TotalSum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "TotalSum", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
