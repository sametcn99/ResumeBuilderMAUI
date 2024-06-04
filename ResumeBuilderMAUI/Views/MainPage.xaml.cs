using ResumeBuilderMAUI.ViewModels;

namespace ResumeBuilderMAUI.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            MainViewModel viewModel = MainViewModel.Instance;

            BindingContext = viewModel;
        }
    }
}
