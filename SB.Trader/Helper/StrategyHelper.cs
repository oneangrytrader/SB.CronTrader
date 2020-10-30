using SB.Trader.Model;
using System.Collections.Generic;

namespace SB.Trader.Helper
{
    public class StrategyHelper
    {
        private readonly Rules _rules;
        private readonly List<Candle> _data;

        public StrategyHelper(Rules rules, List<Candle> data)
        {
            _rules = rules;
            _data = data;
        }
        public void RunRules()
        {

        }
    }
}
