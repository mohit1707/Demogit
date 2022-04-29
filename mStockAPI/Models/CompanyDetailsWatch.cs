using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mStockAPI.Models
{
    [Table("CompaniesWatchList")]
    public class CompanyDetailsWatch
    {
        public int Id { get; set; }

        [ForeignKey("Company")]
        public int CompanyCode { get; set; }
        public CompanyDetails Company { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public AppUser User { get; set; }
    }
}