using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ResumeBuilderMAUI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FullName))]
        private string firstName = "";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FullName))]
        private string lastName = "";


        public string FullName => $"{FirstName} {LastName}";

        [RelayCommand]
        void Save()
        {
            Console.WriteLine($"Saving {FullName}");
            if (FullName.Length > 5)
            {
                if (firstName.Length < 5 || lastName.Length < 5)
                {
                    Application.Current?.MainPage?.DisplayAlert(firstName.Length < 5 ? "First Name" : "Last Name", "Name should be more than 5 characters", "OK");
                }
                else
                {
                    Application.Current?.MainPage?.DisplayAlert("Saved", FullName, "OK");
                }
            }
            else
            {
                Application.Current?.MainPage?.DisplayAlert("Full Name", "Full Name should be more than 5 characters", "OK");
            }
        }
    }
}