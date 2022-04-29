using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mStockAPI.DTOs
{
    public class LoginResponse
    {
        public int UserId { get; set; }
        public string Email { get; set; }
    }
}