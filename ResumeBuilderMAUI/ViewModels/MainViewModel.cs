using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ResumeBuilderMAUI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private static MainViewModel? instance;

        public static MainViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainViewModel();
                }
                return instance;
            }
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? firstName;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? lastName;


        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? phoneNumber;

        public string Data => $"First Name: {FirstName}\nLast Name: {LastName}\nPhone Number: {phoneNumber}";

        [RelayCommand]
        void Save()
        {
            Console.WriteLine($"Saving {Data}");
            if (Data.Length > 5)
            {
                if (firstName.Length < 5 || lastName.Length < 5)
                {
                    Application.Current?.MainPage?.DisplayAlert(firstName.Length < 5 ? "First Name" : "Last Name", "Name should be more than 5 characters", "OK");
                }
                else
                {
                    Application.Current?.MainPage?.DisplayAlert("Saved", $"{Data}", "OK");

                }
            }
            else
            {
                Application.Current?.MainPage?.DisplayAlert("Full Name", "Full Name should be more than 5 characters", "OK");
            }
        }
    }
}