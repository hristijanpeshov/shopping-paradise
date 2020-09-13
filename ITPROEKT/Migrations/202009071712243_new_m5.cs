namespace ITPROEKT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_m5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sellers", "URL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sellers", "URL");
        }
    }
}
