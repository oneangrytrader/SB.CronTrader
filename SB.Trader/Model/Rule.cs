﻿using Newtonsoft.Json;
using SB.Trader.Model.Enum;
using System.Collections.Generic;

namespace SB.Trader.Model
{
    public class Rule
    {
        [JsonProperty("ruleType")]
        public RuleType RuleType;

        [JsonProperty("strategy")]
        public StrategyType Strategy;

        [JsonProperty("level")]
        public int Level;

        [JsonProperty("direction")]
        public Direction Direction;

        [JsonProperty("stop")]
        public int Stop;

        [JsonProperty("frequency")]
        public int Frequency;
    }

    public class Rules
    {
        [JsonProperty("Rules")]
        public List<Rule> Items;
    }
}