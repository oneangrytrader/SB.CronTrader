using SB.Trader.Model.Enum;
using System;

namespace SB.Trader.Model
{
    public class Position
    {
        public DateTime EntryDate { get; set; }
        public Direction Direction { get; internal set; }
        public double EntryLevel { get; internal set; }
        public double Level { get; internal set; }
        public double? Stop { get; internal set; }
        public double? Limit { get; internal set; }
        public DateTime ExitDate { get; set; }
        public double ExitLevel { get; internal set; }
        public PositionStatus PositionStatus { get; internal set; }        
    }
}