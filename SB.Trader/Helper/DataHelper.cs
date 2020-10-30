using SB.Trader.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace SB.Trader.Helper
{
    public class DataHelper
    {
        public static List<Candle> GetCandles(string path, string market, bool withVolume)
        {
            var candles = new List<Candle>();
            var data = File.ReadAllLines(path);

            foreach (var line in data.Skip(1))
            {
                var values = line.Split(",");
                var date = values[0].Split(" ");
                var candle = new Candle
                {
                    Market = market,
                    Date = DateTime.ParseExact($"{date[0]} {date[1]}", "dd.MM.yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture),
                    Open = double.Parse(values[1]),
                    High = double.Parse(values[2]),
                    Low = double.Parse(values[3]),
                    Close = double.Parse(values[4]),
                    Volume = withVolume ? double.Parse(values[5]) : 0
                };
                candles.Add(candle);
            }
            return candles;
        }
    }
}
