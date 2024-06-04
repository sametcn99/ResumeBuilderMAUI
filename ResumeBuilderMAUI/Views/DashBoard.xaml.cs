using ResumeBuilderMAUI.ViewModels;

namespace ResumeBuilderMAUI.Views;

public partial class DashBoard : ContentPage
{
    public DashBoard()
    {
        InitializeComponent();
        MainViewModel viewModel = MainViewModel.Instance;

        BindingContext = viewModel;
    }
}