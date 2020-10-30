using CommandLine;
using CommandLine.Text;

namespace SB.Trader
{
    public class Options
    {
        [Option('r', "rules", Required = true, HelpText = "Rules in json format.")]
        public string RulesPath { get; set; }

        [Option('d', "data", Required = true, HelpText = "Data file from duskacopy")]
        public string DataPath { get; set; }

        [Option('e', "epic", Required = true, HelpText = "Market Epic")]
        public string Epic { get; set; }
    }
}
