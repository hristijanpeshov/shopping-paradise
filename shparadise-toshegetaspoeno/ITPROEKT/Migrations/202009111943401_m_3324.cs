namespace ITPROEKT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m_3324 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FinalOrders", "IdentityUser", c => c.String());
            AddColumn("dbo.FinalOrders", "Status", c => c.String());
            AddColumn("dbo.FinalOrders", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.FinalOrders", "Color", c => c.String());
            AddColumn("dbo.FinalOrders", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.FinalOrders", "ProductId");
            AddForeignKey("dbo.FinalOrders", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FinalOrders", "ProductId", "dbo.Products");
            DropIndex("dbo.FinalOrders", new[] { "ProductId" });
            DropColumn("dbo.FinalOrders", "ProductId");
            DropColumn("dbo.FinalOrders", "Color");
            DropColumn("dbo.FinalOrders", "Quantity");
            DropColumn("dbo.FinalOrders", "Status");
            DropColumn("dbo.FinalOrders", "IdentityUser");
        }
    }
}
