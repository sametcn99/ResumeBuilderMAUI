namespace ResumeBuilderMAUI.Helpers
{
    internal class Validators
    {
        public static bool IsValidEmail(string email)
        {
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

        public static bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri? uriResult) && uriResult != null;
        }
    }
}
