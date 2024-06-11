using CommunityToolkit.Maui.Core;
using Microsoft.Extensions.Logging;
using QuestPDF.Infrastructure;
using ResumeBuilderMAUI.Services;
using ResumeBuilderMAUI.ViewModels;
using ResumeBuilderMAUI.Views;

namespace ResumeBuilderMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>().UseMauiCommunityToolkitCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Montserrat-VariableFont_wght.ttf", "Montserrat");
                });
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<CreateResumePage>();
            builder.Services.AddSingleton<ResumeService>();

#if !ANDROID && !IOS
            QuestPDF.Settings.License = LicenseType.Community;
#endif

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();
            return app;
        }
    }
}
