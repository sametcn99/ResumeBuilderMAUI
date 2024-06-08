using System.Text.Json;

namespace ResumeBuilderMAUI.Helpers
{
    internal class Formatters
    {
        public static string FormatJson(Object json)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var beautifiedJson = JsonSerializer.Serialize(json, options);
            return beautifiedJson.ToString();
        }

        public static string FormatPhoneNumber(string? phoneNumber)
        {
            if (phoneNumber == null)
                return "";
            return System.Text.RegularExpressions.Regex.Replace(phoneNumber, @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3");
        }

        public static string FormatUrl(string? url)
        {
            if (url == null)
                return "";
            return url.Replace("https://", "").Replace("http://", "");
        }

        public static string FormatDate(string? date)
        {
            if (date == null)
                return "";
            return System.Text.RegularExpressions.Regex.Replace(date, @"(\d{4})(\d{2})(\d{2})", "$2/$3/$1");
        }

        public static string FormatTime(string? time)
        {
            if (time == null)
                return "";
            return System.Text.RegularExpressions.Regex.Replace(time, @"(\d{2})(\d{2})", "$1:$2");
        }


    }
}
