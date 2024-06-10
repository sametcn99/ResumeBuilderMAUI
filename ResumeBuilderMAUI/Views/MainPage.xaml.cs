using ResumeBuilderMAUI.Services;
using ResumeBuilderMAUI.ViewModels;
using System.Collections.ObjectModel;

namespace ResumeBuilderMAUI.Views
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<string> ResumeIds { get; set; }

        public MainPage()
        {
            LoadNames();
            BindingContext = new LoginViewModel();
            InitializeComponent();

            // Subscribe to the SelectedIndexChanged event
            NamePicker.SelectedIndexChanged += OnNamePickerSelectedIndexChanged;

            UpdateContinueButton();

        }

        private void OnNamePickerSelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateContinueButton();
        }

        private void UpdateContinueButton()
        {
            if (NamePicker.SelectedIndex == -1)
            {
                ContinueButton.IsEnabled = false;
                ContinueButton.BackgroundColor = Color.FromHex("#B0B0B0");
            }
            else
            {
                ContinueButton.IsEnabled = true;
                ContinueButton.BackgroundColor = Color.FromHex("#2196F3");
            }
        }

        public async Task LoadNames()
        {
            var persons = await LocalDbService.GetAllPersons();
            ResumeIds = new ObservableCollection<string>(persons.Select(p => $"{p.ResumeId}").Distinct());
            NamePicker.ItemsSource = ResumeIds;
        }

        async void OnContinueButtonClicked(object sender, EventArgs e)
        {

            var selectedResumeId = ResumeIds[NamePicker.SelectedIndex];
            var resume = await LocalDbService.GetResumeByResumeId(selectedResumeId);
            await Navigation.PushAsync(new CreateResumePage(resume));
        }
    }
}
