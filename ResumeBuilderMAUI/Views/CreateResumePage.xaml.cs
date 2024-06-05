using ResumeBuilderMAUI.ViewModels;

namespace ResumeBuilderMAUI.Views;

public partial class CreateResumePage : ContentPage
{
    public CreateResumePage(MainViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}