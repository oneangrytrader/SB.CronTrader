using CommandLine;
using CommandLine.Text;

namespace SB.Trader
{
    public class Options
    {
        [Option('r', "rules file path", Required = true, HelpText = "Rules in json format.")]
        public string RulesPath { get; set; }

        [Option('d', "data file path", Required = true, HelpText = "Data file from duskacopy")]
        public string DataPath { get; set; }
    }
}
