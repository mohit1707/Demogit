using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mStockAPI.DTOs
{
    public class CompanyDetailsRespone
    {
        public int CompanyCode { get; set; }

        public string CompanyName { get; set; }

        public string BriefDesc { get; set; }

        public int CurrentStockPrice { get; set; }
    }
}