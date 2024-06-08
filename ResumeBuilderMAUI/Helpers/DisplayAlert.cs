namespace ResumeBuilderMAUI.Helpers
{
    class DisplayAlertHelpers
    {
        public static void ShowAlert(string title, string message)
        {
            if (Application.Current?.MainPage != null)
            {
                Application.Current.MainPage.DisplayAlert(title, message, "OK");
            }
            else
            {
                throw new InvalidOperationException("MainPage is not set in the current application.");
            }
        }
    }
}
