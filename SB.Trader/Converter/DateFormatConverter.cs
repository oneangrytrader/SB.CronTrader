using Newtonsoft.Json.Converters;

namespace SB.Trader.Converter
{
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}
