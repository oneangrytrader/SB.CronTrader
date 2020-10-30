using Newtonsoft.Json;
using System.Collections.Generic;

namespace SB.Trader.Model
{
    public class Rule
    {
        [JsonProperty("type")]
        public string Type;

        [JsonProperty("strategy")]
        public string Strategy;

        [JsonProperty("level")]
        public int Level;

        [JsonProperty("direction")]
        public string Direction;

        [JsonProperty("stop")]
        public int Stop;
    }

    public class Rules
    {
        [JsonProperty("Rules")]
        public List<Rule> Items;
    }
}