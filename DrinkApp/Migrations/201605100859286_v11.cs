namespace DrinkApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drinks", "DrinkType", c => c.String());
            AddColumn("dbo.Drinks", "Complexity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drinks", "Complexity");
            DropColumn("dbo.Drinks", "DrinkType");
        }
    }
}
