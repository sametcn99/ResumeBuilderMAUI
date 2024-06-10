using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ResumeBuilderMAUI.Views;

namespace ResumeBuilderMAUI.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [RelayCommand]
        async Task OnCreateResumeClicked()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CreateResumePage(new MainViewModel()));
        }

        [RelayCommand]
        void OnViewSourceCodeClicked()
        {
            Task.Run(async () =>
            {
                await Launcher.OpenAsync(new Uri("https://github.com/sametcn99/ResumeBuilderMAUI"));
            }).Wait();
        }
    }
}
