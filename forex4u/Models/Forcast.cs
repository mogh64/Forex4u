using System;
using System.Collections.Generic;
using System.Text;

namespace FX.Core.Entities
{
    public class Forcast
    {
        public int ForcastId { get; set; }
        public DateTime Date { get; set; }
        public int Type { get; set; }
        public decimal EntryPoint { get; set; }
        public decimal TargetPoint { get; set; }
        public decimal StopPoint { get; set; }
        public float VolPercent { get; set; }
        public int Period { get; set; }
        public int SymbolId { get; set; }
        public Symbol Symbol { get; set; }
    }
}
