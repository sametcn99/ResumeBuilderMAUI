using ResumeBuilderMAUI.ViewModels;

namespace ResumeBuilderMAUI.Views;

public partial class CreateResumePage : ContentPage
{
    public CreateResumePage(MainViewModel? vm)
    {
        if (vm is null)
            BindingContext = new MainViewModel();
        else
            BindingContext = vm;
        InitializeComponent();
    }
    protected override bool OnBackButtonPressed()
    {
        if (!string.IsNullOrEmpty((BindingContext as MainViewModel)?.FirstName))
        {
            _ = Dispatcher.DispatchAsync(async () =>
            {
                var result = await this.DisplayAlert("Alert!", "Are you sure you want to exit without saving data?", "Yes", "No");
                if (result)
                {
                    await Navigation.PopAsync();
                }
            });
        }
        else
        {
            Navigation.PopAsync();
        }
        return true;
    }
}
