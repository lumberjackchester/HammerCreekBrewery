namespace HammerCreekBrewing.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HCBDataBaseMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beers",
                c => new
                    {
                        BeerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        StyleId = c.Int(nullable: false),
                        TapName = c.String(),
                        LocationId = c.Int(nullable: false),
                        BrewDate = c.DateTime(nullable: false),
                        KeggedDate = c.DateTime(),
                        TappedDate = c.DateTime(),
                        Abv = c.Decimal(nullable: false, precision: 18, scale: 2),
                        KegId = c.Int(),
                        OnTap = c.Boolean(nullable: false),
                        BreweryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BeerId)
                .ForeignKey("dbo.Breweries", t => t.BreweryId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.BeerStyles", t => t.StyleId, cascadeDelete: true)
                .Index(t => t.BreweryId)
                .Index(t => t.LocationId)
                .Index(t => t.StyleId);
            
            CreateTable(
                "dbo.Breweries",
                c => new
                    {
                        BreweryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BreweryId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "dbo.BeerStyles",
                c => new
                    {
                        BeerStyleId = c.Int(nullable: false, identity: true),
                        StyleName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BeerStyleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Beers", "StyleId", "dbo.BeerStyles");
            DropForeignKey("dbo.Beers", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Beers", "BreweryId", "dbo.Breweries");
            DropIndex("dbo.Beers", new[] { "StyleId" });
            DropIndex("dbo.Beers", new[] { "LocationId" });
            DropIndex("dbo.Beers", new[] { "BreweryId" });
            DropTable("dbo.BeerStyles");
            DropTable("dbo.Locations");
            DropTable("dbo.Breweries");
            DropTable("dbo.Beers");
        }
    }
}
