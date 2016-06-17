namespace DrinkApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DrinkRecipes",
                c => new
                    {
                        DrinkRecipeID = c.Int(nullable: false, identity: true),
                        Amount = c.String(),
                        Order = c.String(),
                        IngredientID = c.Int(nullable: false),
                        DrinkID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DrinkRecipeID)
                .ForeignKey("dbo.Drinks", t => t.DrinkID, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.IngredientID, cascadeDelete: true)
                .Index(t => t.IngredientID)
                .Index(t => t.DrinkID);
            
            CreateTable(
                "dbo.Drinks",
                c => new
                    {
                        DrinkID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DrinkTaste = c.String(),
                        DrinkType = c.String(),
                        Complexity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DrinkID);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        IngredientID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.IngredientID);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        LikeID = c.Int(nullable: false, identity: true),
                        PersonID = c.Int(nullable: false),
                        DrinkID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LikeID)
                .ForeignKey("dbo.Drinks", t => t.DrinkID, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .Index(t => t.PersonID)
                .Index(t => t.DrinkID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.PersonID);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        LoginID = c.Int(nullable: false, identity: true),
                        Account = c.String(),
                        Password = c.String(),
                        PersonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LoginID)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .Index(t => t.PersonID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logins", "PersonID", "dbo.People");
            DropForeignKey("dbo.Likes", "PersonID", "dbo.People");
            DropForeignKey("dbo.Likes", "DrinkID", "dbo.Drinks");
            DropForeignKey("dbo.DrinkRecipes", "IngredientID", "dbo.Ingredients");
            DropForeignKey("dbo.DrinkRecipes", "DrinkID", "dbo.Drinks");
            DropIndex("dbo.Logins", new[] { "PersonID" });
            DropIndex("dbo.Likes", new[] { "DrinkID" });
            DropIndex("dbo.Likes", new[] { "PersonID" });
            DropIndex("dbo.DrinkRecipes", new[] { "DrinkID" });
            DropIndex("dbo.DrinkRecipes", new[] { "IngredientID" });
            DropTable("dbo.Logins");
            DropTable("dbo.People");
            DropTable("dbo.Likes");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Drinks");
            DropTable("dbo.DrinkRecipes");
        }
    }
}
