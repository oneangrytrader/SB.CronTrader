using SB.Trader.Model;
using SB.Trader.Model.Enum;
using System;
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
            foreach(var candle in _data)
            {
                RunRulesOnCandle(candle);
            }
        }
        private void RunRulesOnCandle(Candle candle)
        {
            foreach(var rule in _rules.Items)
            {
                RunSingleRule(rule, candle);
            }
        }
        private void RunSingleRule(Rule rule, Candle candle)
        {
            switch (rule.RuleType)
            {
                case RuleType.ENTRY:
                    {
                        break;
                    }
                case RuleType.EXIT:
                    {
                        break;
                    }
            }
        }
    }
}
