using ResumeBuilderMAUI.ViewModels;

namespace ResumeBuilderMAUI.Views;

public partial class CreateResumePage : ContentPage
{
    public CreateResumePage(MainViewModel vm)
    {
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
                    (BindingContext as MainViewModel)?.ClearDataCommand.Execute(null);
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
