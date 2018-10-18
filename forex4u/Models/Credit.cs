using forex4u.Models;
using FX.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace FX.Core.Entities
{
    public class Credit
    {
        public int CreditId { get; set; }
        public CreditType CreditType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsActive { get; set; }
        public StockUser StockUser { get; set; }
    }
}
