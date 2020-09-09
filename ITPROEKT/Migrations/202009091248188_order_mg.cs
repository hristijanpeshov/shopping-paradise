namespace ITPROEKT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order_mg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "InStock", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "sumPaid", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "sumPaid");
            DropColumn("dbo.Products", "InStock");
        }
    }
}
