namespace ITPROEKT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mm_223 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FinalOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Info = c.DateTime(nullable: false),
                        TotalAmount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "FinalOrder_Id", c => c.Int());
            CreateIndex("dbo.Orders", "FinalOrder_Id");
            AddForeignKey("dbo.Orders", "FinalOrder_Id", "dbo.FinalOrders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "FinalOrder_Id", "dbo.FinalOrders");
            DropIndex("dbo.Orders", new[] { "FinalOrder_Id" });
            DropColumn("dbo.Orders", "FinalOrder_Id");
            DropTable("dbo.FinalOrders");
        }
    }
}
