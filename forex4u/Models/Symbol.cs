using System;
using System.Collections.Generic;
using System.Text;

namespace FX.Core.Entities
{
    public class Symbol
    {
        public int SymbolId { get; set; }
        public string SymFullName { get; set; }
        public string SymAbbrName { get; set; }
        public SymbolGroup SymbolGroup { get; set; }
        public ICollection<UserSymbol> UserSymbols { get; set; }
        public ICollection<Forcast> Forcasts { get; set; }
    }
}
