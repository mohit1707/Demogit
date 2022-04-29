using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mStockAPI.DTOs
{
    public class WatchListRequest
    {
        public int UserId { get; set; }
        public int CompanyCode { get; set; }
    }
}