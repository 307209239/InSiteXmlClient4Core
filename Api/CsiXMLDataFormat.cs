using System;
using System.Globalization;

namespace InSiteXmlClient4Core.Api
{
    /// <summary>
    /// XML数据格式化
    /// </summary>
    public class CsiXmlDataFormat
    {
        private const string mkDatePattern = "yyyy-MM-dd";
        private const string mkDateTimePattern = "yyyy-MM-dd'T'HH:mm:sszzz";
        private const string mkDecimalPattern = "0.0##############################";
        private const string mkFloatPattern = "#######0.0####################E0";
        private const string mkTimePattern = "HH:mm:ss";

        private CsiXmlDataFormat()
        {
        }

        internal static string GetUTCOffset() =>
            DateTime.Now.ToString("zzz");

        internal static DateTime Lexical2DateTime(string val) =>
            DateTime.Parse(val);

        internal static string Lexical2LocaleDate(string val)
        {
            DateTime time = Lexical2DateTime(val);
            DateTimeFormatInfo dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
            return time.ToString(dateTimeFormat.ShortDatePattern);
        }

        internal static string Lexical2LocaleDateTime(string val)
        {
            DateTime time = Lexical2DateTime(val);
            DateTimeFormatInfo dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
            return time.ToString(dateTimeFormat.ShortDatePattern + " " + dateTimeFormat.LongTimePattern);
        }

        internal static string Lexical2LocaleDecimal(string val) =>
            decimal.Parse(val).ToString();

        internal static string Lexical2LocaleFloat(string val) =>
            double.Parse(val).ToString();

        internal static string Lexical2LocaleTime(string val)
        {
            DateTime time = Lexical2DateTime(val);
            DateTimeFormatInfo dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
            return time.ToString(dateTimeFormat.LongTimePattern);
        }

        internal static string Locale2LexicalDate(string val) =>
            Locale2LexicalDateTime(val);

        internal static string Locale2LexicalDateTime(string val) =>
            DateTime.Parse(val).ToString("yyyy-MM-dd'T'HH:mm:sszzz");

        internal static string Locale2LexicalDecimal(string val) =>
            decimal.Parse(val).ToString("0.0##############################");

        internal static string Locale2LexicalFloat(string val) =>
            double.Parse(val).ToString("#######0.0####################E0");

        internal static string Locale2LexicalTime(string val) =>
            Locale2LexicalDateTime(val);
    }

}