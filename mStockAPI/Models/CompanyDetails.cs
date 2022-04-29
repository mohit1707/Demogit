using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mStockAPI.Models
{
    [Table("Companies")]
    public class CompanyDetails
    {
        [Key]
        public int CompanyCode { get; set; }

        [Required, StringLength(50)]
        public string CompanyName { get; set; }

        [Required, StringLength(200)]
        public string BriefDesc { get; set; }

        public int CurrentStockPrice { get; set; }
    }
}