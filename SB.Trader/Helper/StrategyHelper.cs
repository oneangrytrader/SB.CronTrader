using SB.Trader.Model;
using SB.Trader.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SB.Trader.Helper
{
    public class StrategyHelper
    {
        private readonly Rules _rules;
        private readonly List<Candle> _data;
        private readonly List<Position> _positions;

        public StrategyHelper(Rules rules, List<Candle> data)
        {
            _rules = rules;
            _data = data;
            _positions = new List<Position>();
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
                        HandleEntryRule(rule, candle);
                        break;
                    }
                case RuleType.UPDATE:
                    {
                        HandleUpdateRule(rule, candle);
                        break;
                    }
            }
        }
        private void HandleUpdateRule(Rule rule, Candle candle)
        {
            throw new NotImplementedException();
        }
        private void HandleEntryRule(Rule rule, Candle candle)
        {
            switch (rule.Strategy)
            {
                case StrategyType.ENTER_AT_LEVEL:
                    {
                        break;
                    }
                case StrategyType.ENTER_AT_DATE:
                    {
                        HandleEnterAtDate(rule, candle);
                        break;
                    }
            }
        }
        private void HandleEnterAtDate(Rule rule, Candle candle)
        {
            switch (rule.Frequency)
            {
                case Frequency.SINGLE:
                    {
                        if (!_positions.Any(x => x.EntryDate == rule.Date) && candle.Date == rule.Date)
                        {
                            OpenPosition(rule, candle);
                        }
                        break;
                    }
                case Frequency.MULTIPLE:
                    {
                        if (candle.Date == rule.Date)
                        {
                            OpenPosition(rule, candle);
                        }
                        break;
                    }
            }
        }
        private void OpenPosition(Rule rule, Candle candle)
        {
            throw new NotImplementedException();
        }
    }
}
