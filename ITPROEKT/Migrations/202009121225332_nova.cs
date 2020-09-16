namespace ITPROEKT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nova : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FinalOrders",
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ToDeliverOrders", "ProductId");
            CreateIndex("dbo.FinalOrders", "ProductId");
            AddForeignKey("dbo.ToDeliverOrders", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FinalOrders", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
