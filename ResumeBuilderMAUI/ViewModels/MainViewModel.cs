using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ResumeBuilderMAUI.Models;
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
        private string? linkedIn;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? gitHub;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? certifications;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? languages;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? address;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? skill;


        // Experience
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? experienceTitle;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? experienceDetail;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? experiencePosition;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? experienceStartDate;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? experienceEndDate;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? experienceDescription;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private string? experienceCompany;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private ObservableCollection<ExperienceModel> experiences = new ObservableCollection<ExperienceModel>();

        // Skills
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private ObservableCollection<string> skillList = new ObservableCollection<string> { "skill1", "skill2" };


        [RelayCommand]
        void AddExperience()
        {
            var experienceData = new ExperienceModel
            {
                Id = Experiences.Count + 1,
                Title = ExperienceTitle,
                Description = ExperienceDetail,
                Company = ExperienceCompany,
                Position = ExperiencePosition,
                StartDate = ExperienceStartDate,
                EndDate = ExperienceEndDate,
            };
            Experiences.Add(experienceData);
            Application.Current?.MainPage?.DisplayAlert("Experience Added", JsonSerializer.Serialize(experienceData), "OK");
        }

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
            Summary,
            PhoneNumber,
            SkillList,
            Email,
            Website,
            Links,
            Address,
            Certifications,
            Languages,
            LinkedIn,
            GitHub,
            Experiences
        };
        [RelayCommand]
        void ClearData()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Summary = string.Empty;
            PhoneNumber = string.Empty;
            Email = string.Empty;
            Website = string.Empty;
            Links = string.Empty;
            Address = string.Empty;
            Certifications = string.Empty;
            Languages = string.Empty;
            LinkedIn = string.Empty;
            GitHub = string.Empty;
            Experiences.Clear();
            SkillList.Clear();
        }

        [RelayCommand]
        void Save()
        {
            Application.Current?.MainPage?.DisplayAlert("Saved", $"{JsonSerializer.Serialize(Data)}", "OK");
            ClearData();
        }
    }
}