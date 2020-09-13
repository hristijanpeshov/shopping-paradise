namespace ITPROEKT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m_33257 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToDeliverOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentityUser = c.String(),
                        Info = c.DateTime(nullable: false),
                        Status = c.String(),
                        TotalAmount = c.Single(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Color = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDeliverOrders", "ProductId", "dbo.Products");
            DropIndex("dbo.ToDeliverOrders", new[] { "ProductId" });
            DropTable("dbo.ToDeliverOrders");
        }
    }
}
