using CommunityToolkit.Mvvm.ComponentModel;

namespace ResumeBuilderMAUI.Models
{
    public partial class ProjectModel : ObservableObject
    {
        [ObservableProperty]
        public int? id;

        [ObservableProperty]
        public string? projectName;

        [ObservableProperty]
        public string? description;

        [ObservableProperty]
        public string? startDate;

        [ObservableProperty]
        public string? endDate;

        [ObservableProperty]
        public string? status;

        [ObservableProperty]
        public string? link;
    }
}
