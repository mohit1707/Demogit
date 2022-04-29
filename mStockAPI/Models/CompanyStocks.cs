using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mStockAPI.Models
{
    [Table("CompanyStocks")]
    public class CompanyStocks
    {
        public int Id { get; set; }

        [Column(TypeName ="date")]
        public DateTime Date { get; set; }

        public int StockPrice { get; set; }

        [ForeignKey("Company")]
        public int CompanyCode { get; set; }
        public CompanyDetails Company { get; set; }

    }
}