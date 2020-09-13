namespace ITPROEKT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class last : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "ProductId" });
            AddColumn("dbo.Orders", "productInfo_Name", c => c.String());
            AddColumn("dbo.Orders", "productInfo_URL", c => c.String());
            AddColumn("dbo.Orders", "productInfo_Price", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "productInfo_Price");
            DropColumn("dbo.Orders", "productInfo_URL");
            DropColumn("dbo.Orders", "productInfo_Name");
            CreateIndex("dbo.Orders", "ProductId");
            AddForeignKey("dbo.Orders", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
