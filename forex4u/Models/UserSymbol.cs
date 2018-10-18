using forex4u.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FX.Core.Entities
{
    public class UserSymbol
    {      
        public int UserId { get; set; }    
        public StockUser StockUser { get; set; }
        public int SymbolId { get; set; }
        public Symbol Symbol { get; set; }
    }
}
