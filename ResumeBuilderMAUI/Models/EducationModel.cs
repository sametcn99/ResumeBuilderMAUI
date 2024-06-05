using CommunityToolkit.Mvvm.ComponentModel;

namespace ResumeBuilderMAUI.Models
{
    public partial class EducationModel : ObservableObject
    {
        [ObservableProperty]
        public int? id;

        [ObservableProperty]
        public string? school;

        [ObservableProperty]
        public string? degree;

        [ObservableProperty]
        public string? fieldOfStudy;

        [ObservableProperty]
        public string? startDate;

        [ObservableProperty]
        public string? endDate;

        [ObservableProperty]
        public string? grade;
    }
}
