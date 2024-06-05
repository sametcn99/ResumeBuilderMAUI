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
        async void OnCreateResumeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateResumePage(BindingContext as MainViewModel));
        }
        void OnViewSourceCodeClicked(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                await Launcher.OpenAsync(new Uri("https://github.com/sametcn99/ResumeBuilderMAUI"));
            }).Wait();
        }
    }

}
