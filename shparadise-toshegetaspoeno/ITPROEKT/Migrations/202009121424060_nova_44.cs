namespace ITPROEKT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nova_44 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FinalOrders", "IdentityUser", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FinalOrders", "IdentityUser");
        }
    }
}
