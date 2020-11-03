using SB.Trader.Model;
using SB.Trader.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace SB.Trader.Helper
{
    public class StrategyHelper
    {
        private readonly Rules _rules;
        private readonly List<Candle> _data;
        public List<Position> Positions;

        public StrategyHelper(Rules rules, List<Candle> data)
        {
            _rules = rules;
            _data = data;
            Positions = new List<Position>();
        }
        public void RunRules()
        {
            foreach(var candle in _data)
            {
                UpdatePositions(candle);
                RunRulesOnCandle(candle);
                CloseStoppedPositions(candle);
                CloseLimitReachedPositions(candle);
            }
        }

        private void UpdatePositions(Candle candle)
        {
            Positions.ForEach(position =>
            {
                position.Level = candle.Close;
            });
        }

        private void CloseLimitReachedPositions(Candle candle)
        {
            Positions.Where(x => x.PositionStatus == PositionStatus.OPEN && x.Limit != null).ToList().ForEach(position =>
             {
                 if (
                 (position.Level >= position.Limit && position.Direction == Direction.BUY) ||
                 (position.Level <= position.Limit && position.Direction == Direction.SELL)
                 )
                 {
                     position.ExitLevel = position.Level;
                     position.PositionStatus = PositionStatus.LIMIT_REACHED;
                     position.ExitDate = candle.Date;
                 }
             });
        }
        private void CloseStoppedPositions(Candle candle)
        {
            Positions.Where(x => x.PositionStatus == PositionStatus.OPEN && x.Stop != null).ToList().ForEach(position =>
            {
                if (
                (position.Level <= position.Stop && position.Direction == Direction.BUY) ||
                (position.Level >= position.Stop && position.Direction == Direction.SELL)
                )
                {
                    position.ExitLevel = position.Level;
                    position.PositionStatus = PositionStatus.STOP_REACHED;
                    position.ExitDate = candle.Date;
                }
            });
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
                        if (
                            !Positions.Any(x => x.EntryDate.ToShortDateString() == rule.Date.ToShortDateString()) && 
                            candle.Date.ToShortDateString() == rule.Date.ToShortDateString())
                        {
                            OpenPosition(rule, candle);
                        }
                        break;
                    }
                case Frequency.MULTIPLE:
                    {
                        if (candle.Date.ToShortDateString() == rule.Date.ToShortDateString())
                        {
                            OpenPosition(rule, candle);
                        }
                        break;
                    }
            }
        }
        private void OpenPosition(Rule rule, Candle candle)
        {
            var level = rule.Direction == Direction.BUY ? candle.Close - rule.Spread : candle.Close + rule.Spread;
            Positions.Add(new Position
            {
                EntryDate = candle.Date,
                EntryLevel = level,
                Level = level,
                Stop = GetStop(rule, candle),
                Limit = GetLimit(rule, candle),
                PositionStatus = PositionStatus.OPEN,
                Direction = rule.Direction
            });
        }
        private double? GetLimit(Rule rule, Candle candle)
        {
            double? limit = null;
            if (rule.Limit != null)
            {
                limit = rule.Direction == Direction.BUY ? candle.Close + rule.Limit : candle.Close - rule.Limit;
            }
            return limit;
        }
        private double? GetStop(Rule rule, Candle candle)
        {
            double? stop = null;
            if (rule.Stop != null)
            {
                stop = rule.Direction == Direction.BUY ? candle.Close - rule.Stop : candle.Close + rule.Stop;
            }
            return stop;
        }
    }
}
