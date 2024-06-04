using ResumeBuilderMAUI.ViewModels;

namespace ResumeBuilderMAUI
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}
