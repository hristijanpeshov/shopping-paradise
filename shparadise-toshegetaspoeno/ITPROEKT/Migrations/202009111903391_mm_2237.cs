namespace ITPROEKT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mm_2237 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "FinalOrderId", "dbo.FinalOrders");
            DropIndex("dbo.Orders", new[] { "FinalOrderId" });
            RenameColumn(table: "dbo.Orders", name: "FinalOrderId", newName: "FinalOrder_Id");
            AlterColumn("dbo.Orders", "FinalOrder_Id", c => c.Int());
            CreateIndex("dbo.Orders", "FinalOrder_Id");
            AddForeignKey("dbo.Orders", "FinalOrder_Id", "dbo.FinalOrders", "Id");
            DropColumn("dbo.FinalOrders", "IdentityUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FinalOrders", "IdentityUser", c => c.String());
            DropForeignKey("dbo.Orders", "FinalOrder_Id", "dbo.FinalOrders");
            DropIndex("dbo.Orders", new[] { "FinalOrder_Id" });
            AlterColumn("dbo.Orders", "FinalOrder_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Orders", name: "FinalOrder_Id", newName: "FinalOrderId");
            CreateIndex("dbo.Orders", "FinalOrderId");
            AddForeignKey("dbo.Orders", "FinalOrderId", "dbo.FinalOrders", "Id", cascadeDelete: true);
        }
    }
}
