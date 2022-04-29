namespace mStockAPI.Migrations
{
    using mStockAPI.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<mStockAPI.Models.mStockContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(mStockAPI.Models.mStockContext context)
        {
            var jojo = new AppUser { Email = "jojo@gmail.com", Password = "Jojo@123" };

            var companies = new CompanyDetails[]
            {
                new CompanyDetails{ CompanyName="ABC", CurrentStockPrice=100, BriefDesc="An Indian IT service company since 2000"},
                new CompanyDetails{ CompanyName="XYZ", CurrentStockPrice=120, BriefDesc="US based electronics goods manufacturing company."},
                new CompanyDetails{ CompanyName="JKL", CurrentStockPrice=130, BriefDesc="A man-power supply company based out of Japan."},
            };

            var watchitem = new CompanyDetailsWatch()
            {
                Company = companies[0],
                User = jojo
            };

            var stocks = new CompanyStocks[]
            {
                new CompanyStocks{ StockPrice=100, Date=new DateTime(2021,01,01), Company=companies[0]},
                new CompanyStocks{ StockPrice=130, Date=new DateTime(2021,01,01), Company=companies[1]},
                new CompanyStocks{ StockPrice=150, Date=new DateTime(2021,01,02), Company=companies[0]},
                new CompanyStocks{ StockPrice=80, Date=new DateTime(2021,01,02), Company=companies[1]},
            };

            context.Users.AddOrUpdate(u => u.Email, jojo);
            context.Companies.AddOrUpdate(c => c.CompanyName, companies);
            context.CompanyStocks.AddOrUpdate(s => s.Date, stocks);
            context.WatchList.AddOrUpdate(w => w.CompanyCode, watchitem);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
