using System.Text.Json;

namespace ResumeBuilderMAUI.Helpers
{
    internal class Validators
    {
        public static bool IsValidEmail(string? email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            return System.Text.RegularExpressions.Regex.Match(phoneNumber, @"^(\+[0-9]{9})$").Success;
        }

        public static bool IsValidUrl(string? url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri? uriResult) && uriResult != null;
        }

        public static bool IsValidJson(string json)
        {
            try
            {
                var doc = JsonDocument.Parse(json);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidDate(string date)
        {
            return System.Text.RegularExpressions.Regex.Match(date, @"^(\d{4}-\d{2}-\d{2})$").Success;
        }

        public static bool IsValidTime(string time)
        {
            return System.Text.RegularExpressions.Regex.Match(time, @"^(\d{2}:\d{2})$").Success;
        }

        public static bool IsValidNumber(string number)
        {
            return System.Text.RegularExpressions.Regex.Match(number, @"^(\d+)$").Success;
        }

        public static bool IsValidString(string str)
        {
            return !string.IsNullOrEmpty(str);
        }
    }
}
