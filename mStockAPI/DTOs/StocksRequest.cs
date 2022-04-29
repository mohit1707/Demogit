using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mStockAPI.DTOs
{
    public class StocksRequest
    {
        public int CompanyCode1 { get; set; }

        public int CompanyCode2 { get; set; }

        public DateTime FromDate { get; set; }
        
        public DateTime ToDate { get; set; }

    }
}