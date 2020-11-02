using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SB.Trader.Report
{
    public static class ReportGenerator
    {
        public static void GenerateReport<T>(this List<T> listOfClassObjects)
        {
            var template = File.ReadAllText("./Report/ResultTemplate.html");
            var tableContent = listOfClassObjects.ToHtmlTable();
            template = template.Replace("[TABLE]", tableContent);
            File.WriteAllText("./Report/Result.html", template);
        }
        private static string ToHtmlTable<T>(this List<T> listOfClassObjects)
        {
            var ret = string.Empty;

            return listOfClassObjects == null || !listOfClassObjects.Any()
                ? ret
                : "<table id='mainTable' class='display' style='width:100%'>" +
                  listOfClassObjects.First().GetType().GetProperties().Select(p => p.Name).ToList().ToColumnHeaders() +
                  listOfClassObjects.Aggregate(ret, (current, t) => current + t.ToHtmlTableRow()) +
                  "</table>";
        }
        private static string ToColumnHeaders<T>(this List<T> listOfProperties)
        {
            var ret = string.Empty;

            return listOfProperties == null || !listOfProperties.Any()
                ? ret
                : "<thead><tr>" +
                  listOfProperties.Aggregate(ret,
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
