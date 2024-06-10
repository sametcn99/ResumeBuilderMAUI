using QuestPDF.Fluent;
using ResumeBuilderMAUI.Helpers;
using ResumeBuilderMAUI.ViewModels;

namespace ResumeBuilderMAUI.Services
{
    internal class ResumeService
    {
        public static void CreateResumePDF(MainViewModel mainViewModel)
        {
            string filePath = Path.Combine(FileSystem.Current.CacheDirectory, $"{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch (IOException ioEx)
            {
                DisplayAlertHelpers.ShowAlert("Error", ioEx.Message);
                return;
            }

            try
            {
                var document = ClassicResumeLayout.GenerateClassicResumeLayout(mainViewModel);
                DisplayAlertHelpers.ShowAlert("Success", $"PDF Created Successfully\n {filePath}");
                // open the PDF file
                document.GeneratePdf(filePath);
            }
            catch (Exception ex)
            {
                DisplayAlertHelpers.ShowAlert("Error", ex.Message);
            }
        }
    }
}
