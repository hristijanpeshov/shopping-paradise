namespace ITPROEKT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mm_2232 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FinalOrders", "IdentityUser", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FinalOrders", "IdentityUser", c => c.Int(nullable: false));
        }
    }
}
