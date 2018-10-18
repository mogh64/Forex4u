using System;
using System.Collections.Generic;
using System.Text;

namespace FX.Core.Entities
{
    public class SymbolGroup
    {
        public int SymbolGroupId { get; set; }
        public string GroupName { get; set; }
        public ICollection<Symbol> Symbols { get; set; }
    }
}
