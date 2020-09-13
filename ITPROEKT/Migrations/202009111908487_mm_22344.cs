namespace ITPROEKT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mm_22344 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "FinalOrder_Id", "dbo.FinalOrders");
            DropIndex("dbo.Orders", new[] { "FinalOrder_Id" });
            DropColumn("dbo.Orders", "FinalOrder_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "FinalOrder_Id", c => c.Int());
            CreateIndex("dbo.Orders", "FinalOrder_Id");
            AddForeignKey("dbo.Orders", "FinalOrder_Id", "dbo.FinalOrders", "Id");
        }
    }
}
