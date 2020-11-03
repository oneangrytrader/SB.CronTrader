using Newtonsoft.Json;
using SB.Trader.Converter;
using SB.Trader.Model.Enum;
using System;
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
        public double? Stop;

        [JsonProperty("limit")]
        public double? Limit;

        [JsonProperty("frequency")]
        public Frequency Frequency;

        [JsonConverter(typeof(DateFormatConverter), "dd/MM/yyyy")]
        [JsonProperty("date")]
        public DateTime Date;

        [JsonProperty("spread")]
        public double Spread;
    }
    public class Rules
    {
        [JsonProperty("rules")]
        public List<Rule> Items;

        [JsonProperty("description")]
        public string Description;
    }
}