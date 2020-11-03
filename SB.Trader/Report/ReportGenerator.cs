using SB.Trader.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SB.Trader.Report
{
    public static class ReportGenerator
    {
        public static string BuildSummary(this List<Position> list)
        {
            var output = string.Empty;
            output += "<b><u>Summary</u></b>";
            output += "<ul>";
            output += $"<li>Positions: {list.Count}</li>";
            output += $"<li>Positions remaining open: {list.Where(x => x.PositionStatus == Model.Enum.PositionStatus.OPEN).Count()}</li>";
            output += $"<li>Positions stopped: {list.Where(x => x.PositionStatus == Model.Enum.PositionStatus.STOP_REACHED).Count()}</li>";
            output += $"<li>Positions closed in profit: {list.Where(x => x.PositionStatus == Model.Enum.PositionStatus.LIMIT_REACHED).Count()}</li>";
            output += "</ul>";

            return output;
        }
        public static void GenerateReport(this List<Position> list, Model.Rules rules)
        {
            var template = File.ReadAllText("./Report/ResultTemplate.html");
            var tableContent = list.ToHtmlTable();
            template = template.Replace("[TABLE]", tableContent);
            template = template.Replace("[DESCRIPTION]", rules.Description);
            template = template.Replace("[SUMMARY]", list.BuildSummary());
            File.WriteAllText("./Report/Result.html", template);
        }
        private static string ToHtmlTable<T>(this List<T> list)
        {
            var ret = string.Empty;

            return list == null || !list.Any()
                ? ret
                : "<table id='mainTable' class='display' style='width:100%'>" +
                  list.First().GetType().GetProperties().Select(p => p.Name).ToList().ToColumnHeaders() +
                  list.Aggregate(ret, (current, t) => current + t.ToHtmlTableRow()) +
                  "</table>";
        }
        private static string ToColumnHeaders<T>(this List<T> list)
        {
            var ret = string.Empty;

            return list == null || !list.Any()
                ? ret
                : "<thead><tr>" +
                  list.Aggregate(ret,
                      (current, propValue) =>
                          current +
                          ("<th>" +
                           (Convert.ToString(propValue).Length <= 100
                               ? Convert.ToString(propValue)
                               : Convert.ToString(propValue).Substring(0, 100))+ "</th>")) +
                  "</tr></thead>";
        }
        private static string ToHtmlTableRow<T>(this T classObject)
        {
            var ret = string.Empty;

            ret =  classObject == null
                ? ret
                : "<tr>" +
                  classObject.GetType()
                      .GetProperties()
                      .Aggregate(ret,
                          (current, prop) =>
                              current + ("<td>" +
                                         (Convert.ToString(prop.GetValue(classObject, null)).Length <= 100
                                             ? Convert.ToString(prop.GetValue(classObject, null))
                                             : Convert.ToString(prop.GetValue(classObject, null)).Substring(0, 100)) +
                                         "</td>")) + "</tr>";
            return $"<tbody>{ret}</tbody>";
        }
    }
}
