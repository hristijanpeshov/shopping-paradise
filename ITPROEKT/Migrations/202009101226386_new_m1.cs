namespace ITPROEKT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_m1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Color", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Color");
        }
    }
}
