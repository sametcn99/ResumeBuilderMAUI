using ResumeBuilderMAUI.ViewModels;

namespace ResumeBuilderMAUI.Views;

public partial class DashBoard : ContentPage
{
    public DashBoard(MainViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}