using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmHelpers;
using ResumeBuilderMAUI.Helpers;
using ResumeBuilderMAUI.Models;
using ResumeBuilderMAUI.Services;
using System.Collections.ObjectModel;

namespace ResumeBuilderMAUI.ViewModels
{
    public partial class MainViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
#if DEBUG
        public MainViewModel()
        {
            FillEntriesInDebug.FillEntries(this);
        }
#endif

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
        private string? certification;

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

        public ObservableRangeCollection<Experience> Experiences { get; set; } = [];

        [RelayCommand]
        void AddExperience()
        {
            if (string.IsNullOrWhiteSpace(ExperienceTitle)) return;
            var experienceData = new Experience
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
            ClearEntriesHelper.ClearExperienceEntries(this);
        }

        [RelayCommand]
        void RemoveExperience(int id)
        {
            var experienceToRemove = Experiences.FirstOrDefault(x => x.Id == id);
            if (experienceToRemove != null)
                Experiences.Remove(experienceToRemove);
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

        public ObservableRangeCollection<Education> Educations { get; set; } = [];

        [RelayCommand]
        void AddEducation()
        {
            if (string.IsNullOrWhiteSpace(EducationSchool)) return;

            var educationData = new Education
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
            ClearEntriesHelper.ClearEducationEntries(this);
        }

        [RelayCommand]
        void RemoveEducation(int id)
        {
            var educationToRemove = Educations.FirstOrDefault(x => x.Id == id);
            if (educationToRemove != null)
                Educations.Remove(educationToRemove);
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
        private string? projectLink;

        public ObservableRangeCollection<Project> Projects { get; set; } = [];

        [RelayCommand]
        void AddProject()
        {
            if (string.IsNullOrWhiteSpace(ProjectTitle)) return;

            var projectData = new Project
            {
                Id = Projects.Count + 1,
                Title = ProjectTitle,
                Description = ProjectDescription,
                StartDate = ProjectStartDate,
                EndDate = ProjectEndDate,
                Link = ProjectLink,
            };
            Projects.Add(projectData);
            ClearEntriesHelper.ClearProjectEntries(this);
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

        // Certifications
        [ObservableProperty]
        private ObservableCollection<string> certifications = [];

        [RelayCommand]
        void AddCertification()
        {
            if (string.IsNullOrWhiteSpace(Certification)) return;
            Certifications.Add(Certification);
            Certification = string.Empty;
        }

        [RelayCommand]
        void RemoveCertification(string certification) => Certifications.Remove(certification);

        // Skills
        [ObservableProperty]
        private ObservableCollection<string> skillList = [];

        [RelayCommand]
        void AddSkill()
        {
            if (string.IsNullOrWhiteSpace(Skill)) return;
            SkillList.Add(Skill);
            Skill = string.Empty;
        }

        [RelayCommand]
        void RemoveSkill(string skill) => SkillList.Remove(skill);

        private ObservableCollection<string> Errors { get; set; } = [];

        void CheckForErrors()
        {
            Errors.Clear();
            FormatData();
            if (string.IsNullOrWhiteSpace(FirstName) || FirstName.Length < 3)
                Errors.Add("First Name is required");

            if (string.IsNullOrWhiteSpace(LastName) || LastName.Length < 3)
                Errors.Add("Last Name is required");

            if (!Validators.IsValidEmail(Email) & Email?.Length > 5)
                Errors.Add("Invalid Email");

            if (Validators.IsValidUrl(Website))
                Errors.Add("Invalid Website URL");

            if (Validators.IsValidUrl(LinkedIn))
                Errors.Add("Invalid LinkedIn URL");

            if (Validators.IsValidUrl(GitHub))
                Errors.Add("Invalid GitHub URL");
        }

        void FormatData()
        {
            Website = Formatters.FormatUrl(Website);
            LinkedIn = Formatters.FormatUrl(LinkedIn);
            GitHub = Formatters.FormatUrl(GitHub);
        }

        [RelayCommand]
        async Task Save()
        {
            try
            {
                CheckForErrors();
                if (Errors.Count > 0)
                {
                    Dialogs.ShowAlert("Error", string.Join("Errors", $"{Formatters.FormatJson(Errors)}"));
                    return;
                }
                string ResumeId = $"{this.FirstName}_{this.LastName}_{DateTime.Now:yyyy_MM_dd_HH_mm_ss}";

                await LocalDbService.AddPerson(new Person
                {
                    ResumeId = ResumeId,
                    ResumeDate = DateTime.Now.ToString("MM/dd/yyyy"),
                    FirstName = FirstName,
                    LastName = LastName,
                    Summary = Summary,
                    PhoneNumber = PhoneNumber,
                    Email = Email,
                    Website = Website,
                    Address = Address,
                    Languages = Languages,
                    LinkedIn = LinkedIn,
                    GitHub = GitHub,
                });

                for (int i = 0; i < this.Certifications.Count; i++)
                {
                    await LocalDbService.AddCertification(new Certification
                    {
                        ResumeId = ResumeId,
                        Id = i,
                        Name = this.Certifications[i]
                    });
                }

                for (int i = 0; i < this.Educations.Count; i++)
                {
                    var education = this.Educations[i];
                    await LocalDbService.AddEducation(new Education
                    {
                        ResumeId = ResumeId,
                        Id = education.Id,
                        School = education.School,
                        Degree = education.Degree,
                        StartDate = education.StartDate,
                        EndDate = education.EndDate,
                        Description = education.Description
                    });
                }

                for (int i = 0; i < this.Experiences.Count; i++)
                {
                    var experience = this.Experiences[i];
                    await LocalDbService.AddExperience(new Experience
                    {
                        ResumeId = ResumeId,
                        Id = experience.Id,
                        Company = experience.Company,
                        Position = experience.Position,
                        StartDate = experience.StartDate,
                        EndDate = experience.EndDate,
                        Description = experience.Description
                    });
                }

                for (int i = 0; i < this.Projects.Count; i++)
                {
                    var project = this.Projects[i];
                    await LocalDbService.AddProject(new Project
                    {
                        ResumeId = ResumeId,
                        Id = i,
                        Title = project.Title,
                        Description = project.Description,
                        StartDate = project.StartDate,
                        EndDate = project.EndDate,
                        Status = project.Status,
                        Link = project.Link
                    });
                }

                for (int i = 0; i < this.SkillList.Count; i++)
                {
                    var skill = this.SkillList[i];
                    await LocalDbService.AddSkill(new Skill
                    {
                        Id = i,
                        ResumeId = ResumeId,
                        Name = skill
                    });
                }
                ResumeService.CreateResumePDF(this);
                //Dialogs.ShowAlert("Saved", $"{Formatters.FormatJson(new
                //{
                //    Id = 1,
                //    FirstName,
                //    LastName,
                //    Summary,
                //    PhoneNumber,
                //    SkillList,
                //    Email,
                //    Website,
                //    Address,
                //    Certifications,
                //    Languages,
                //    LinkedIn,
                //    GitHub,
                //    Educations,
                //    Experiences,
                //    Projects
                //})}");
                ClearEntriesHelper.ClearAllEntries(this);
            }
            catch (Exception ex)
            {
                Dialogs.ShowAlert("Error", ex.Message);
            }
        }
    }
}
