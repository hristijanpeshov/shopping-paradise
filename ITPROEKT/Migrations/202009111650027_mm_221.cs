namespace ITPROEKT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mm_221 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FinalOrders", "IdentityUser", c => c.Int(nullable: false));
            DropColumn("dbo.FinalOrders", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FinalOrders", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.FinalOrders", "IdentityUser");
        }
    }
}
