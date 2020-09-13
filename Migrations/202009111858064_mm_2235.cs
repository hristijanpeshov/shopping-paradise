namespace ITPROEKT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mm_2235 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "FinalOrder_Id", "dbo.FinalOrders");
            DropIndex("dbo.Orders", new[] { "FinalOrder_Id" });
            RenameColumn(table: "dbo.Orders", name: "FinalOrder_Id", newName: "FinalOrderId");
            AlterColumn("dbo.Orders", "FinalOrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "FinalOrderId");
            AddForeignKey("dbo.Orders", "FinalOrderId", "dbo.FinalOrders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "FinalOrderId", "dbo.FinalOrders");
            DropIndex("dbo.Orders", new[] { "FinalOrderId" });
            AlterColumn("dbo.Orders", "FinalOrderId", c => c.Int());
            RenameColumn(table: "dbo.Orders", name: "FinalOrderId", newName: "FinalOrder_Id");
            CreateIndex("dbo.Orders", "FinalOrder_Id");
            AddForeignKey("dbo.Orders", "FinalOrder_Id", "dbo.FinalOrders", "Id");
        }
    }
}
