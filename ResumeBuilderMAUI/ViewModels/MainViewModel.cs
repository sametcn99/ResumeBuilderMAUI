using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmHelpers;
using ResumeBuilderMAUI.Helpers;
using ResumeBuilderMAUI.Models;
using System.Collections.ObjectModel;

namespace ResumeBuilderMAUI.ViewModels
{
    public partial class MainViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        // Personal Information
        [ObservableProperty]
        private string? firstName;

        [ObservableProperty]
        private string? lastName;

        [ObservableProperty]
        private string? summary;

        [ObservableProperty]
        private string? phoneNumber;

        [ObservableProperty]
        private string? email;

        [ObservableProperty]
        private string? website;

        [ObservableProperty]
        private string? linkedIn;

        [ObservableProperty]
        private string? gitHub;

        [ObservableProperty]
        private string? certifications;

        [ObservableProperty]
        private string? languages;

        [ObservableProperty]
        private string? address;

        [ObservableProperty]
        private string? skill;

        // Experience
        [ObservableProperty]
        private string? experienceTitle;

        [ObservableProperty]
        private string? experienceDescription;

        [ObservableProperty]
        private string? experiencePosition;

        [ObservableProperty]
        private string? experienceStartDate;

        [ObservableProperty]
        private string? experienceEndDate;

        [ObservableProperty]
        private string? experienceCompany;

        //[ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(Data))]
        //private ObservableCollection<ExperienceModel> experiences = new ObservableCollection<ExperienceModel>();

        public ObservableRangeCollection<ExperienceModel> Experiences { get; set; } = new ObservableRangeCollection<ExperienceModel>();


        void ClearExperienceEntries()
        {
            ExperienceTitle = string.Empty;
            ExperienceCompany = string.Empty;
            ExperienceDescription = string.Empty;
            ExperiencePosition = string.Empty;
            ExperienceStartDate = string.Empty;
            ExperienceEndDate = string.Empty;
        }

        [RelayCommand]
        void AddExperience()
        {
            var experienceData = new ExperienceModel
            {
                Id = Experiences.Count + 1,
                Title = ExperienceTitle,
                Description = ExperienceDescription,
                Company = ExperienceCompany,
                Position = ExperiencePosition,
                StartDate = ExperienceStartDate,
                EndDate = ExperienceEndDate,
            };
            Experiences.Add(experienceData);
            ClearExperienceEntries();
        }

        [RelayCommand]
        void RemoveExperience(int id)
        {
            var experienceToRemove = Experiences.FirstOrDefault(x => x.Id == id);
            if (experienceToRemove != null)
            {
                Experiences.Remove(experienceToRemove);
            }
        }

        // Education
        [ObservableProperty]
        private string? educationSchool;

        [ObservableProperty]
        private string? educationDescription;

        [ObservableProperty]
        private string? educationDegree;


        [ObservableProperty]
        private string? educationStartDate;

        [ObservableProperty]
        private string? educationEndDate;

        [ObservableProperty]
        private string? educationGrade;

        public ObservableRangeCollection<EducationModel> Educations { get; set; } = new ObservableRangeCollection<EducationModel>();

        void ClearEducationEntries()
        {
            EducationSchool = string.Empty;
            EducationDegree = string.Empty;
            EducationStartDate = string.Empty;
            EducationEndDate = string.Empty;
            EducationGrade = string.Empty;
            EducationDescription = string.Empty;
        }

        [RelayCommand]
        void AddEducation()
        {
            var educationData = new EducationModel
            {
                Id = Educations.Count + 1,
                School = EducationSchool,
                Degree = EducationDegree,
                StartDate = EducationStartDate,
                EndDate = EducationEndDate,
                Grade = EducationGrade,
                Description = EducationDescription,
            };
            Educations.Add(educationData);
            ClearEducationEntries();
        }

        [RelayCommand]
        void RemoveEducation(int id)
        {
            var educationToRemove = Educations.FirstOrDefault(x => x.Id == id);
            if (educationToRemove != null)
            {
                Educations.Remove(educationToRemove);
            }
        }

        // Projects
        [ObservableProperty]
        private string? projectTitle;

        [ObservableProperty]
        private string? projectDescription;

        [ObservableProperty]
        private string? projectStartDate;

        [ObservableProperty]
        private string? projectEndDate;

        [ObservableProperty]
        private string? projectStatus;

        [ObservableProperty]
        private string? projectLink;

        void ClearProjectEntries()
        {
            ProjectTitle = string.Empty;
            ProjectDescription = string.Empty;
            ProjectStartDate = string.Empty;
            ProjectEndDate = string.Empty;
            ProjectStatus = string.Empty;
            ProjectLink = string.Empty;
        }

        public ObservableRangeCollection<ProjectModel> Projects { get; set; } = new ObservableRangeCollection<ProjectModel>();
        [RelayCommand]
        void AddProject()
        {
            var projectData = new ProjectModel
            {
                Id = Projects.Count + 1,
                Title = ProjectTitle,
                Description = ProjectDescription,
                StartDate = ProjectStartDate,
                EndDate = ProjectEndDate,
                Status = ProjectStatus,
                Link = ProjectLink,
            };
            Projects.Add(projectData);
            ClearProjectEntries();
        }

        [RelayCommand]
        void RemoveProject(int id)
        {
            var projectToRemove = Projects.FirstOrDefault(x => x.Id == id);
            if (projectToRemove != null)
            {
                Projects.Remove(projectToRemove);
            }
        }

        // Skills
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Data))]
        private ObservableCollection<string> skillList = new ObservableCollection<string> { };


        [RelayCommand]
        void AddSkill()
        {
            if (!string.IsNullOrWhiteSpace(Skill))
                SkillList.Add(Skill);
            Skill = string.Empty;
        }

        [RelayCommand]
        void RemoveSkill(string skill)
        {
            SkillList.Remove(skill);
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
            Address,
            Certifications,
            Languages,
            LinkedIn,
            GitHub,
            Experiences,
            Projects
        };

        [RelayCommand]
        void ClearEntries()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Summary = string.Empty;
            PhoneNumber = string.Empty;
            Email = string.Empty;
            Website = string.Empty;
            Address = string.Empty;
            Certifications = string.Empty;
            Languages = string.Empty;
            LinkedIn = string.Empty;
            GitHub = string.Empty;
            Experiences.Clear();
            Projects.Clear();
            SkillList.Clear();
        }

        private ObservableCollection<string> Errors { get; set; } = new ObservableCollection<string>();

        void CheckForErrors()
        {
            Errors.Clear();
            if (string.IsNullOrWhiteSpace(FirstName))
                Errors.Add("First Name is required");

            if (string.IsNullOrWhiteSpace(LastName))
                Errors.Add("Last Name is required");

            if (!Validators.IsValidEmail(Email) || Email?.Length < 5)
                Errors.Add("Invalid Email");

            if (string.IsNullOrWhiteSpace(FirstName) || FirstName.Length < 3)
                Errors.Add("First Name is required");

            if (string.IsNullOrWhiteSpace(LastName) || LastName.Length < 3)
                Errors.Add("Last Name is required");

            if (string.IsNullOrWhiteSpace(Summary) || Summary.Length < 10)
                Errors.Add("Summary is required");

            if (string.IsNullOrWhiteSpace(PhoneNumber) || PhoneNumber.Length < 10)
                Errors.Add("Phone Number is required");

            if (Validators.IsValidUrl(Website))
                Errors.Add("Invalid Website URL");

            if (Validators.IsValidUrl(LinkedIn))
                Errors.Add("Invalid LinkedIn URL");

            if (Validators.IsValidUrl(GitHub))
                Errors.Add("Invalid GitHub URL");
        }

        [RelayCommand]
        void Save()
        {
            CheckForErrors();
            if (Errors.Count > 0)
            {
                Application.Current?.MainPage?.DisplayAlert("Errors", $"{Formatters.FormatJson(Errors)}", "OK");
                return;
            }
            else
            {
                Application.Current?.MainPage?.DisplayAlert("Saved", $"{Formatters.FormatJson(Data)}", "OK");
                ClearEntries();
            }
        }
    }
}
