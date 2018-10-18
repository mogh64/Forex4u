using FX.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forex4u.Models
{
    public class StockUser
    {
        public int StockUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public int State { get; set; }
        public string WebPassword { get; set; }
        public ICollection<Credit> Credits { get; set; }
        public ICollection<UserSymbol> UserSymbols { get; set; }
    }
}
