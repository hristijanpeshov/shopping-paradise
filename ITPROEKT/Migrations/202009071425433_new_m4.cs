namespace ITPROEKT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_m4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        SellerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.Int(nullable: false),
                        Country = c.String(),
                        Vision = c.String(),
                    })
                .PrimaryKey(t => t.SellerId);
            
            AddColumn("dbo.Products", "SellerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "SellerId");
            AddForeignKey("dbo.Products", "SellerId", "dbo.Sellers", "SellerId", cascadeDelete: true);
            DropColumn("dbo.Products", "Seller");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Seller", c => c.String());
            DropForeignKey("dbo.Products", "SellerId", "dbo.Sellers");
            DropIndex("dbo.Products", new[] { "SellerId" });
            DropColumn("dbo.Products", "SellerId");
            DropTable("dbo.Sellers");
        }
    }
}
