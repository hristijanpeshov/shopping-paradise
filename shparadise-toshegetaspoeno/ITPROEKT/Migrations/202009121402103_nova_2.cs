namespace ITPROEKT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nova_2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FinalOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Info = c.DateTime(nullable: false),
                        TotalAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "FinalOrder_Id", c => c.Int());
            CreateIndex("dbo.Products", "FinalOrder_Id");
            AddForeignKey("dbo.Products", "FinalOrder_Id", "dbo.FinalOrders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "FinalOrder_Id", "dbo.FinalOrders");
            DropIndex("dbo.Products", new[] { "FinalOrder_Id" });
            DropColumn("dbo.Products", "FinalOrder_Id");
            DropTable("dbo.FinalOrders");
        }
    }
}
