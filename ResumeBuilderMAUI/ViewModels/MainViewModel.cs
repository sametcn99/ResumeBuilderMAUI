using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ResumeBuilderMAUI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? firstName;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? lastName;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? summary;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? phoneNumber;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? email;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? website;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? links;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? address;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? skill;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? city;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? state;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? country;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? zipCode;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? certifications;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? languages;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? linkedIn;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? gitHub;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private ObservableCollection<string> skillList = new ObservableCollection<string> { "skill1", "skill2" };


        [RelayCommand]
        void AddSkill()
        {
            Application.Current?.MainPage?.DisplayAlert("Skill Added", Skill, "OK");
            SkillList.Add(Skill);
            Skill = string.Empty;
        }



        public string Data => $"First Name: {FirstName}\nLast Name: {LastName}\nPhone Number: {PhoneNumber}\nSkills: ${SkillList.Count}";

        [RelayCommand]
        void Save()
        {
            Console.WriteLine($"Saving {Data}");
            if (Data.Length > 5)
            {
                if (FirstName.Length < 5 || LastName.Length < 5)
                {
                    Application.Current?.MainPage?.DisplayAlert(FirstName.Length < 5 ? "First Name" : "Last Name", "Name should be more than 5 characters", "OK");
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