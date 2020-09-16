namespace ITPROEKT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_m3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "URL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "URL");
        }
    }
}
