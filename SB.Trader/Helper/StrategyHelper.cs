﻿using SB.Trader.Model;
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
                RunRulesOnCandle(candle);
                CloseStoppedPositions(candle);
                CloseLimitReachedPositions(candle);
            }
        }
        private void CloseLimitReachedPositions(Candle candle)
        {
            Positions.Where(x => x.PositionStatus == PositionStatus.OPEN).ToList().ForEach(position =>
             {
                 if (candle.Close >= position.Limit)
                 {
                     position.Level = candle.Close;
                     position.ExitLevel = candle.Close;
                     position.PositionStatus = PositionStatus.LIMIT_REACHED;
                     position.ExitDate = candle.Date;
                 }
             });
        }
        private void CloseStoppedPositions(Candle candle)
        {
            Positions.Where(x => x.PositionStatus == PositionStatus.OPEN).ToList().ForEach(position =>
            {
                if (position.Level <= position.Stop)
                {
                    position.Level = candle.Close;
                    position.ExitLevel = candle.Close;
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
            Positions.Add(new Position
            {
                EntryDate = candle.Date,
                EntryLevel = candle.Close,
                Level = candle.Close,
                Stop = rule.Stop != null ? candle.Close - rule.Stop : null,
                Limit = rule.Limit != null ? candle.Close + rule.Limit : null,
                PositionStatus = PositionStatus.OPEN,
                Direction = rule.Direction
            });
        }
    }
}
