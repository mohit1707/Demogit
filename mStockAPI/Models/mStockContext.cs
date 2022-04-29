using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mStockAPI.Models
{
    public class mStockContext : DbContext
    {
        public mStockContext():base("mStockDbConnection")
        {

        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<CompanyDetails> Companies { get; set; }
        public DbSet<CompanyDetailsWatch> WatchList { get; set; }
        public DbSet<CompanyStocks> CompanyStocks { get; set; }
    }
}