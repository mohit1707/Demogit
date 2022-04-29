namespace mStockAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyCode = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 50),
                        BriefDesc = c.String(nullable: false, maxLength: 200),
                        CurrentStockPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyCode);
            
            CreateTable(
                "dbo.CompanyStocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        StockPrice = c.Int(nullable: false),
                        CompanyCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyCode, cascadeDelete: true)
                .Index(t => t.CompanyCode);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.CompaniesWatchList",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyCode = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyCode, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CompanyCode)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompaniesWatchList", "UserId", "dbo.Users");
            DropForeignKey("dbo.CompaniesWatchList", "CompanyCode", "dbo.Companies");
            DropForeignKey("dbo.CompanyStocks", "CompanyCode", "dbo.Companies");
            DropIndex("dbo.CompaniesWatchList", new[] { "UserId" });
            DropIndex("dbo.CompaniesWatchList", new[] { "CompanyCode" });
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.CompanyStocks", new[] { "CompanyCode" });
            DropTable("dbo.CompaniesWatchList");
            DropTable("dbo.Users");
            DropTable("dbo.CompanyStocks");
            DropTable("dbo.Companies");
        }
    }
}
