using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mStockAPI.DTOs
{
    public class StocksResponse
    {
        public DateTime Date { get; set; }
        public string CompanyName { get; set; }
        public int StockPrice { get; set; }
    }
}