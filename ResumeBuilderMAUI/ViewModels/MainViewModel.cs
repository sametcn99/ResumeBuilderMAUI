using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Text.Json;

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
            if (!string.IsNullOrWhiteSpace(Skill))
                SkillList.Add(Skill);
            Skill = string.Empty;
        }

        public object Data => new
        {
            FirstName,
            LastName,
            PhoneNumber,
            SkillList,
            Summary,
            Email,
            Website,
            Links,
            Address,
            City,
            State,
            Country,
            ZipCode,
            Certifications,
            Languages,
            LinkedIn,
            GitHub
        };



        [RelayCommand]
        void Save()
        {
            Application.Current?.MainPage?.DisplayAlert("Saved", $"{JsonSerializer.Serialize(Data)}", "OK");
        }
    }
}