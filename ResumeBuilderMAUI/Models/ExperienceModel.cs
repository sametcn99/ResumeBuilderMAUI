using CommunityToolkit.Mvvm.ComponentModel;

namespace ResumeBuilderMAUI.Models
{
    public partial class ExperienceModel : ObservableObject
    {
        [ObservableProperty]
        public int? id;

        [ObservableProperty]
        public string? title;

        [ObservableProperty]
        public string? company;

        [ObservableProperty]
        public string? position;

        [ObservableProperty]
        public string? startDate;

        [ObservableProperty]
        public string? endDate;

        [ObservableProperty]
        public string? description;
    }
}
