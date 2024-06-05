using ResumeBuilderMAUI.ViewModels;

namespace ResumeBuilderMAUI.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainViewModel vm)
        {
            BindingContext = vm;
            InitializeComponent();
        }
    }
}
