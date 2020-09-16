namespace ITPROEKT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nova_3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "FinalOrder_Id", "dbo.FinalOrders");
            DropIndex("dbo.Products", new[] { "FinalOrder_Id" });
            AddColumn("dbo.Orders", "FinalOrder_Id", c => c.Int());
            AlterColumn("dbo.FinalOrders", "TotalAmount", c => c.Single(nullable: false));
            CreateIndex("dbo.Orders", "FinalOrder_Id");
            AddForeignKey("dbo.Orders", "FinalOrder_Id", "dbo.FinalOrders", "Id");
            DropColumn("dbo.Products", "FinalOrder_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "FinalOrder_Id", c => c.Int());
            DropForeignKey("dbo.Orders", "FinalOrder_Id", "dbo.FinalOrders");
            DropIndex("dbo.Orders", new[] { "FinalOrder_Id" });
            AlterColumn("dbo.FinalOrders", "TotalAmount", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "FinalOrder_Id");
            CreateIndex("dbo.Products", "FinalOrder_Id");
            AddForeignKey("dbo.Products", "FinalOrder_Id", "dbo.FinalOrders", "Id");
        }
    }
}
