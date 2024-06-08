using ResumeBuilderMAUI.ViewModels;

namespace ResumeBuilderMAUI.Helpers
{
    class ClearEntriesHelper
    {
        public static void ClearAllEntries(MainViewModel viewModel)
        {
            viewModel.FirstName = string.Empty;
            viewModel.LastName = string.Empty;
            viewModel.Summary = string.Empty;
            viewModel.PhoneNumber = string.Empty;
            viewModel.Email = string.Empty;
            viewModel.Website = string.Empty;
            viewModel.Address = string.Empty;
            viewModel.Certifications = string.Empty;
            viewModel.Languages = string.Empty;
            viewModel.LinkedIn = string.Empty;
            viewModel.GitHub = string.Empty;
            viewModel.Skill = string.Empty;
            ClearProjectEntries(viewModel);
            ClearEducationEntries(viewModel);
            ClearExperienceEntries(viewModel);
            viewModel.Educations.Clear();
            viewModel.Experiences.Clear();
            viewModel.Projects.Clear();
            viewModel.SkillList.Clear();
        }

        public static void ClearProjectEntries(MainViewModel viewModel)
        {
            viewModel.ProjectTitle = string.Empty;
            viewModel.ProjectDescription = string.Empty;
            viewModel.ProjectStartDate = string.Empty;
            viewModel.ProjectEndDate = string.Empty;
            viewModel.ProjectStatus = string.Empty;
            viewModel.ProjectLink = string.Empty;
        }

        public static void ClearEducationEntries(MainViewModel viewModel)
        {
            viewModel.EducationSchool = string.Empty;
            viewModel.EducationDegree = string.Empty;
            viewModel.EducationStartDate = string.Empty;
            viewModel.EducationEndDate = string.Empty;
            viewModel.EducationGrade = string.Empty;
            viewModel.EducationDescription = string.Empty;
        }

        public static void ClearExperienceEntries(MainViewModel viewModel)
        {

            viewModel.ExperienceTitle = string.Empty;
            viewModel.ExperienceCompany = string.Empty;
            viewModel.ExperienceDescription = string.Empty;
            viewModel.ExperiencePosition = string.Empty;
            viewModel.ExperienceStartDate = string.Empty;
            viewModel.ExperienceEndDate = string.Empty;
        }
    }
}
