﻿using ResumeBuilderMAUI.Helpers;
using ResumeBuilderMAUI.ViewModels;

namespace ResumeBuilderMAUI.Services
{
    internal class ResumeService
    {
        public static async Task CreateResumePDF(MainViewModel mainViewModel)
        {
            //string filePath = Path.Combine(FileSystem.Current.CacheDirectory, $"{DateTime.Now:yyyyMMdd_HHmmss}.pdf");


            try
            {
                var document = ClassicResumeLayout.GenerateClassicResumeLayout(mainViewModel);
                // open the PDF file
            }
            catch (Exception ex)
            {
                Dialogs.ShowAlert("Error", ex.Message);
                throw;
            }
        }
    }
}
