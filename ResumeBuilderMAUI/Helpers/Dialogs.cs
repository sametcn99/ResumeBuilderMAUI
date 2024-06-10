﻿using CommunityToolkit.Maui.Storage;

namespace ResumeBuilderMAUI.Helpers
{
    class Dialogs
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

        public static async Task<string> PickFolder(CancellationToken cancellationToken)
        {
            var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.StorageRead>();
            }

            if (status == PermissionStatus.Granted)
            {
                var result = await FolderPicker.Default.PickAsync(cancellationToken);
                return result?.Folder?.Path;
            }
            else
            {
                // Handle permission denied scenario
                return null;
            }
        }

        public static async Task SaveResume(CancellationToken cancellationToken, string fileName, byte[] document)
        {
            using var stream = new MemoryStream(document);
            var fileSaverResult = await FileSaver.Default.SaveAsync(fileName, stream, cancellationToken);
            if (fileSaverResult.IsSuccessful)
            {
                Dialogs.ShowAlert("Success", $"The file was saved successfully to location: {fileSaverResult.FilePath}");
            }
            else
            {
                Dialogs.ShowAlert("Error", $"The file was not saved successfully with error: {fileSaverResult.Exception.Message}");
            }
        }
    }
}
