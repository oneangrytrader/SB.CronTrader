using CommandLine;
using Newtonsoft.Json;
using SB.Trader.Model;
using System.Collections.Generic;
using System.IO;

namespace SB.Trader
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
            .WithParsed(Run)
            .WithNotParsed(HandleParseError);
        }
        static void Run(Options options)
        {
            var rules = JsonConvert.DeserializeObject<Rules>(File.ReadAllText(options.RulesPath));
        }
        static void HandleParseError(IEnumerable<Error> errs)
        {
            //in case there is any need for special handling
        }
    }
}
