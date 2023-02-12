using DevExpress.Maui;
using Microsoft.Extensions.Logging;
using Tutor.Mobile.ViewModels;
using Tutor.MobileUI.Pages;
using Tutor.Shared.Validators;
using Tutor.Client.Logic;

namespace Tutor.MobileUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseDevExpress()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            builder
                .Services
                .AddTransient<LoginPage>()
                .AddTransient<LoginViewModel>()
                .AddValidators()
                .AddLogic();

            return builder.Build();
        }
    }
}