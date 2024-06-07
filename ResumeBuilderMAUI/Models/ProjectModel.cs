using CommunityToolkit.Mvvm.ComponentModel;

namespace ResumeBuilderMAUI.Models
{
    public partial class ProjectModel : ObservableObject
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? Status { get; set; }
        public string? Link { get; set; }
    }
}
