using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mStockAPI.Models
{
    [Table("Users")]
    public class AppUser
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(50), Required, Index(IsUnique =true)]
        public string Email { get; set; }
        [StringLength(50), Required]
        public string Password { get; set; }
    }
}